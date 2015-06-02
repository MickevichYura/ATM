namespace ATM.Reader
{
    public interface ICassetteReader<out T>
    {
        T LoadCassettes(string filename);
    }
}
