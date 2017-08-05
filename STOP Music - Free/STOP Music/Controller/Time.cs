namespace STOP_Music.Controller
{
    internal class Time
    {
        public Time()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
            totalseconds = 0;
        }

        private int hours { get; set; }
        private int minutes { get; set; }
        private int seconds { get; set; }
        private int totalseconds { get; set; }

        public int Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }

        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        public int TotalSeconds
        {
            get
            {
                totalseconds = seconds + minutes*60 + hours*3600;
                return totalseconds;
            }
            set
            {
                totalseconds = value;
                hours = totalseconds/3600;
                minutes = (totalseconds%3600)/60;
                seconds = (totalseconds%3600)%60;
            }
        }
    }
}