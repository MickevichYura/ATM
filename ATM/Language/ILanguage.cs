namespace ATM.Language
{
    public interface ILanguage
    {
        string Exit { get; set; }
        string NotEnoughMoney { get; set; }
        string WrongInput { get; set; }
        string TooManyBanknotes { get; set; }
        string ImpossibleToCollectMoney { get; set; }
        string Ok { get; set; }
    }
}
