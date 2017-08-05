using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Adjust_Volume.Controller;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Adjust_Volume.Views
{
    public partial class Main : PhoneApplicationPage
    {
        public Main()
        {
            InitializeComponent();
        }

        private void VolumeSlider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (VolumeSlider == null)
                    return;
                VolumeText.Text = Convert.ToUInt16(VolumeSlider.Value).ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VolumeSlider_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            Common.SetVolume(Convert.ToUInt16(VolumeSlider.Value));
        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	Common.Rating();
        }
    }
}