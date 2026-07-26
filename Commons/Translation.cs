using HarmonyLib;
using KMod;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Commons
{
    public class Translation_Patch
    {

        public static bool TryLoadTranslations(UserMod2 mod,out Dictionary<string, string> translations)
        {
            string path2 = "Translations";
            string mlocale = GetCurrentLanguageCode();
            if (string.IsNullOrEmpty(mlocale))
            {
                mlocale = "en";
            }
            string path3 = Path.Combine(mod.path, path2, mlocale + ".po");
            if (File.Exists(path3))
            {
                translations = Localization.LoadStringsFile(path3, false);
                Localization.OverloadStrings(translations);

                Debug.LogFormat("[{0}] 翻译加载成功: {1}",mod.mod.title , translations.Count);
                return true;
            }
            else
            {
                Debug.LogFormat("[{0}] No translation is loaded and the default language is used", mod.mod.title);
            }

            translations = null;
            return false;
        }


        public static string GetCurrentLanguageCode()
        {
            switch (Localization.GetSelectedLanguageType())
            {
                case Localization.SelectedLanguageType.None:
                    return Localization.DEFAULT_LANGUAGE_CODE;
                case Localization.SelectedLanguageType.Preinstalled:
                    string mlocale =  KPlayerPrefs.GetString(Localization.SELECTED_LANGUAGE_CODE_KEY);
                    if (GetLocaleForCode == null)
                    {
                        Debug.LogError("[Translations] Warring: GetLocaleForCode method not found!");
                        return mlocale.Replace("_klei","");
                    }
                    Localization.Locale locale = GetLocaleForCode.GetValue<Localization.Locale>(new object[] { mlocale });
                    return locale.Code;
                case Localization.SelectedLanguageType.UGC:
                    return LanguageOptionsScreen.GetInstalledLanguageCode();
                default:
                    return "";
            }
        }

        private static readonly Type Loc = typeof(Localization);
       private static readonly Traverse GetLocaleForCode = Traverse.Create(typeof(Localization)).Method("GetLocaleForCode", new Type[] { typeof(string) }); 
    }
}
