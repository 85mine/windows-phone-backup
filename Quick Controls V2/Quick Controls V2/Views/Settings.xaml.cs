using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Quick_Controls_V2.Controls;
using Quick_Controls_V2.Resources;

namespace Quick_Controls_V2.Views
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();

            #region Load setting

            if (AppSetting.Settings.Contains(AppSetting.Autoclose))
            {
                AutoCloseMode.IsChecked = bool.Parse(AppSetting.Settings[AppSetting.Autoclose].ToString());
            }

            if (AppSetting.Settings.Contains(AppSetting.Flashlight))
            {
                FlashLightMode.IsChecked = bool.Parse(AppSetting.Settings[AppSetting.Flashlight].ToString());
            }

            #endregion
        }

        private void FlashLightMode_Tap(object sender, GestureEventArgs e)
        {
            #region Save flashlight setting => isolated

            if (FlashLightMode.IsChecked)
            {
                AppSetting.Add(AppSetting.Flashlight, true);
            }
            else
            {
                AppSetting.Add(AppSetting.Flashlight, false);
            }

            #endregion
        }

        private void AutoCloseMode_Tap(object sender, GestureEventArgs e)
        {
            #region Save autoclose setting => isolated

            if (AutoCloseMode.IsChecked)
            {
                AppSetting.Add(AppSetting.Autoclose, true);
            }
            else
            {
                AppSetting.Add(AppSetting.Autoclose, false);
            }

            #endregion
        }

        private void PinVolume_Click(object sender, RoutedEventArgs e)
        {
            Common.PinVolume();
        }
    }
}