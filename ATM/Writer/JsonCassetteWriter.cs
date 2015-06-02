using System.IO;
using System.Runtime.Serialization.Json;

namespace ATM.Writer
{
    public class JsonCassetteWriter<T> : ICassetteWriter<T>
    {
        public void WriteCassettes(T data, string fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.Create);
            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T));

            ds.WriteObject(stream, data);
            stream.Close();
        } 
    }
}