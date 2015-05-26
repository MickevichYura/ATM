namespace ATM.Language
{
    public interface ILanguage
    {
        string WrongInput { get; set; }
        string NotEnoughMoney { get; set; }
        string TooManyBills { get; set; }
        string Exit { get; set; }
    }
}
