using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using ATM;
using ATM.Language;
using ATM.Reader;
using log4net;
using log4net.Config;

namespace AtmConsoleUI
{
    public partial class AtmMainForm : Form
    {
        public AtmMainForm()
        {
            InitializeComponent();
            XmlConfigurator.Configure();

            _languagePack = new LanguagePack("ru-RU");
            _statesDictionary = new Dictionary<AtmState, string>()
            {
                {AtmState.Ok, _languagePack.Ok},
                {AtmState.NotEnoughMoney, _languagePack.NotEnoughMoney},
                {AtmState.ImpossibleToCollectMoney, _languagePack.ImpossibleToCollectMoney},
                {AtmState.TooManyBanknotes, _languagePack.TooManyBanknotes}
            };
        }

        private static readonly ILog Log = LogManager.GetLogger(typeof(AtmMainForm));
        private readonly Dictionary<AtmState, string> _statesDictionary;

        private CashMachine _atm;
        private ILanguage _languagePack;
        private ICassetteReader<List<Cassette>> _cassetteReader;

        private void AtmMainForm_Load(object sender, EventArgs e)
        {
            Log.Debug("Start application");
            _atm = new CashMachine();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null) textBoxInputSum.Text += button.Text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxInputSum.Text = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxInputSum.Text))
                textBoxInputSum.Text = textBoxInputSum.Text.Remove(textBoxInputSum.Text.Length - 1);
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            var readLine = textBoxInputSum.Text;
            Log.Info(string.Format("User required sum {0}", readLine));

            decimal requestedSum;
            if (!decimal.TryParse(readLine, out requestedSum) || requestedSum <= decimal.Zero)
            {
                MessageBox.Show(_languagePack.WrongInput);
            }

            var money = _atm.WithdrawMoney(requestedSum);
            switch (_atm.CurrentState)
            {
                case AtmState.Ok:
                    {
                        Log.Info(string.Format("State:{1}: {0}", MoneyConverter.ConvertToString(money), _statesDictionary[_atm.CurrentState]));
                        listBoxMoney.Items.Clear();
                        foreach (var nominal in _atm.AllMoney.Banknotes)
                        {
                            listBoxMoney.Items.Add(string.Format("Banknote: {0} " + " Amount: {1}", nominal.Key.Nominal,
                                nominal.Value));
                        }
                        break;
                    }

                default:
                {
                    Log.Info(string.Format("State:{1}. User input {0}", readLine, _statesDictionary[_atm.CurrentState]));
                    MessageBox.Show(_statesDictionary[_atm.CurrentState]);
                    break;
                }
            }
        }

        private void buttonLoadCassettes_Click(object sender, EventArgs e)
        {
            listBoxMoney.Items.Clear();
            Log.Info("Start loading cassettes");
            string pathToMoney = "PathToMoney";

            string userInput = textBoxCassettes.Text.ToLower().Trim();
            string first = userInput[0].ToString().ToUpper();
            userInput = userInput.Remove(0, 1);
            userInput = userInput.Insert(0, first);
            bool isLoaded = true;

            try
            {
                _cassetteReader = ReadersCollection.CassetteReaders[userInput];
                pathToMoney += userInput;
                List<Cassette> cassettes = _cassetteReader.ReadCassettes(ConfigurationManager.AppSettings[pathToMoney]);
                _atm.InsertCassettes(cassettes);
                Log.Info(string.Format("Cassettes are loaded successfully from \"{0}\"", ConfigurationManager.AppSettings[pathToMoney]));
            }
            catch (KeyNotFoundException)
            {
                Log.Error("There is no such file with cassettes. Cassettes are not loaded");
                isLoaded = false;
            }
            if (isLoaded)
            {
                foreach (var nominal in _atm.AllMoney.Banknotes)
                {
                    listBoxMoney.Items.Add(string.Format("Banknote: {0}  " + "Amount: {1}", nominal.Key.Nominal, nominal.Value));
                }
            }
        }

        private void AtmMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.Info("Finish application " + e.CloseReason);
        }

        private void buttonDeleteCassettes_Click(object sender, EventArgs e)
        {
            _atm.DeleteCassettes();
            listBoxMoney.Items.Clear();
            Log.Info("Cassettes are deleted");
        }
    }
}
