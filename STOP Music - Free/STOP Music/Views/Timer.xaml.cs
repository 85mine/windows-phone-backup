using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using STOP_Music.Controller;
using STOP_Music.Resources;

namespace STOP_Music.Views
{
    public partial class Timer : PhoneApplicationPage
    {

        //Math time
        private readonly Time _time = new Time();

        private readonly DispatcherTimer _timerCounter = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1.0)
        };

        private readonly DispatcherTimer _timewheel = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1)
        };


        public Timer()
        {
            InitializeComponent();
            _timewheel.Tick += _timewheel_Tick;
            _timerCounter.Tick += _timerCounter_Tick;
        }

        private void _timerCounter_Tick(object sender, EventArgs e)
        {
            if (_time.TotalSeconds > 0)
            {
                _time.TotalSeconds--;
                timeselector.Value = new TimeSpan(_time.Hours, _time.Minutes, _time.Seconds);
            }
            else
            {
                Music.StopMusic();
                Application.Current.Terminate();
            }
        }

        private void _timewheel_Tick(object sender, EventArgs e)
        {
            SecondSlider.EndAngle++;
            if (SecondSlider.EndAngle == 360)
                SecondSlider.EndAngle = 0;
        }


        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Delete cache (image, database)
            Controller.Controls.DeleteFilesFromIsolatedStorage();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string msg = "";
            if (NavigationContext.QueryString.TryGetValue(AppResources.VarTimerInput, out msg))
            {
                _time.Hours = int.Parse(msg.Substring(0, 2));
                _time.Minutes = int.Parse(msg.Substring(2, 2));
                _time.Seconds = int.Parse(msg.Substring(4, 2));
                timeselector.Value = new TimeSpan(_time.Hours, _time.Minutes, _time.Seconds);
            }

            _timewheel.Start();
            _timerCounter.Start();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            _timewheel.Stop();
            _timerCounter.Stop();
        }

        #region ApplicationBar Events

        private void rate_bar_Click(object sender, EventArgs e)
        {
            Controller.Controls.Ratting();
        }

        private void home_bar_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri(AppResources.ViewMain, UriKind.RelativeOrAbsolute));
        }

        #endregion
    }
}