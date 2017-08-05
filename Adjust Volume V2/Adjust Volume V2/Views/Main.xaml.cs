using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Windows.Phone.Media.Capture;
using Adjust_Volume_V2.Controls;
using Adjust_Volume_V2.Model;
using Adjust_Volume_V2.Resources;
using Microsoft.Phone.Controls;

namespace Adjust_Volume_V2.Views
{
    public partial class Main : PhoneApplicationPage
    {
        #region Variable

        private readonly DispatcherTimer _checkState = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(0.5)
        };

        #endregion

        public Main()
        {
            InitializeComponent();

            //Check state
            _checkState.Tick += _checkState_Tick;
        }

        private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!_checkState.IsEnabled)
            {
                _checkState.Start();
            }

            CoverStoryboard.Begin();
        }

        #region Checking state

        private void _checkState_Tick(object sender, EventArgs e)
        {
            NameSong.Text = SongMusic.Name;
            ArtistsSong.Text = SongMusic.Artist;
            var ib = new ImageBrush { ImageSource = SongMusic.Albumcover };
            Cover.Fill = ib;
            Cover.Stretch = Stretch.UniformToFill;
            Common.ChangeButton(Play, Pause);
        }

        #endregion

        #region Adjust volume

        private void Mute_Click(object sender, RoutedEventArgs e)
        {
            Common.SetVolume(0, VolumeSlider, VolumeValue);
        }

        private void Volume_Click(object sender, RoutedEventArgs e)
        {
            Common.SetVolume(30, VolumeSlider, VolumeValue);
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (VolumeSlider == null)
                    return;
                VolumeValue.Text = Convert.ToUInt16(VolumeSlider.Value).ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VolumeSlider_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            Common.SetVolume(Convert.ToUInt16(VolumeSlider.Value));
        }

        #endregion

        #region Music Player Controls

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            MusicControls.Stop(AppResources.Quickstop);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            MusicControls.Next();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            MusicControls.Play();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            MusicControls.Back();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            MusicControls.Pause();
        }

        #endregion

        #region Navigate To My Store

        private void Copyright_Tap(object sender, GestureEventArgs e)
        {
            Common.GetMore(AppResources.TextPublisher);
        }

        private void GetMore_Click(object sender, RoutedEventArgs e)
        {
            Common.GetMore(AppResources.TextPublisher);
        }

        #endregion


        #region Rating

        private void Rate_Click(object sender, RoutedEventArgs e)
        {
            Common.Rating();
        }

        #endregion
    }
}