using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using STOP_Music.Controller;
using STOP_Music.Resources;

namespace STOP_Music.Views
{
    public partial class Quickstop : PhoneApplicationPage
    {
        public Quickstop()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string msg = "";
            if (NavigationContext.QueryString.TryGetValue(AppResources.VarQuickstop, out msg))
            {
                if (msg == AppResources.VarQuickstop)
                {
                    Music.StopMusic();
                    Application.Current.Terminate();
                }
            }
        }
    }
}