using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Threading;
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
            comboBoxExtension.DataSource = (new[]
            {
                "Json",
                "Xml",
                "Txt",
                "Csv"
            });

            _languagePack = new LanguagePack(CultureInfo.CurrentCulture.Name);
            LoadLang();
        }

        private static readonly ILog Log = LogManager.GetLogger(typeof (AtmMainForm));
        private Dictionary<AtmState, string> _statesDictionary;

        private CashMachine _atm;
        private ILanguage _languagePack;
        private ICassetteReader<List<Cassette>> _cassetteReader;

        private void LoadLang()
        {
            _statesDictionary = new Dictionary<AtmState, string>
            {
                {AtmState.Ok, _languagePack.Ok},
                {AtmState.NotEnoughMoney, _languagePack.NotEnoughMoney},
                {AtmState.ImpossibleToCollectMoney, _languagePack.ImpossibleToCollectMoney},
                {AtmState.TooManyBanknotes, _languagePack.TooManyBanknotes}
            };

            buttonInsertCassettes.Text = _languagePack.InsertCassettes;
            buttonDeleteCassettes.Text = _languagePack.DeleteCassettes;
            buttonCancel.Text = _languagePack.Cancel;
            buttonClear.Text = _languagePack.Clear;
            buttonEnter.Text = _languagePack.Enter;

        }

        private void DisplayMoney()
        {
            listBoxMoney.Items.Clear();
            foreach (var nominal in _atm.AllMoney.Banknotes)
            {
                listBoxMoney.Items.Add(string.Format("Banknote: {0}  " + "Amount: {1}", nominal.Key.Nominal,
                    nominal.Value));
            }
        }

        private void AtmMainForm_Load(object sender, EventArgs e)
        {
            Log.Debug("Start application");
            _atm = CashMachine.Deserialize(ConfigurationManager.AppSettings["SerializationFile"]) ?? new CashMachine();
            DisplayMoney();
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
                    DisplayMoney();
                    //MoneyConverter.ConvertToString(issuedMoney)
                    //MessageBox.Show(money.ToString());
                    break;
                }

                default:
                {
                    MessageBox.Show(_statesDictionary[_atm.CurrentState]);
                    break;
                }
            }
        }

        private void buttonInsertCassettes_Click(object sender, EventArgs e)
        {
            listBoxMoney.Items.Clear();
            string pathToMoney = "PathToMoney";
            string extension = comboBoxExtension.Text;

            _cassetteReader = ReadersCollection.GetReader(extension);
            if (_cassetteReader != null)
            {
                pathToMoney += extension;
                List<Cassette> cassettes = _cassetteReader.LoadCassettes(ConfigurationManager.AppSettings[pathToMoney]);
                if (cassettes != null)
                {
                    _atm.InsertCassettes(cassettes);
                }
                DisplayMoney();
            }
        }

        private void buttonDeleteCassettes_Click(object sender, EventArgs e)
        {
            _atm.DeleteCassettes();
            listBoxMoney.Items.Clear();
        }

        private void AtmMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.Info("Finish application " + e.CloseReason);
        }

        private void buttonLang_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Text != Thread.CurrentThread.CurrentCulture.Name)
            {
                string cultureInfo = button.Text;
                _languagePack = new LanguagePack(cultureInfo);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureInfo);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureInfo);
                LoadLang();
                Log.Info(string.Format("Culture changed to {0}", Thread.CurrentThread.CurrentCulture));
            }
        }

        private void AtmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _atm.Serialize(ConfigurationManager.AppSettings["SerializationFile"]);
        }
    }
}
