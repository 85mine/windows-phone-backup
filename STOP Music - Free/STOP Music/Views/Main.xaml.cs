using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using STOP_Music.Controller;
using STOP_Music.Controls;
using STOP_Music.Model;
using STOP_Music.Resources;

namespace STOP_Music.Views
{
    public partial class Main : PhoneApplicationPage
    {
        #region Variable

        //Toast notification  ( update successed,...)

        //Add song music cover => ImageBrush
        private readonly Popup _clearhistory = new Popup();
        private readonly ImageBrush _imageBrush = new ImageBrush();
        private readonly Popup _setting = new Popup();

        //Math time
        private readonly Time _time = new Time();

        private readonly DispatcherTimer _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1.5)
        };

        //Counter Timer
        private readonly DispatcherTimer _timerCounter = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1.0)
        };

        //TimeWheel
        private readonly DispatcherTimer _timewheel = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1)
        };

        private readonly ToastPrompt _toast = new ToastPrompt();

        //Popup

        #endregion

        public Main()
        {
            InitializeComponent();

            (App.Current as App).rateReminder.Notify();

            #region SET No Cover for album cover

            _imageBrush.ImageSource = SongMusic.Albumcover;

            AlbumCover.Fill = _imageBrush;

            #endregion

            #region Set info

            SongName.Text = SongMusic.Name;
            SongArtist.Text = SongMusic.Artist;

            #endregion

            #region Tick Events

            _timer.Tick += timer_Tick;
            _timewheel.Tick += _timewheel_Tick;
            _timerCounter.Tick += _timerCounter_Tick;

            #endregion

            _timer.Start();
        }

        #region TimerCounter Tick

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
                timeselector.Value = new TimeSpan(0, 30, 0);
                SecondSlider.EndAngle = 0;
                _timerCounter.Stop();
                _timewheel.Stop();
                StartTimer.Visibility = Visibility.Visible;
                StopTimer.Visibility = Visibility.Collapsed;
                if (AppSetting.Settings.Contains(AppSetting.Autoclose))
                {
                    if (bool.Parse(AppSetting.Settings[AppSetting.Autoclose].ToString()))
                    {
                        Application.Current.Terminate();
                    }
                }
            }
        }

        #endregion

        #region TimeWheel Tick

        private void _timewheel_Tick(object sender, EventArgs e)
        {
            SecondSlider.EndAngle++;
            if (SecondSlider.EndAngle == 360)
                SecondSlider.EndAngle = 0;
        }

        #endregion

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //#region Initialize Language

            //quickstop_bar.Text = AppResources.AppBarQuickStop;
            //rate_bar.Text = AppResources.AppBarRating;
            //clear_bar.Text = AppResources.AppBarClearHistory;
            //setting_bar.Text = AppResources.AppBarSettings;

            //#endregion
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            #region SET No Cover for album cover

            _imageBrush.ImageSource = SongMusic.Albumcover;

            AlbumCover.Fill = _imageBrush;

            #endregion

            #region Set info

            SongName.Text = SongMusic.Name;
            SongArtist.Text = SongMusic.Artist;

            #endregion
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            CoverStoryboard.Begin();
            InfoStoryboard.Begin();
            if (AppSetting.IsShowTutorial())
            {
                NavigationService.Navigate(new Uri(AppResources.ViewTutorial, UriKind.RelativeOrAbsolute));
            }
        }

		#region Rating this app

        private void rate_bar_Click(object sender, EventArgs e)
        {
            #region Ratting app

            Controller.Controls.Ratting();

            #endregion
        }

        #endregion

        #region Clear History

        private void clear_bar_Click(object sender, EventArgs e)
        {
            ApplicationBar.IsVisible = false;
            _clearhistory.Child = new ClearHistory();
            _clearhistory.IsOpen = true;
            _clearhistory.VerticalOffset = 0;
            _clearhistory.HorizontalOffset = 0;
        }

        #endregion

        #region Create Tiles Quick Stop Music

        private void quickstop_bar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppResources.MsgQUICKSTOP, AppResources.Notice, MessageBoxButton.OKCancel) ==
                MessageBoxResult.OK)
            {
                Controller.Controls.CreateFlipTile(AppResources.ViewQuickstopExtend, AppResources.VarQuickstop,
                    AppResources.QUICKSTOP400,
                    AppResources.QUICKSTOP400, AppResources.QUICKSTOP691, true, AppResources.TextQuickstop);
            }
        }

        #endregion

        #region Open Setting 

        private void setting_bar_Click(object sender, EventArgs e)
        {
            ApplicationBar.IsVisible = false;
            _setting.Child = new Setting();
            _setting.IsOpen = true;
            _setting.VerticalOffset = 0;
            _setting.HorizontalOffset = 0;
        }

        #endregion

        #region BackKeyPress

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            //Check if the PopUp window is open
            if (_setting.IsOpen || _clearhistory.IsOpen)
            {
                e.Cancel = true;
                _setting.IsOpen = false;
                _clearhistory.IsOpen = false;
                ApplicationBar.IsVisible = true;
            }
            else
            {
                //There is no PopUp open, use the back button normally
                //base.OnBackKeyPress(e);
                Application.Current.Terminate();
            }
        }

        #endregion

        #region Change Current Pivot

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Pivotlayout.SelectedItem == StopPivot)
            {
                ApplicationBar.IsVisible = true;
            }
            else if (Pivotlayout.SelectedItem == TimerPivot)
            {
                ApplicationBar.IsVisible = false;
            }
            else if (Pivotlayout.SelectedItem == AboutPivot)
            {
                ApplicationBar.IsVisible = false;
            }
        }

        #endregion

        #region Start Timer

        private void startTimer_Click(object sender, RoutedEventArgs e)
        {
            #region Math coutdown

            _time.Seconds = int.Parse(timeselector.ValueString.Substring(6, 2));
            _time.Minutes = int.Parse(timeselector.ValueString.Substring(3, 2));
            _time.Hours = int.Parse(timeselector.ValueString.Substring(0, 2));

            #endregion

            _timerCounter.Start();
            _timewheel.Start();

            StartTimer.Visibility = Visibility.Collapsed;
            StopTimer.Visibility = Visibility.Visible;
            
            var toast=new ToastPrompt
            {
                Title = "Warning !",
                Message = "PLEASE KEEP APP RUNNING IN FOREGROUND\nYOU CAN TURN OFF SCREEN IF YOU WANT 🙅",
                TextOrientation = System.Windows.Controls.Orientation.Vertical,
            };

            toast.Show();
        }

        #endregion

        #region Stop Timer

        private void stopTimer_Click(object sender, RoutedEventArgs e)
        {
            _timerCounter.Stop();
            _timewheel.Stop();
            StartTimer.Visibility = Visibility.Visible;
            StopTimer.Visibility = Visibility.Collapsed;
            SecondSlider.EndAngle = 0;
        }

        #endregion

        #region Pin Timer To Start

        private void PintimerBtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Controller.Controls.GetProVersion("d50346ae-6c38-44de-ae6c-feccbfe0643d");

            #region PRO

            //string timerInput = Controller.Controls.TimeSelectorToString(timeselector); //Return timer (ex: 003000)

            //#region Create FlipTile

            //try
            //{
            //    //this.LayoutRoot.Children.Add(new Loading());
            //    Controller.Controls.FlipTilesAsync(timerInput);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //#endregion

            #endregion
        }

        #endregion

        #region Quick Set Timer

        private void quicksetTimer_Click(object sender, RoutedEventArgs e)
        {
			
        }

        #endregion

        private void AlbumCover_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	Music.StopMusic();
            CoverStoryboard.Stop();
        }

        private void help_btn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            AppSetting.Remove(AppSetting.Tutorial);
        	NavigationService.Navigate(new Uri(AppResources.ViewTutorial, UriKind.RelativeOrAbsolute));
        }

        private void getmore_btn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	Controller.Controls.GetMore();
        }

        private void rating_btn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	Controller.Controls.Ratting();
        }
		
    }
}