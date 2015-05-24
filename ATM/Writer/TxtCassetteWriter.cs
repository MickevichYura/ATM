using System.Collections.Generic;
using System.IO;

namespace ATM.Writer
{
    public class TxtCassetteWriter : ICassetteWriter<List<Cassette>>
    {
        public void WriteCassettes(List<Cassette> data, string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                foreach (Cassette cassette in data)
                {
                    writer.WriteLine("{0} {1}", cassette.Banknote.Nominal, cassette.Number);
                }
            }
        }
    }
}
