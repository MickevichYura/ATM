using System;
using System.IO;
using System.Runtime.Serialization;
using log4net;

namespace ATM.Reader
{
    public class XmlCassetteReader<T> : ICassetteReader<T>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(XmlCassetteReader<T>));

        public T LoadCassettes(string filename)
        {
            Stream stream = Stream.Null;
            T cassettes = default(T);
            Log.Info("Start loading cassettes");
            try
            {
                stream = new FileStream(filename, FileMode.Open);
                DataContractSerializer ds = new DataContractSerializer(typeof(T));
                cassettes = (T)ds.ReadObject(stream);
                Log.Info(string.Format("Cassettes are loaded from {0}", filename));
            }
            catch (Exception exception)
            {
                Log.Info(string.Format("Cassettes are not loaded from {0}\n{1}", filename, exception.Message));
            } 

            stream.Close();
            return cassettes;
        }
    }
}
