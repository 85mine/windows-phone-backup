using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Windows.Phone.Media.Capture;
using Windows.System;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Reboot.Resources;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace Reboot.Controls
{
    internal class Common
    {
        //Toast notification  ( update successed,...)
        private static readonly ToastPrompt Toast = new ToastPrompt();

        public static void Rating()
        {
            var reviewTask = new MarketplaceReviewTask();
            reviewTask.Show();
        }

        public static void CreateFlipTile(string uri, string contains, string smallBackgroundImage,
            string backgroundImage)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(contains));

            if (tile != null && tile.NavigationUri.ToString().Contains(contains))
            {
                var iconicTileData = new FlipTileData
                {
                    SmallBackgroundImage = new Uri(smallBackgroundImage, UriKind.RelativeOrAbsolute),
                    BackgroundImage = new Uri(backgroundImage, UriKind.RelativeOrAbsolute),
                };

                tile.Update(iconicTileData);
                Toast.Title = AppResources.TextNotice;
                Toast.Message = AppResources.TextSuccessfully;
                Toast.Show();
            }
            else
            {
                var tileUri = new Uri(uri + contains, UriKind.RelativeOrAbsolute);
                var tileData = new FlipTileData
                {
                    SmallBackgroundImage = new Uri(smallBackgroundImage, UriKind.RelativeOrAbsolute),
                    BackgroundImage = new Uri(backgroundImage, UriKind.RelativeOrAbsolute),
                };

                ShellTile.Create(tileUri, tileData, false);
            }
        }

        public static void CreateFlipTile(string uri, string contains, string smallBackgroundImage,
          string backgroundImage,string widebackgroundImage)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(contains));

            if (tile != null && tile.NavigationUri.ToString().Contains(contains))
            {
                var iconicTileData = new FlipTileData
                {
                    SmallBackgroundImage = new Uri(smallBackgroundImage, UriKind.RelativeOrAbsolute),
                    BackgroundImage = new Uri(backgroundImage, UriKind.RelativeOrAbsolute),
                    WideBackgroundImage = new Uri(widebackgroundImage,UriKind.RelativeOrAbsolute),
                    Title = AppResources.TextReboot
                };

                tile.Update(iconicTileData);
                Toast.Title = AppResources.TextNotice;
                Toast.Message = AppResources.TextSuccessfully;
                Toast.Show();
            }
            else
            {
                var tileUri = new Uri(uri + contains, UriKind.RelativeOrAbsolute);
                var tileData = new FlipTileData
                {
                    SmallBackgroundImage = new Uri(smallBackgroundImage, UriKind.RelativeOrAbsolute),
                    BackgroundImage = new Uri(backgroundImage, UriKind.RelativeOrAbsolute),
                    WideBackgroundImage = new Uri(widebackgroundImage, UriKind.RelativeOrAbsolute),
                    Title = AppResources.TextReboot
                };

                ShellTile.Create(tileUri, tileData, true);
            }
        }

        public static void GetMore(string publisher)
        {
            var getmore = new MarketplaceSearchTask();
            getmore.SearchTerms = publisher;
            getmore.ContentType = MarketplaceContentType.Applications;
            getmore.Show();
        }

        public static bool Reboot()
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
                Launcher.LaunchUriAsync(new Uri("test:"));
            }
            return false;
        }
    }
}