using System.IO;
using System.Runtime.Serialization.Json;
using log4net;

namespace ATM.Reader
{
    public class JsonCassetteReader<T> : ICassetteReader<T>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(JsonCassetteReader<T>));

        public T LoadCassettes(string filename)
        {
            Stream stream = new FileStream(filename, FileMode.Open);
            var ds = new DataContractJsonSerializer(typeof(T));
            T cassettes = (T)ds.ReadObject(stream);
            stream.Close();
            return cassettes;
        } 
    }
}
