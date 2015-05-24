using System;
using System.Collections.Generic;
using System.IO;

namespace ATM.Reader
{
    public class CsvCassetteReader : ICassetteReader<List<Cassette>>
    {
        public List<Cassette> ReadCassettes(string fileName)
        {
            List<Cassette> list = new List<Cassette>();
            var stream = new StreamReader(new FileStream(fileName, FileMode.Open));

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
            }
            stream.Close();
            return list;
        }
    }
}
