using System.IO.IsolatedStorage;

namespace Quick_Controls_V2.Controls
{
    internal class AppSetting
    {
        //Variable
        public const string Autoclose = "autoclose";
        public const string Flashlight = "flashlight";
        public const string Tutorial = "tutorial";

        //Setting
        public static IsolatedStorageSettings Settings = IsolatedStorageSettings.ApplicationSettings;

        public static void Add(string contain, bool key)
        {
            //Remove if exist
            if (Settings.Contains(contain))
            {
                Settings.Remove(contain);
            }

            //Add to setting
            Settings.Add(contain, key);

            Settings.Save();
        }

        public static void Remove(string contain)
        {
            //Remove if exist
            if (Settings.Contains(contain))
            {
                Settings.Remove(contain);
            }
        }

        public static bool IsShowTutorial()
        {
            if (!Settings.Contains(Tutorial))
            {
                return true;
            }

            return false;
        }
    }
}