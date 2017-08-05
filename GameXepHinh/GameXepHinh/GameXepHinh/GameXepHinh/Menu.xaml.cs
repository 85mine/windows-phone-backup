using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GameXepHinh.Controller;
using System.Windows.Threading;

namespace GameXepHinh
{
    public partial class Menu : PhoneApplicationPage
    {
        static int count = 0;
        public static bool nhacgame = false;
        public Menu()
        {
            InitializeComponent();
        }
        protected void OnNavigatingFrom(System.Windows.Navigation.NavigationEventArgs e)
        {


        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
                MessageBoxResult m = MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "", MessageBoxButton.OKCancel);
                if (m == MessageBoxResult.OK)
                {
                    //  Environment.Exit();
                    /* if (NavigationService.CanGoBack)
                     {
                         while (NavigationService.RemoveBackEntry() != null)
                         {
                             NavigationService.RemoveBackEntry();
                         }
                     }*/
                    //Microsoft.Xna.Framework.Game game = new Microsoft.Xna.Framework.Game();
                    //game.Exit();

                    Type type = Application.Current.GetType();
                    type.GetMethod("Terminate").Invoke(Application.Current, new object[] { });
                }
                else
                {
                    e.Cancel = true;
                    //   MessageBox.Show("OK");
                    // NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
                }
        }
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            timer.Stop();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {

            btncb4.Visibility = Visibility.Collapsed;
            cb_kieu4.Visibility = Visibility.Collapsed;
            btncb5.Visibility = Visibility.Collapsed;
            cb_kieu5.Visibility = Visibility.Collapsed;
            btncb6.Visibility = Visibility.Collapsed;
            cb_kieu6.Visibility = Visibility.Collapsed;
            Gr_Caidat.Visibility = Visibility.Collapsed;
            Hinhnen.diem = 0;
            if (Controller.CheckNote.Read_Block().Equals("2"))
            {
                cb_kieu1.IsChecked = true;
            }
            else if (Controller.CheckNote.Read_Block().Equals("3"))
            {
                cb_kieu2.IsChecked = true;
            }
            else if (Controller.CheckNote.Read_Block().Equals("5"))
            {
                cb_kieu3.IsChecked = true;
            }
            else if (Controller.CheckNote.Read_Block().Equals("1"))
            {
                cb_kieu4.IsChecked = true;
            }
            else if (Controller.CheckNote.Read_Block().Equals("6"))
            {
                cb_kieu5.IsChecked = true;
            }
            else if (Controller.CheckNote.Read_Block().Equals("8"))
            {
                cb_kieu6.IsChecked = true;
            }
            Controller.CheckNote.Note();
            if (Controller.CheckNote.Read_Volume())
            {
                cb_amthanh.IsChecked = true;
                myAudio.Source = new Uri("Audio/menubg.mp3", UriKind.RelativeOrAbsolute);
                myAudio.Play();
                nhacgame = true;
            }
            else { cb_amthanh.IsChecked = false; nhacgame = false; }
            if (Controller.CheckNote.Read_Bong())
            {
                cb_hienbong.IsChecked = true;
            }
            else { cb_hienbong.IsChecked = false; }
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(5);
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {

        }
        DispatcherTimer timer;
        private void btnChoi_Click(object sender, RoutedEventArgs e)
        {
            Hinhnen.level = 0;
            Hinhnen.IsPause = false;
            Update_Matrix.IsEndRow = false;
            Update_Matrix.IsDaChay = false;
            Update_Matrix.IsGameOver = false;
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    Update_Matrix.matrix[i, j] = 0;
                    Update_Matrix.matrix2[i, j] = 0;
                    Update_Matrix.matrix3[i, j] = 0;

                    Update_Matrix.matrix_mau[i, j] = 0;
                    Update_Matrix.matrix_bong[i, j] = 0;
                    Update_Matrix.matrix_mau2[i, j] = 0;
                    Hinhnen.matrix_nho[i, j] = 0;
                }
            NavigationService.Navigate(new Uri("/GamePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            myAudio.Position = TimeSpan.Zero;
            myAudio.Play();
        }

        private void btnDiemcao_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DiemCao.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnCaidat_Click(object sender, RoutedEventArgs e)
        {
            st_caidat.Begin();
            Gr_Caidat.Visibility = Visibility.Visible;
        }

        private void btn_Dong1_Click(object sender, RoutedEventArgs e)
        {
            Gr_Caidat.Visibility = Visibility.Collapsed;

        }
        private void cb_kieu3_Checked(object sender, RoutedEventArgs e)
        {
            cb_kieu1.IsChecked = false;
            cb_kieu2.IsChecked = false;
            cb_kieu3.IsChecked = true;
            cb_kieu4.IsChecked = false;
            cb_kieu5.IsChecked = false;
            cb_kieu6.IsChecked = false;
            Controller.CheckNote.Write_Block("5");
        }

        private void cb_kieu2_Checked(object sender, RoutedEventArgs e)
        {
            cb_kieu1.IsChecked = false;
            cb_kieu2.IsChecked = true;
            cb_kieu3.IsChecked = false;
            cb_kieu4.IsChecked = false;
            cb_kieu5.IsChecked = false;
            cb_kieu6.IsChecked = false;
            Controller.CheckNote.Write_Block("3");
        }

        private void cb_kieu1_Checked(object sender, RoutedEventArgs e)
        {
            cb_kieu1.IsChecked = true;
            cb_kieu2.IsChecked = false;
            cb_kieu3.IsChecked = false;
            cb_kieu4.IsChecked = false;
            cb_kieu5.IsChecked = false;
            cb_kieu6.IsChecked = false;
            Controller.CheckNote.Write_Block("2");
        }

        private void cb_kieu4_Checked(object sender, RoutedEventArgs e)
        {
            cb_kieu1.IsChecked = false;
            cb_kieu2.IsChecked = false;
            cb_kieu3.IsChecked = false;
            cb_kieu4.IsChecked = true;
            cb_kieu5.IsChecked = false;
            cb_kieu6.IsChecked = false;
            Controller.CheckNote.Write_Block("1");
        }

        private void cb_kieu5_Checked(object sender, RoutedEventArgs e)
        {
            cb_kieu1.IsChecked = false;
            cb_kieu2.IsChecked = false;
            cb_kieu3.IsChecked = false;
            cb_kieu4.IsChecked = false;
            cb_kieu5.IsChecked = true;
            cb_kieu6.IsChecked = false;
            Controller.CheckNote.Write_Block("6");
        }

        private void cb_kieu6_Checked(object sender, RoutedEventArgs e)
        {
            cb_kieu1.IsChecked = false;
            cb_kieu2.IsChecked = false;
            cb_kieu3.IsChecked = false;
            cb_kieu4.IsChecked = false;
            cb_kieu5.IsChecked = false;
            cb_kieu6.IsChecked = true;
            Controller.CheckNote.Write_Block("8");
        }

        private void cb_amthanh_Checked(object sender, RoutedEventArgs e)
        {
            Controller.CheckNote.Write_Volume(true);
            nhacgame = true;
            /* cb_amthanh.IsChecked = true;*/
            myAudio.Source = new Uri("Audio/menubg.mp3", UriKind.RelativeOrAbsolute);
            myAudio.Play();
        }

        private void cb_hienbong_Checked(object sender, RoutedEventArgs e)
        {
            Controller.CheckNote.Write_Bong(true);
        }

        private void cb_amthanh_Unchecked(object sender, RoutedEventArgs e)
        {
            
            Controller.CheckNote.Write_Volume(false);
            nhacgame = false;
            /* cb_amthanh.IsChecked = false;*/
            myAudio.Stop();
        }

        private void cb_hienbong_Unchecked(object sender, RoutedEventArgs e)
        {
            Controller.CheckNote.Write_Bong(false);
        }


    }
}