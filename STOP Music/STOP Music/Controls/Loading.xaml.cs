using System.Windows;
using System.Windows.Controls;

namespace STOP_Music.Controls
{
    public partial class Loading : UserControl
    {
        public Loading()
        {
            InitializeComponent();

            Width = Application.Current.Host.Content.ActualWidth;

            Height = Application.Current.Host.Content.ActualHeight;
        }
    }
}