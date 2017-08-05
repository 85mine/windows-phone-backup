using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Quick_Controls_V2.Controls;

namespace Quick_Controls_V2.UserControls
{
    public partial class Tutorial : UserControl
    {
        public Tutorial()
        {
            InitializeComponent();
            Width = Application.Current.Host.Content.ActualWidth;
            Height = Application.Current.Host.Content.ActualHeight;
            CloseStoryboard.Completed += CloseStoryboard_Completed;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        	TutorialStoryboard.Begin();
        }

        void CloseStoryboard_Completed(object sender, System.EventArgs e)
        {
            AppSetting.Add(AppSetting.Tutorial, true);
            var popup = this.Parent as Popup;
            if (popup != null) popup.IsOpen = false;
        }

        private void _4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            CloseStoryboard.Begin();
        }
    }
}