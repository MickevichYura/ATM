using System;
using System.Collections.Generic;
using System.IO;
using log4net;

namespace ATM.Reader
{
    public class CsvCassetteReader : ICassetteReader<List<Cassette>>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CsvCassetteReader));

        public List<Cassette> LoadCassettes(string filename)
        {
            List<Cassette> list = new List<Cassette>();
            var stream = new StreamReader(new FileStream(filename, FileMode.Open));
            Log.Info("Start loading cassettes");

            try
            {
                stream.ReadLine();
                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var split = line.Split(',');
                    var number = int.Parse(split[0]);
                    var nominal =
                        int.Parse(
                            split[1].Remove(split[1].IndexOf("}", StringComparison.Ordinal))
                                .Substring(split[1].IndexOf(":", StringComparison.Ordinal) + 1));
                    list.Add(new Cassette(new Banknote(nominal), number));
                    Log.Info(string.Format("Cassettes are loaded from {0}", filename));
                }
            }
            catch (Exception exception)
            {
                Log.Info(string.Format("Cassettes are not loaded from {0}\n{1}", filename, exception.Message));
            } 

            stream.Close();
            return list;
        }
    }
}
