using System.Collections.Generic;
using log4net;

namespace ATM.Reader
{
    public abstract class ReadersCollection
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ReadersCollection));

        static public Dictionary<string, ICassetteReader<List<Cassette>>> CassetteReaders =
            new Dictionary<string, ICassetteReader<List<Cassette>>>
            {
                {"Xml", new XmlCassetteReader<List<Cassette>>()},
                {"Csv", new CsvCassetteReader()},
                {"Txt", new TxtCassetteReader()},
                {"Json", new JsonCassetteReader<List<Cassette>>()}
            };


        public static ICassetteReader<List<Cassette>> GetReader(string extension)
        {
            ICassetteReader<List<Cassette>> cassetteReader = null;
            try
            {
                cassetteReader = CassetteReaders[extension];
            }
            catch (KeyNotFoundException)
            {
                Log.Error(string.Format("There is no such reader for this extension {0}", extension));
            }

            return cassetteReader;
        }
    }
}
