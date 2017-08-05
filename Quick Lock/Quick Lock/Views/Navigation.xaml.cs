using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Quick_Lock.Controls;

namespace Quick_Lock.Views
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
                    case ShortcutValue.LockPhone:
                        Common.LockPhone();
                        break;
                }
                Application.Current.Terminate();
            }
        }
    }
}