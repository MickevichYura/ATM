using System.Globalization;
using System.Reflection;
using System.Resources;

namespace ATM.Language
{
    public class LanguagePack : ILanguage
    {
        public string Exit { get; set; }
        public string NotEnoughMoney { get; set; }
        public string WrongInput { get; set; }
        public string TooManyBanknotes { get; set; }
        public string ImpossibleToCollectMoney { get; set; }
        public string Ok { get; set; }

        public LanguagePack(string cultureInfo)
        {
            Assembly loadResources = Assembly.Load("ATM");
            ResourceManager resourceManager = new ResourceManager("ATM.Language.Lang", loadResources);
            CultureInfo culture = new CultureInfo(cultureInfo);

            Exit = resourceManager.GetString("Exit", culture);
            NotEnoughMoney = resourceManager.GetString("NotEnoughMoney", culture);
            WrongInput = resourceManager.GetString("WrongInput", culture);
            TooManyBanknotes = resourceManager.GetString("TooManyBanknotes", culture);
            ImpossibleToCollectMoney = resourceManager.GetString("ImpossibleToCollectMoney", culture);
            Ok = resourceManager.GetString("Ok", culture);
        }
    }
}