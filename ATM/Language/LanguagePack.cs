using System.Globalization;
using System.Reflection;
using System.Resources;

namespace ATM.Language
{
    public class LanguagePack : ILanguage
    {
        public string WrongInput { get; set; }
        public string NotEnoughMoney { get; set; }
        public string TooManyBills { get; set; }
        public string Exit { get; set; }

        public LanguagePack(string cultureInfo)
        {
            Assembly loadResources = Assembly.Load("ATM");
            ResourceManager rm = new ResourceManager("ATM.Language.Lang", loadResources);
            CultureInfo ci = new CultureInfo(cultureInfo);

            WrongInput = rm.GetString("WrongInput", ci);
            NotEnoughMoney = rm.GetString("NotEnoughMoney", ci);
            TooManyBills = rm.GetString("TooManyBills", ci);
            Exit = rm.GetString("Exit", ci);
        }
    }
}