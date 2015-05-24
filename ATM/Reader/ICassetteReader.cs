namespace ATM.Reader
{
    public interface ICassetteReader<out T>
    {
        T ReadCassettes(string filename);
    }
}
