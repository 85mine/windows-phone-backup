using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Windows.System;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Reboot.Controls;
using Reboot.Resources;

namespace Reboot.Views
{
    public partial class Main : PhoneApplicationPage
    {
        public Main()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
            //Shows the rate reminder message, according to the settings of the RateReminder.
            (App.Current as App).rateReminder.Notify();
        }

        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar { BackgroundColor = Color.FromArgb(255, 219, 60, 0), Opacity = 99 };

            // Create a new button and set the text value to the localized string from AppResources.
            var likeButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/Like.png", UriKind.Relative))
            {
                Text = AppResources.TextRating
            };
            var moreButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/More.png", UriKind.Relative))
            {
                Text = AppResources.TextMore
            };
            var pinButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/Pin.png", UriKind.Relative))
            {
                Text = AppResources.TextPin
            };

            ApplicationBar.Buttons.Add(pinButton);
            ApplicationBar.Buttons.Add(moreButton);
            ApplicationBar.Buttons.Add(likeButton);

            likeButton.Click += likeButton_Click;
            moreButton.Click+=moreButton_Click;
            pinButton.Click+=pinButton_Click;

        }

        void likeButton_Click(object sender, EventArgs e)
        {
            Common.Rating();
        }
        void moreButton_Click(object sender, EventArgs e)
        {
            Common.GetMore(AppResources.TextPublisher);
        }
        void pinButton_Click(object sender, EventArgs e)
        {
            Tiles.PinShortcut(Tiles.Reboot);
        }
        private void Reboot_Click(object sender, System.Windows.RoutedEventArgs e)
        {
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
                ApplicationBar.IsVisible = false;
                Launcher.LaunchUriAsync(new Uri("test:"));
            }
            else
            {
                ApplicationBar.IsVisible = true;
            }
        }
    }
}