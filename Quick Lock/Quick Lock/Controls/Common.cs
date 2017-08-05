using System;
using System.Linq;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Quick_Lock.Resources;
using WP8SystemTime;

namespace Quick_Lock.Controls
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

        public static void LockPhone()
        {
            new WPRequestScreenClosed().RequestLockScreen();
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


        public static void GetMore(string publisher)
        {
            var getmore = new MarketplaceSearchTask
            {
                SearchTerms = publisher,
                ContentType = MarketplaceContentType.Applications
            };
            getmore.Show();
        }
    }
}