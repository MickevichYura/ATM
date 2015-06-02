using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;
using ATM.Language;
using ATM.Reader;

namespace AtmConsoleUI
{
    class CommandPerformer
    {
        private readonly CashMachine _atm;
        private readonly ILanguage _lang;

        public CommandPerformer(ref CashMachine atm, ref ILanguage lang)
        {
            _atm = atm;
            _lang = lang;
        }

        public bool TryPerform(string command)
        {
            if (command == "exit")
            {
                _atm.Exit();
                return true;
            }

            if (command.Split().First() == "insert")
            {
                var splitCommand = command.Split(' ');
                string pathToMoney = "PathToMoney";
                Console.WriteLine(splitCommand[1]);
                string extension = splitCommand[1];
                ICassetteReader<List<Cassette>> cassetteReader = ReadersCollection.GetReader(extension);
                if (cassetteReader != null)
                {
                    pathToMoney += extension;
                    List<Cassette> cassettes = cassetteReader.LoadCassettes(ConfigurationManager.AppSettings[pathToMoney]);
                    if (cassettes != null)
                    {
                        _atm.InsertCassettes(cassettes);
                    }
                }
                return true;
            }

            if (command == "delete")
            {
                _atm.DeleteCassettes();
                Console.WriteLine("\nСassettes have been successfully removed\n");
                return true;
            }

            if (command == "help")
            {
                Console.WriteLine('\n' + "allCommands" + '\n' +
                                  "help" + "                     " + "help" + '\n' +
                                  "exit" + "                     " + _lang.Exit + '\n' +
                                  "insert" + "                   " + _lang.InsertCassettes + '\n' +
                                  "delete" + "                   " + _lang.DeleteCassettes + '\n' +
                                  "clear" + "                    " + _lang.Clear + '\n'
                    );
                return true;
            }

            if (command == "clear")
            {
                Console.Clear();
                return true;
            }

            if (command == "clear")
            {
                Console.Clear();
                return true;
            }

            return false;
        }
    }
}
