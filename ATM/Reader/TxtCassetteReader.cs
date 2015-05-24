using System.Collections.Generic;
using System.IO;

namespace ATM.Reader
{
    public class TxtCassetteReader : ICassetteReader<List<Cassette>>
    {
        public List<Cassette> ReadCassettes(string path)
        {
            var moneyCassettes = new List<Cassette>();

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) return moneyCassettes;
                    var cassetteInfo = line.Split(' ');
                    moneyCassettes.Add(new Cassette(new Banknote(decimal.Parse(cassetteInfo[0])),
                        int.Parse(cassetteInfo[1])));
                }
            }
            return moneyCassettes;
        }
    }
}
