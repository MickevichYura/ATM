namespace ATM.Language
{
    public interface ILanguage
    {
        string Exit { get; set; }
        string ImpossibleToCollectMoney { get; set; }
        string NotEnoughMoney { get; set; }
        string Ok { get; set; }
        string TooManyBanknotes { get; set; }
        string WrongInput { get; set; }
        string InsertCassettes { get; set; }
        string DeleteCassettes { get; set; }
        string Cancel { get; set; }
        string Clear { get; set; }
        string Enter { get; set; }
        string Help { get; set; }
    }
}
