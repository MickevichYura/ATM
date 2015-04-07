using System.Collections.Generic;
using System.IO;

namespace ATM
{
    public static class CasseteReader
    {  
        public static List<Cassette> ReadCassete(string path)
        {
            var moneyCassettes = new List<Cassette>();

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) return moneyCassettes;
                    var casseteInfo = line.Split(' ');
                    moneyCassettes.Add(new Cassette(new Banknote(decimal.Parse(casseteInfo[0])),
                        int.Parse(casseteInfo[1])));
                }
            }
            return moneyCassettes;
        }
    }
}