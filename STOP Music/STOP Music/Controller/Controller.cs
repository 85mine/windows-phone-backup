using System;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using STOP_Music.Model;
using STOP_Music.Resources;

namespace STOP_Music.Controller
{
    internal class Controls
    {
        //Toast notification  ( update successed,...)
        private static readonly ToastPrompt Toast = new ToastPrompt
        {
            ImageSource = new BitmapImage(new Uri(AppResources.ImageNotice, UriKind.RelativeOrAbsolute))
        };

        public static string TimeSelectorToString(TimeSpanPicker timeselector)
        {
            string result = timeselector.ValueString.Substring(0, 2) +
                            timeselector.ValueString.Substring(3, 2) +
                            timeselector.ValueString.Substring(6, 2);
            return result;
        }

        public static void FlipTilesAsync(string timerInput)
        {
            try
            {
                FlipTile flipTile = CreateTiles.CreateImage(timerInput);

                CreateFlipTile(AppResources.ViewTimerExtend, timerInput,
                    flipTile.SmallBackgroundImage,
                    flipTile.BackgroundImage,
                    flipTile.WideBackgroundImage,
                    true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void CreateFlipTile(string uri, string contains, string smallBackgroundImage
            , string backgroundImage,
            string wideBackgroundImage,
            bool supportsWideTile)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(contains));

            if (tile != null && tile.NavigationUri.ToString().Contains(contains))
            {
                var fliptile = new FlipTileData
                {
                    SmallBackgroundImage = new Uri(smallBackgroundImage, UriKind.RelativeOrAbsolute),
                    BackgroundImage = new Uri(backgroundImage, UriKind.RelativeOrAbsolute)
                };
                if (supportsWideTile)
                {
                    fliptile.WideBackgroundImage = new Uri(wideBackgroundImage, UriKind.RelativeOrAbsolute);
                }
                tile.Update(fliptile);
                Toast.Title = AppResources.Notice;
                Toast.Message = AppResources.TextSuccessfully;
                Toast.Show();
            }
            else
            {
                var tileUri = new Uri(uri + contains, UriKind.RelativeOrAbsolute);
                var tileData = new FlipTileData
                {
                    SmallBackgroundImage = new Uri(smallBackgroundImage, UriKind.RelativeOrAbsolute),
                    BackgroundImage = new Uri(backgroundImage, UriKind.RelativeOrAbsolute)
                };

                if (supportsWideTile)
                {
                    tileData.WideBackgroundImage = new Uri(wideBackgroundImage, UriKind.RelativeOrAbsolute);
                }

                ShellTile.Create(tileUri, tileData, supportsWideTile);
                DataHelper.AddTimer(new Timer {ID = contains});
            }
        }

        public static void CreateFlipTile(string uri, string contains, string smallBackgroundImage
            , string backgroundImage,
            string wideBackgroundImage,
            bool supportsWideTile, string title)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(contains));

            if (tile != null && tile.NavigationUri.ToString().Contains(contains))
            {
                var fliptile = new FlipTileData
                {
                    SmallBackgroundImage = new Uri(smallBackgroundImage, UriKind.RelativeOrAbsolute),
                    BackgroundImage = new Uri(backgroundImage, UriKind.RelativeOrAbsolute),
                    Title = title
                };
                if (supportsWideTile)
                {
                    fliptile.WideBackgroundImage = new Uri(wideBackgroundImage, UriKind.RelativeOrAbsolute);
                }
                tile.Update(fliptile);
                Toast.Title = AppResources.Notice;
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
                    Title = title
                };

                if (supportsWideTile)
                {
                    tileData.WideBackgroundImage = new Uri(wideBackgroundImage, UriKind.RelativeOrAbsolute);
                }

                ShellTile.Create(tileUri, tileData, supportsWideTile);
            }
        }

        public static void GetMore()
        {
            MarketplaceSearchTask getmore = new MarketplaceSearchTask();
            getmore.SearchTerms = "Inception Inc.";
            getmore.ContentType = MarketplaceContentType.Applications;
            getmore.Show();    
        }

        public static void Ratting()
        {
            var reviewTask = new MarketplaceReviewTask();
            reviewTask.Show();
        }

        public static void DeleteFilesFromIsolatedStorage()
        {
            using (IsolatedStorageFile isolatedFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                try
                {
                    foreach (Timer timer in DataHelper.GetTimers())
                    {
                        ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(
                            x => x.NavigationUri.ToString().Contains(timer.ID));
                        if (tile == null)
                        {
                            isolatedFile.DeleteFile("/Shared/ShellContent/" + timer.ID + "S.png");
                            isolatedFile.DeleteFile("/Shared/ShellContent/" + timer.ID + "M.png");
                            isolatedFile.DeleteFile("/Shared/ShellContent/" + timer.ID + "W.png");
                            DataHelper.DeleteTimer(timer);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void PlayMedia(string media)
        {
            try
            {
                FrameworkDispatcher.Update();
                Song track = Song.FromUri("😛", new Uri(media, UriKind.RelativeOrAbsolute));
                MediaPlayer.Play(track);
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Error, please try again :(" + ex.Message);
            }
        }

        public static void ShowUserControl(UserControl userControl)
        {

        }
    }
}