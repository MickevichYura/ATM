using System.IO;
using System.Runtime.Serialization;

namespace ATM.Reader
{
    public class XmlCassetteReader<T> : ICassetteReader<T>
    {
        public T LoadCassettes(string filename)
        {
            Stream stream = new FileStream(filename, FileMode.Open);
            DataContractSerializer ds = new DataContractSerializer(typeof(T));
            T cassettes = (T) ds.ReadObject(stream);
            stream.Close();
            return cassettes;
        }
    }
}
