using System.IO;
using ServiceStack.Text;

namespace ATM.Writer
{
    public class CsvCassetteWriter<T> : ICassetteWriter<T>
    {
        public void WriteCassettes(T data, string fileName)
        {
            CsvSerializer.SerializeToStream(data, new FileStream(fileName, FileMode.OpenOrCreate));
        }
    }
}
