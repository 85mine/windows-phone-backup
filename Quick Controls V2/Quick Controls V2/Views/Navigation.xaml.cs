using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Quick_Controls_V2.Controls;
using Quick_Controls_V2.Resources;

namespace Quick_Controls_V2.Views
{
    public partial class Navigation : PhoneApplicationPage
    {
        private const string Key = "Shortcut";
        private string _value = String.Empty;

        public Navigation()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.TryGetValue(Key, out _value))
            {
                switch (_value)
                {
                    case ShortcutValue.Wifi:
                        Controls.Navigation.Wifi();
                        break;
                    case ShortcutValue.Cellular:
                        Controls.Navigation.Cellular();
                        break;
                    case ShortcutValue.Bluetooth:
                        Controls.Navigation.Bluetooth();
                        break;
                    case ShortcutValue.Location:
                        Controls.Navigation.Location();
                        break;
                    case ShortcutValue.Airplane:
                        Controls.Navigation.Airplane();
                        break;
                    case ShortcutValue.Accounts:
                        Controls.Navigation.Accounts();
                        break;
                    case ShortcutValue.LockScreen:
                        Controls.Navigation.LockScreen();
                        break;
                    case ShortcutValue.Rotation:
                        Controls.Navigation.Rotation();
                        break;
                    case ShortcutValue.Previous:
                        MusicControls.Back();
                        break;
                    case ShortcutValue.Play:
                        MusicControls.Play();
                        break;
                    case ShortcutValue.Pause:
                        MusicControls.Pause();
                        break;
                    case ShortcutValue.Next:
                        MusicControls.Next();
                        break;
                    case ShortcutValue.Mute:
                        Common.Mute();
                        break;
                    case ShortcutValue.Battery:
                        Controls.Navigation.BatterySaver();
                        break;
                    case ShortcutValue.LockPhone:
                        Common.LockPhone();
                        break;
                    case ShortcutValue.StopMusic:
                        MusicControls.Stop(AppResources.Quickstop);
                        break;
                }
                Application.Current.Terminate();
            }
        }
    }
}