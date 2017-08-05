using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Windows.Phone.Media.Capture;
using Adjust_Volume_V3.Resources;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using WP8SystemTime;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace Adjust_Volume_V3.Controls
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

        public static void SetVolume(uint value, Slider volumeslider, TextBlock volume)
        {
            new WPChangeSystemVolume().SubVolume(30);
            new WPChangeSystemVolume().AddVolume(value);
            volumeslider.Value = value;
            volume.Text = value.ToString(CultureInfo.InvariantCulture);
        }

        public static void MaxVolume()
        {
            new WPChangeSystemVolume().AddVolume(30);
        }

        public static void LockPhone(bool flashIsOn)
        {
            bool terminate = false;
            new WPRequestScreenClosed().RequestLockScreen();

            if (AppSetting.Settings.Contains(AppSetting.Autoclose))
            {
                if (bool.Parse(AppSetting.Settings[AppSetting.Autoclose].ToString()))
                {
                    terminate = true;
                }
            }

            if (AppSetting.Settings.Contains(AppSetting.Flashlight))
            {
                if (bool.Parse(AppSetting.Settings[AppSetting.Flashlight].ToString()))
                {
                    if (flashIsOn)
                    {
                        terminate = false;
                    }
                }
            }
            if (terminate)
            {
                Application.Current.Terminate();
            }
        }

        public static void LockPhone()
        {
            new WPRequestScreenClosed().RequestLockScreen();
        }

        public static void RestartPhone()
        {
            //new WPRequestRebootphone().RequestRebootPhone();
            //Application.Current.Terminate();
            new WPChangeSystemVolume().AddVolume(5);
        }


        public static void ChangeButton(Button play, Button pause)
        {
            try
            {
                FrameworkDispatcher.Update();
                switch (MediaPlayer.State)
                {
                    case MediaState.Playing:
                        play.Visibility = Visibility.Collapsed;
                        pause.Visibility = Visibility.Visible;
                        break;
                    case MediaState.Paused:
                        play.Visibility = Visibility.Visible;
                        pause.Visibility = Visibility.Collapsed;
                        break;
                    case MediaState.Stopped:
                        play.Visibility = Visibility.Visible;
                        pause.Visibility = Visibility.Collapsed;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":(" + ex.Message);
            }
        }

        public static void TurnOnFlashlight(ToggleButton flashlight, AudioVideoCaptureDevice avDevice,
            CameraSensorLocation sensorLocation)
        {
            try
            {
                IReadOnlyList<object> supportedCameraModes =
                    AudioVideoCaptureDevice.GetSupportedPropertyValues(sensorLocation,
                        KnownCameraAudioVideoProperties.VideoTorchMode);

                if (supportedCameraModes.ToList().Contains((UInt32)VideoTorchMode.On))
                {
                    avDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchMode, VideoTorchMode.On);
                    // set flash power to maxinum
                    avDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchPower,
                        AudioVideoCaptureDevice.GetSupportedPropertyRange(sensorLocation,
                            KnownCameraAudioVideoProperties.VideoTorchPower).Max);
                }
                flashlight.IsChecked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Turn On Flashlight " + ex.Message);
            }
        }

        public static void TurnOffFlashlight(ToggleButton flashlight, AudioVideoCaptureDevice avDevice)
        {
            try
            {
                avDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchMode, VideoTorchMode.Off);
                flashlight.IsChecked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Turn Off Flashlight " + ex.Message);
            }
        }

        public static void CreateIconicTile(string uri, string contains, string smallIconImage, string iconImage,
            int count)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(contains));

            if (tile != null && tile.NavigationUri.ToString().Contains(contains))
            {
                var iconicTileData = new IconicTileData
                {
                    SmallIconImage = new Uri(smallIconImage, UriKind.RelativeOrAbsolute),
                    IconImage = new Uri(smallIconImage, UriKind.RelativeOrAbsolute),
                    Count = count
                };

                tile.Update(iconicTileData);
                Toast.Title = AppResources.TextNotice;
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

                ShellTile.Create(tileUri, tileData, false);
            }
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

        public static void PinVolume()
        {
            var input = new InputPrompt
            {
                Title = AppResources.TextInputPromptHeader,
                Message = AppResources.TextInputPromptTitle,
                MessageTextWrapping = TextWrapping.Wrap,
                InputScope = new InputScope { Names = { new InputScopeName { NameValue = InputScopeNameValue.Number } } }
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
                            Toast.Title = AppResources.TextInputPromptWarningValue;
                            Toast.Message = "";
                            Toast.Show();
                        }
                    }
                }
                catch (Exception)
                {
                    Toast.Title = AppResources.TextInputPromptWarning;
                    Toast.Message = "";
                    Toast.Show();
                }
            };

            input.Show();
        }

        public static void SetStateNetWork(Button button, Rectangle state, bool stateIsOn)
        {
            if (stateIsOn)
            {
                state.Opacity = 100;
            }
            else
            {
                state.Opacity = 0;
            }
        }

        public static void GetMore(string publisher)
        {
            var getmore = new MarketplaceSearchTask();
            getmore.SearchTerms = publisher;
            getmore.ContentType = MarketplaceContentType.Applications;
            getmore.Show();
        }
    }
}