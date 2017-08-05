using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Xna.Framework.Media;
using STOP_Music.Controller;
using STOP_Music.Resources;

namespace STOP_Music.Controls
{
    public partial class Hello : UserControl
    {
        public Hello()
        {
            InitializeComponent();

            Width = Application.Current.Host.Content.ActualWidth;

            Height = Application.Current.Host.Content.ActualHeight;

            HelloStoryboard.Completed += HelloStoryboard_Completed;
        }

        public event EventHandler EventForPageNavigation;

        private void HelloStoryboard_Completed(object sender, EventArgs e)
        {
            AppSetting.Add(AppSetting.Tutorial, true);
            MediaPlayer.Stop();
            MethodToNavigateToPage(new Uri(AppResources.ViewMain, UriKind.Relative));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Controller.Controls.PlayMedia(AppResources.MusicQueHuongVietNam);
            HelloStoryboard.Begin();
        }

        public void MethodToNavigateToPage(Uri uri)
        {
            var e = new NavigationEventArgs(null, uri);
            if (EventForPageNavigation != null)
                EventForPageNavigation(this, e);
        }

        private void skip_Tap(object sender, GestureEventArgs e)
        {
            AppSetting.Add(AppSetting.Tutorial, true);
            MediaPlayer.Stop();
            MethodToNavigateToPage(new Uri(AppResources.ViewMain, UriKind.Relative));
        }
    }
}