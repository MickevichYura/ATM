using System.IO;
using System.Runtime.Serialization;

namespace ATM.Reader
{
    public class XmlCassetteReader<T> : ICassetteReader<T>
    {
        public T ReadCassettes(string fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.Open);
            DataContractSerializer ds = new DataContractSerializer(typeof(T));
            T cassettes = (T) ds.ReadObject(stream);
            stream.Close();
            return cassettes;
        }
    }
}
