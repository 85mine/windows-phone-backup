using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;
using Windows.System;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Reboot.Controls;
using Reboot.Resources;

namespace Reboot.Views
{
    public partial class Navigation : PhoneApplicationPage
    {
        private const string Key = "Shortcut";
        private string _value = String.Empty;

        public Navigation()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (NavigationContext.QueryString.TryGetValue(Key, out _value))
            {
                switch (_value)
                {
                    case ShortcutValue.Reboot:
                        if (MessageBox.Show(AppResources.TextRebootDetails, AppResources.TextReboot, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                        {
                            //Goodbye message
                            var goodbye = new Popup
                            {
                                Child = new UserControls.Goodbye(),
                                VerticalOffset = 0,
                                HorizontalOffset = 0,
                                IsOpen = true
                            };
                            SystemTray.IsVisible = false;
                            Launcher.LaunchUriAsync(new Uri("test:"));
                        }
                        else
                        {
                            Application.Current.Terminate();
                        }
                        break;
                }
            }
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            e.Cancel = true;
            Application.Current.Terminate();
        }
    }
}