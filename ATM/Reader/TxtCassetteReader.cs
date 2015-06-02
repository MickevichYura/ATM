using System;
using System.Collections.Generic;
using System.IO;
using log4net;

namespace ATM.Reader
{
    public class TxtCassetteReader : ICassetteReader<List<Cassette>>
    {
        private static readonly
            ILog Log = LogManager.GetLogger(typeof (TxtCassetteReader));

        public List<Cassette> LoadCassettes(string filename)
        {
            var moneyCassettes = new List<Cassette>();

            try
            {
                using (var reader = new StreamReader(filename))
                {
                    Log.Info(string.Format("Start loading cassettes  from {0}", filename));
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) return moneyCassettes;
                        var cassetteInfo = line.Split(' ');
                        moneyCassettes.Add(new Cassette(new Banknote(decimal.Parse(cassetteInfo[0])),
                            int.Parse(cassetteInfo[1])));
                        Log.Info(string.Format("Cassettes are loaded from {0}", filename));
                    }
                }

            }
            catch (Exception exception)
            {
                Log.Info(string.Format("Cassettes are not loaded from {0}\n{1}", filename, exception.Message));
            }

            return moneyCassettes;
        }
    }
}
