using System;
using System.Windows;
using System.Windows.Navigation;
using Adjust_Volume_V3.Controls;
using Adjust_Volume_V3.Resources;
using Microsoft.Phone.Controls;

namespace Adjust_Volume_V3.Views
{
    public partial class Navigation : PhoneApplicationPage
    {
        private const string Key = "Shortcut";
        private string _value = String.Empty;

        public Navigation()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.TryGetValue(Key, out _value))
            {
                switch (_value)
                {
                    case ShortcutValue.Mute:
                        Common.Mute();
                        break;
                }
                Application.Current.Terminate();
            }
        }
    }
}