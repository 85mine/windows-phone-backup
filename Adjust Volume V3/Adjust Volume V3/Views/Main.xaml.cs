using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;
using Adjust_Volume_V3.Controls;
using Adjust_Volume_V3.Model;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Adjust_Volume_V3.Resources;

namespace Adjust_Volume_V3
{
    public partial class MainPage : PhoneApplicationPage
    {
        #region Variable

        private readonly DispatcherTimer _checkState = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(0.5)
        };

        #endregion

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            _checkState.Tick += _checkState_Tick;
            //BuildLocalizedApplicationBar();
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
            ArtistSong.Text = SongMusic.Artist;
            var ib = new ImageBrush { ImageSource = SongMusic.Albumcover };
            AlbumCover.Fill = ib;
            AlbumCover.Stretch = Stretch.UniformToFill;
            Common.ChangeButton(Play, Pause);
        }

        #endregion

        private void VolumeSlider_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            Common.SetVolume(Convert.ToUInt16(VolumeSlider.Value));
        }

        private void VolumeSlider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
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

        #region ApplicationBar

        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar {BackgroundColor = Color.FromArgb(100, 231, 86, 69), Opacity = 90};

            // Create a new button and set the text value to the localized string from AppResources.
            var likeButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/like.png", UriKind.Relative))
            {
                Text = AppResources.TextRating
            };
            ApplicationBar.Buttons.Add(likeButton);
            likeButton.Click += likeButton_Click;
        }

        void likeButton_Click(object sender, EventArgs e)
        {
            Common.Rating();
        }

        #endregion



        private void Previous_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CoverStoryboard.Begin();
            Controls.MusicControls.Back();
        }

        private void Play_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CoverStoryboard.Begin();
            Controls.MusicControls.Play();
        }

        private void Pause_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CoverStoryboard.Begin();
            Controls.MusicControls.Pause();
        }

        private void Next_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CoverStoryboard.Begin();
            Controls.MusicControls.Next();
        }

        private void StopMusic_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CoverStoryboard.Begin();
        	Controls.MusicControls.Stop();
        }

        private void Rate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Common.Rating();
        }

        private void More_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	Common.GetMore(AppResources.TextPublisher);
        }

        private void Pin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Common.PinVolume();
        }
    }
}