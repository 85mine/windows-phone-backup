using System;
using System.Windows;
using System.Windows.Controls;

namespace STOP_Music.Controls
{
    public partial class TimeWheel : UserControl
    {
        //Public values
        public delegate void TimeChangedHandler(object sender, TimeChangedEventArgs e);

        public TimeWheel()
        {
            InitializeComponent();
            timeselector.ValueChanged += timeselector_ValueChanged;
            selectedHour = int.Parse(timeselector.ValueString.Substring(0, 2));
            selectedMinute = int.Parse(timeselector.ValueString.Substring(3, 2));
            selectedSecond = int.Parse(timeselector.ValueString.Substring(6, 2));
            setTime(selectedHour, selectedMinute, selectedSecond);
        }

        public int selectedMinute { get; set; }
        public int selectedHour { get; set; }
        public int selectedSecond { get; set; }

        //Events

        public event TimeChangedHandler TimeChangedEvent;

        protected void OnTimeChangedEvent(TimeChangedEventArgs e)
        {
            TimeChangedEvent(this, e);
        }

        private void timeselector_ValueChanged(object sender, RoutedPropertyChangedEventArgs<TimeSpan> e)
        {
            selectedHour = int.Parse(timeselector.ValueString.Substring(0, 2));
            selectedMinute = int.Parse(timeselector.ValueString.Substring(3, 2));
            selectedSecond = int.Parse(timeselector.ValueString.Substring(6, 2));
            setTime(selectedHour, selectedMinute, selectedSecond);
        }

        public void setTime(int hour, int minute, int second)
        {
            //Allow the wheels to manually be set

            selectedHour = hour;
            selectedMinute = minute;
            selectedSecond = second;

            hour_slider.EndAngle = (hour/23.0)*360.0;
            min_slider.EndAngle = (minute/60.0)*360.0;
            second_slider.EndAngle = (second/60.0)*360.0;

            timeselector.Value = new TimeSpan(hour, minute, second);
        }
    }

    public class TimeChangedEventArgs : EventArgs
    {
        private readonly int hour;
        private readonly int minute;
        private readonly int second;

        public TimeChangedEventArgs(int NewHour, int NewMinute, int NewSecond)
        {
            hour = NewHour;
            minute = NewMinute;
            second = NewSecond;
        }

        public int Hour
        {
            get { return hour; }
        }

        public int Minute
        {
            get { return minute; }
        }

        public int Second
        {
            get { return second; }
        }
    }
}