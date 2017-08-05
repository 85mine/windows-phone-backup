using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using STOP_Music.Controller;
using STOP_Music.Controls;
using STOP_Music.Resources;

namespace STOP_Music.Views
{
    public partial class Tutorial : PhoneApplicationPage
    {
        private readonly Hello _hello = new Hello();

        public Tutorial()
        {
            InitializeComponent();
            _hello.EventForPageNavigation += hello_EventForPageNavigation;
        }

        private void hello_EventForPageNavigation(object sender, EventArgs e)
        {
            NavigationService.Navigate(((NavigationEventArgs) e).Uri);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (AppSetting.IsShowTutorial())
            {
                LayoutRoot.Children.Add(_hello);
            }
            else
            {
                NavigationService.Navigate(new Uri(AppResources.ViewMain, UriKind.RelativeOrAbsolute));
            }
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}