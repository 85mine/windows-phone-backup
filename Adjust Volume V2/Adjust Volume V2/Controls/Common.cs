using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Quick_Controls_V2.Controls;
using WP8SystemTime;

namespace Adjust_Volume_V2.Controls
{
    internal class Common
    {

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