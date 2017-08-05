using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Adjust_Volume.Resources;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using WP8SystemTime;

namespace Adjust_Volume.Controller
{
    class Common
    {
                //Toast notification  ( update successed,...)
        private static readonly ToastPrompt Toast = new ToastPrompt();

        public static void Rating()
        {
            var reviewTask = new MarketplaceReviewTask();
            reviewTask.Show();
        }

        public static void Mute()
        {
            new WPChangeSystemVolume().SubVolume(30);
        }

        public static void AddVolume(uint value)
        {
            new WPChangeSystemVolume().AddVolume(value);
        }

        public static void SubVolume(uint value)
        {
            new WPChangeSystemVolume().SubVolume(value);
        }

        public static void SetVolume(uint value)
        {
            new WPChangeSystemVolume().SubVolume(30);
            new WPChangeSystemVolume().AddVolume(value); 
        }

        public static void SetVolume(uint value,Slider volumeslider,TextBlock volume)
        {
            new WPChangeSystemVolume().SubVolume(30);
            new WPChangeSystemVolume().AddVolume(value);
            volumeslider.Value = value;
            volume.Text = value + "/30";
        }

        public static void MaxVolume()
        {
            new WPChangeSystemVolume().AddVolume(30);
        }
      
        public static void CreateIconicTile(string uri, string contains, string smallIconImage, string iconImage, int count)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(contains));

            if (tile != null && tile.NavigationUri.ToString().Contains(contains))
            {
                var iconicTileData = new IconicTileData
                {
                    SmallIconImage = new Uri(smallIconImage,UriKind.RelativeOrAbsolute),
                    IconImage = new Uri(smallIconImage, UriKind.RelativeOrAbsolute),
                    Count = count
                };

                tile.Update(iconicTileData);
                Toast.Title = AppResources.Notice;
                Toast.Message = AppResources.TextSuccessfully;
                Toast.Show();
            }
            else
            {
                var tileUri = new Uri(uri + contains, UriKind.RelativeOrAbsolute);
                var tileData = new IconicTileData
                {
                    SmallIconImage = new Uri(smallIconImage, UriKind.RelativeOrAbsolute),
                    IconImage = new Uri(smallIconImage, UriKind.RelativeOrAbsolute),
                    Count = count
                };

                ShellTile.Create(tileUri, tileData,false);
            }
        }

        public static void CreateFlipTile(string uri, string contains, string  smallBackgroundImage, string backgroundImage)
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
                };

                ShellTile.Create(tileUri, tileData, false);
            }
        }

        public static void PinVolume()
        {
            var input = new InputPrompt
            {
                Title = AppResources.InputPromptHeader,
                Message = AppResources.InputPromptTitle,
                MessageTextWrapping = TextWrapping.Wrap,
                InputScope = new InputScope {Names = {new InputScopeName() {NameValue = InputScopeNameValue.Number}}}
            };

            input.Completed += (s1, e1) =>
            {
                try
                {
                    if (input.Value.Any())
                    {
                        if (int.Parse(input.Value) > 0 && int.Parse(input.Value) <= 30)
                        {
                            CreateIconicTile(AppResources.ViewVolumeExtend, input.Value,
                                AppResources.smallIconImage, AppResources.iconImage, int.Parse(input.Value));
                        }
                        else if (int.Parse(input.Value) == 0)
                        {
                            Tiles.PinShortcut(Tiles.Mute);
                        }
                        else
                        {
                            Toast.Title = AppResources.InputPromptWarningValue;
                            Toast.Message = "";
                            Toast.Show();
                        }
                    }
                }
                catch (Exception)
                {
                    Toast.Title = AppResources.InputPromptWarning;
                    Toast.Message = "";
                    Toast.Show();
                }

            };

            input.Show();

        }
    }
}
