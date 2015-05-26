using System.Collections.Generic;

namespace ATM.Writer
{
    public abstract class WritersCollection
    {
        static public Dictionary<string, ICassetteWriter<List<Cassette>>> CassetteWriters =
            new Dictionary<string, ICassetteWriter<List<Cassette>>>
            {
                {"Xml", new XmlCassetteWriter<List<Cassette>>()},
                {"Csv", new CsvCassetteWriter<List<Cassette>>()},
                {"Txt", new TxtCassetteWriter()},
                {"Json", new JsonCassetteWriter<List<Cassette>>()}
            };
    }
}
