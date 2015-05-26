using System.Collections.Generic;

namespace ATM.Reader
{
    public abstract class ReadersCollection
    {
        static public Dictionary<string, ICassetteReader<List<Cassette>>> CassetteReaders =
            new Dictionary<string, ICassetteReader<List<Cassette>>>
            {
                {"Xml", new XmlCassetteReader<List<Cassette>>()},
                {"Csv", new CsvCassetteReader()},
                {"Txt", new TxtCassetteReader()},
                {"Json", new JsonCassetteReader<List<Cassette>>()}
            };
    }
}
