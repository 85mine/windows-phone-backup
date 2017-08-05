using System;
using System.Windows;
using System.Windows.Navigation;
using Adjust_Volume_V3.Controls;
using Microsoft.Phone.Controls;

namespace Adjust_Volume_V3
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