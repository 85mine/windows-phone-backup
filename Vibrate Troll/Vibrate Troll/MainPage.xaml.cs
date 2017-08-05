using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Devices;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Vibrate_Troll.Resources;

namespace Vibrate_Troll
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        
        private DispatcherTimer coutdown_timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1.00)};

        private int count = 5;

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            coutdown_timer.Tick += coutdown_timer_Tick;
            coutdown_timer.Start();
        }

        void coutdown_timer_Tick(object sender, EventArgs e)
        {
            if (count <= 0)
            {
                count = 0;
                VibrateController.Default.Start(TimeSpan.FromMilliseconds(2000));
                //Application.Current.Terminate();
            }
            if (count == 0)
            {
                troll.Text = "";
            }
            else
            {
                troll.Text = count.ToString();
            }
            count--;
        }
    }
}