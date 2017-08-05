using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace STOP_Music.Views
{
    public partial class pageTimer : PhoneApplicationPage
    {
        DispatcherTimer timercount = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1)
        };


        public pageTimer()
        {
            InitializeComponent();
            timercount.Tick += timercount_Tick;
        }

        void timercount_Tick(object sender, EventArgs e)
        {
            timerWheel.selectedSecond++;
            if (timerWheel.selectedSecond == 0)
                timerWheel.selectedSecond = 59;
        }
    }
}