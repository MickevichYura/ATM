using System.IO;
using System.Runtime.Serialization.Json;

namespace ATM.Reader
{
    public class JsonCassetteReader<T> : ICassetteReader<T>
    {
        public T ReadCassettes(string fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.Open);
            var ds = new DataContractJsonSerializer(typeof(T));
            T cassettes = (T)ds.ReadObject(stream);
            stream.Close();
            return cassettes;
        } 
    }
}