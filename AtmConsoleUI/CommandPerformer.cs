using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ATM;
using ATM.Language;
using ATM.Reader;

namespace AtmConsoleUI
{
    internal class CommandPerformer
    {
        private readonly Dictionary<string, Action> _commandsDictionary;
        private readonly CashMachine _atm;
        private readonly ILanguage _lang;
        private bool _result;
        private string _secondParam;

        public CommandPerformer(ref CashMachine atm, ref ILanguage lang)
        {
            _atm = atm;
            _lang = lang;

            _commandsDictionary = new Dictionary<string, Action>
            {
                {"help", Help},
                {"insert", InsertCassettes},
                {"exit", Exit},
                {"delete", DeleteCassettes},
                {"clear", Clear}
            };
        }

        public bool TryPerform(string command)
        {
            _result = false;
            var split = command.Split(' ');
            if (split.Count() > 2)
            {
                return false;
            }
            if (split.Count() == 2)
            {
                _secondParam = split[1];
            }
            command = split[0].ToLower();
            if (_commandsDictionary.ContainsKey(command))
            {
                _commandsDictionary[command].Invoke();
            }

            return _result;
        }

        private void Clear()
        {
            Console.Clear();
            _result = true;
        }

        private void Help()
        {
            Console.WriteLine('\n' +
                              "help" + "\t" + _lang.Help + '\n' +
                              "exit" + "\t" + _lang.Exit + '\n' +
                              "insert" + "\t" + _lang.InsertCassettes + '\n' +
                              "delete" + "\t" + _lang.DeleteCassettes + '\n' +
                              "clear" + "\t" + _lang.Clear + '\n'
                );

            _result = true;
        }

        private void InsertCassettes()
        {
            string pathToMoney = "PathToMoney";
            string extension = _secondParam;
            ICassetteReader<List<Cassette>> cassetteReader = ReadersCollection.GetReader(extension);
            if (cassetteReader != null)
            {
                pathToMoney += extension;
                List<Cassette> cassettes =
                    cassetteReader.LoadCassettes(ConfigurationManager.AppSettings[pathToMoney]);
                if (cassettes != null)
                {
                    _atm.InsertCassettes(cassettes);
                }
            }
            _result = true;
        }

        private void DeleteCassettes()
        {
            _atm.DeleteCassettes();
            _result = true;
        }

        private void Exit()
        {
            _atm.Exit();
            _result = true;
        }
    }
}
