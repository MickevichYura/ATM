using System.IO;
using System.Runtime.Serialization;

namespace ATM.Writer
{
    public class XmlCassetteWriter<T> : ICassetteWriter<T>
    {
        public void WriteCassettes(T data, string filename)
        {
            Stream stream = new FileStream(filename, FileMode.OpenOrCreate);
            DataContractSerializer ds = new DataContractSerializer(typeof (T), new DataContractSerializerSettings());

            ds.WriteObject(stream, data);
            stream.Close();
        }
    }
}
