using System.Globalization;
using System.Reflection;
using System.Resources;

namespace ATM.Language
{
    public class LanguagePack : ILanguage
    {

        public string Exit { get; set; }
        public string ImpossibleToCollectMoney { get; set; }
        public string NotEnoughMoney { get; set; }
        public string Ok { get; set; }
        public string TooManyBanknotes { get; set; }
        public string WrongInput { get; set; }
        public string InsertCassettes { get; set; }
        public string DeleteCassettes { get; set; }
        public string Cancel { get; set; }
        public string Clear { get; set; }
        public string Enter { get; set; }

        public LanguagePack(string cultureInfo)
        {
            Assembly loadResources = Assembly.Load("ATM");
            ResourceManager resourceManager = new ResourceManager("ATM.Language.Lang", loadResources);
            CultureInfo culture = new CultureInfo(cultureInfo);

            Exit = resourceManager.GetString("Exit", culture);
            ImpossibleToCollectMoney = resourceManager.GetString("ImpossibleToCollectMoney", culture);
            NotEnoughMoney = resourceManager.GetString("NotEnoughMoney", culture);
            Ok = resourceManager.GetString("Ok", culture);
            TooManyBanknotes = resourceManager.GetString("TooManyBanknotes", culture);
            WrongInput = resourceManager.GetString("WrongInput", culture);
            InsertCassettes = resourceManager.GetString("InsertCassettes", culture);
            DeleteCassettes = resourceManager.GetString("DeleteCassettes", culture);
            Cancel = resourceManager.GetString("Cancel", culture);
            Clear = resourceManager.GetString("Clear", culture);
            Enter = resourceManager.GetString("Enter", culture);
        }

    }
}