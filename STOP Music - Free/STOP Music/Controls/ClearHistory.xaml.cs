using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using STOP_Music.Controller;

namespace STOP_Music.Controls
{
    public partial class ClearHistory : UserControl
    {
        //History timer
        private readonly DispatcherTimer _historyTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1)
        };

        public ClearHistory()
        {
            InitializeComponent();

            Width = Application.Current.Host.Content.ActualWidth;

            Height = Application.Current.Host.Content.ActualHeight;

            _historyTimer.Tick += historyTimer_Tick; //percent Circle
            ClearHistoryStoryboard.Completed += ClearHistoryStoryboard_Completed;
                //Clean history when storyboar is stoped
            PercentCir.EndAngle = 0;
            ProcessdDone.Visibility = Visibility.Collapsed;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ClearHistoryStoryboard.Begin();
        }

        #region ClearHistoryStoryboard

        private void ClearHistoryStoryboard_Completed(object sender, EventArgs e)
        {
            RunClearTask();
            _historyTimer.Start();
        }

        #endregion

        #region historyTimer Tick

        private void historyTimer_Tick(object sender, EventArgs e)
        {
            PercentCir.EndAngle++;
            if (PercentCir.EndAngle == 360)
                PercentCir.EndAngle = 0;
        }

        #endregion

        #region RunClearTask

        private async void RunClearTask()
        {
            bool result = await Music.ClearHistory();
            if (result)
            {
                PercentCir.EndAngle = 360;
                _historyTimer.Stop();
                processDoneStoryboard.Begin();
            }
        }

        #endregion
    }
}