using System;
using System.Threading;
using System.Globalization;

namespace Lab2
{
    class MonthsLanguages
    {
        static public string OutputMonthsLanguages(CultureInfo cultureInfo)
        {
            //CultureInfo lastCulture = Thread.CurrentThread.CurrentCulture;
            //CultureInfo lastUICulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            string ans = "";
            ans += String.Format("\t{0} \n", cultureInfo.EnglishName);
            for (int i = 0; i < 12; i++)
            {
                ans += String.Format("{0}: {1}\n", i + 1, DateTimeFormatInfo.CurrentInfo.MonthNames[i]);
            }
            //Thread.CurrentThread.CurrentCulture = lastCulture;
            //Thread.CurrentThread.CurrentUICulture = lastUICulture;
            return ans;
        }
        static public CultureInfo LanguageToCulture(string str)
        {
            str = str.Trim().ToLowerInvariant();
            if (str.Length < 2)
            {
                throw new Exception("Неверный язык");
            }
            if (str.Length > 2)
            {
                foreach (CultureInfo cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures))
                {
                    if (cultureInfo.EnglishName.ToLowerInvariant() == str)
                    {
                        str = cultureInfo.TwoLetterISOLanguageName;
                        break;
                    }
                }
            }
            CultureInfo cultureInfoNew = new CultureInfo(str);
            if (cultureInfoNew.EnglishName == "Unknown")
            {
                throw new Exception("Неверный язык");
            }
            return cultureInfoNew;
        }
    }
}
