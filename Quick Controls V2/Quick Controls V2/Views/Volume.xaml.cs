using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Quick_Controls_V2.Controls;

namespace Quick_Controls_V2.Views
{
    public partial class Volume : PhoneApplicationPage
    {
        private const string Key = "volume";
        private string _volumeValue = String.Empty;

        public Volume()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.TryGetValue(Key, out _volumeValue))
            {
                Common.SetVolume(Convert.ToUInt16(_volumeValue));
                Application.Current.Terminate();
            }
        }
    }
}