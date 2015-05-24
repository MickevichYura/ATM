namespace ATM.Writer
{
    public interface ICassetteWriter<in T>
    {
        void WriteCassettes(T data, string filename);
    }
}
