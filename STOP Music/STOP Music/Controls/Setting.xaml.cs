using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using STOP_Music.Controller;

namespace STOP_Music
{
    public partial class Setting : UserControl
    {
        public Setting()
        {
            InitializeComponent();

            Width = Application.Current.Host.Content.ActualWidth;

            Height = Application.Current.Host.Content.ActualHeight;

            #region Load setting

            if (AppSetting.Settings.Contains(AppSetting.Autoclose))
            {
                autoclose_btn.IsChecked = bool.Parse(AppSetting.Settings[AppSetting.Autoclose].ToString());
            }

            #endregion
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SettingStoryboard.Begin();
        }

        private void autoclose_btn_Tap(object sender, GestureEventArgs e)
        {
            #region Save autoclose setting => isolated

            if (autoclose_btn.IsChecked)
            {
                AppSetting.Add(AppSetting.Autoclose, true);
            }
            else
            {
                AppSetting.Add(AppSetting.Autoclose, false);
            }

            #endregion
        }
    }
}