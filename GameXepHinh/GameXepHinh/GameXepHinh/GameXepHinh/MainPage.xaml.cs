using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Threading;

namespace GameXepHinh
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        Rectangle[,] arr = new Rectangle[20, 32];
        DispatcherTimer newTimer = new DispatcherTimer();
        //  public static bool CheckWifi = false;
        int count = 0;
        bool x = false;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //  CheckWifi = checkWifi();
        }
        private void mouseLeftButtonUp(object sender, EventArgs e)
        {
            newTimer.Stop();
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.RelativeOrAbsolute));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {
                //   Controller.ButtonController.processFile();
                e.Cancel = false;
                //  game.Exit();
            }
            else
            {
                e.Cancel = true;
                //   MessageBox.Show("OK");
                // NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            newTimer.Tick -= OnTimerTick;
            myAudio.Volume = 1;
            setArray();
            collapsed();
            this.textBlock1.Opacity = 1;

            count = 0;
            DateTime moment = DateTime.Now;

            int day = moment.Day;
            int hour = moment.Hour;
            int minute = moment.Minute;
            x = ((day + hour + minute) % 2 == 0);

            newTimer.Interval = TimeSpan.FromMilliseconds(80);
            newTimer.Start();
            newTimer.Tick += OnTimerTick;

            // Controller.AudioController.backgroundMusic = new Controller.NoBackgroundMedia();

            /*    if (MediaPlayer.State == MediaState.Playing)
                {
                    MessageBoxResult m = MessageBox.Show("Bạn có muốn nghe nhạc nền của game không?", "Đổi nhạc nền", MessageBoxButton.OKCancel);
                    if (m == MessageBoxResult.OK)
                    {
                        Controller.CheckNote.Read_Volume() = true;
                        MediaPlayer.Stop();
                        //hoimotlan = true;
                    }
                    else
                    {
                        Controller.CheckNote.Read_Volume() = false;

                    }
                }
                */
            // Controller.CheckNote.Note();
            //   Controller.AudioController.backgroundMusic.setBackgroundMusic("for_qplay.mp3", myAudio);
            //Controller.AudioController.playAudio("for_qplay.mp3", myAudio);
        }

        protected override void OnNavigatingFrom(System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            //Controller.Controller.proc(this, this.myAudio);
            newTimer.Tick -= OnTimerTick;
            newTimer.Stop();
            //Controller.CloneController.title = "ques" + t + ".mp3";
            //Controller.CloneController.title = myAudio.Source.ToString();
        }

        //private void play()
        //{
        //    if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
        //    {
        //        BackgroundAudioPlayer.Instance.Pause();
        //    }
        //    else
        //    {
        //        BackgroundAudioPlayer.Instance.Play();
        //    }
        //}

        void OnTimerTick(object sender, EventArgs e)
        {
            visible(count);
            count++;
            if (count >= 42 && count <= 61)
            {
                this.textBlock1.Opacity -= 0.05;
            }
            if (count >= 62)
            {
                newTimer.Stop();
                NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void setArray()
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 32; j++)
                {
                    arr[i, j] = null;
                }
            arr[0, 13] = l00;
            arr[0, 14] = l01;
            arr[0, 15] = l02;
            arr[1, 13] = l10;
            arr[1, 14] = l11;
            arr[1, 15] = l12;
            arr[2, 13] = l20;
            arr[2, 14] = l21;
            arr[2, 15] = l22;

            arr[3, 1] = q0_1;
            arr[3, 2] = q0_2;
            arr[3, 3] = q0_3;
            arr[3, 4] = q0_4;
            arr[3, 5] = q0_5;
            arr[3, 7] = q0_7;
            arr[3, 8] = q0_8;
            arr[3, 9] = q0_9;
            arr[3, 10] = q0_10;
            arr[3, 11] = q0_11;

            arr[3, 13] = l30;
            arr[3, 14] = l31;
            arr[3, 15] = l32;

            arr[3, 18] = a0_2;
            arr[3, 19] = a0_3;
            arr[3, 20] = a0_4;
            arr[3, 21] = a0_5;
            arr[3, 22] = a0_6;

            arr[3, 24] = y0_0;
            arr[3, 25] = y0_1;
            arr[3, 26] = y0_2;
            arr[3, 29] = y0_5;
            arr[3, 30] = y0_6;
            arr[3, 31] = y0_7;

            arr[4, 0] = q1_0;
            arr[4, 1] = q1_1;
            arr[4, 2] = q1_2;
            arr[4, 3] = q1_3;
            arr[4, 4] = q1_4;
            arr[4, 5] = q1_5;
            arr[4, 6] = q1_6;
            arr[4, 7] = q1_7;
            arr[4, 8] = q1_8;
            arr[4, 9] = q1_9;
            arr[4, 10] = q1_10;
            arr[4, 11] = q1_11;
            arr[4, 12] = q1_12;

            arr[4, 13] = l40;
            arr[4, 14] = l41;
            arr[4, 15] = l42;

            arr[4, 17] = a1_1;
            arr[4, 18] = a1_2;
            arr[4, 19] = a1_3;
            arr[4, 20] = a1_4;
            arr[4, 21] = a1_5;
            arr[4, 22] = a1_6;
            arr[4, 23] = a1_7;
            arr[4, 24] = y1_0;
            arr[4, 25] = y1_1;
            arr[4, 26] = y1_2;

            arr[4, 29] = y1_5;
            arr[4, 30] = y1_6;
            arr[4, 31] = y1_7;

            arr[5, 0] = q2_0;
            arr[5, 1] = q2_1;
            arr[5, 2] = q2_2;

            arr[5, 5] = q2_5;
            arr[5, 6] = q2_6;
            arr[5, 7] = q2_7;

            arr[5, 10] = q2_10;
            arr[5, 11] = q2_11;
            arr[5, 12] = q2_12;

            arr[5, 13] = l50;
            arr[5, 14] = l51;
            arr[5, 15] = l52;

            arr[5, 21] = a2_5;
            arr[5, 22] = a2_6;
            arr[5, 23] = a2_7;

            arr[5, 24] = y2_0;
            arr[5, 25] = y2_1;
            arr[5, 26] = y2_2;

            arr[5, 29] = y2_5;
            arr[5, 30] = y2_6;
            arr[5, 31] = y2_7;

            arr[6, 0] = q3_0;
            arr[6, 1] = q3_1;
            arr[6, 2] = q3_2;

            arr[6, 5] = q3_5;
            arr[6, 6] = q3_6;
            arr[6, 7] = q3_7;

            arr[6, 10] = q3_10;
            arr[6, 11] = q3_11;
            arr[6, 12] = q3_12;

            arr[6, 13] = l60;
            arr[6, 14] = l61;
            arr[6, 15] = l62;

            arr[6, 17] = a3_1;
            arr[6, 18] = a3_2;
            arr[6, 19] = a3_3;
            arr[6, 20] = a3_4;
            arr[6, 21] = a3_5;
            arr[6, 22] = a3_6;
            arr[6, 23] = a3_7;

            arr[6, 24] = y3_0;
            arr[6, 25] = y3_1;
            arr[6, 26] = y3_2;

            arr[6, 29] = y3_5;
            arr[6, 30] = y3_6;
            arr[6, 31] = y3_7;

            arr[7, 0] = q4_0;
            arr[7, 1] = q4_1;
            arr[7, 2] = q4_2;

            arr[7, 5] = q4_5;
            arr[7, 6] = q4_6;
            arr[7, 7] = q4_7;

            arr[7, 10] = q4_10;
            arr[7, 11] = q4_11;
            arr[7, 12] = q4_12;

            arr[7, 13] = l70;
            arr[7, 14] = l71;
            arr[7, 15] = l72;

            arr[7, 16] = a4_0;
            arr[7, 17] = a4_1;
            arr[7, 18] = a4_2;
            arr[7, 19] = a4_3;
            arr[7, 20] = a4_4;
            arr[7, 21] = a4_5;
            arr[7, 22] = a4_6;
            arr[7, 23] = a4_7;

            arr[7, 24] = y4_0;
            arr[7, 25] = y4_1;
            arr[7, 26] = y4_2;

            arr[7, 29] = y4_5;
            arr[7, 30] = y4_6;
            arr[7, 31] = y4_7;

            arr[8, 0] = q5_0;
            arr[8, 1] = q5_1;
            arr[8, 2] = q5_2;

            arr[8, 5] = q5_5;
            arr[8, 6] = q5_6;
            arr[8, 7] = q5_7;

            arr[8, 10] = q5_10;
            arr[8, 11] = q5_11;
            arr[8, 12] = q5_12;

            arr[8, 13] = l80;
            arr[8, 14] = l81;
            arr[8, 15] = l82;

            arr[8, 16] = a5_0;
            arr[8, 17] = a5_1;

            arr[8, 21] = a5_5;
            arr[8, 22] = a5_6;
            arr[8, 23] = a5_7;

            arr[8, 24] = y5_0;
            arr[8, 25] = y5_1;
            arr[8, 26] = y5_2;
            arr[8, 27] = y5_3;
            arr[8, 28] = y5_4;

            arr[8, 29] = y5_5;
            arr[8, 30] = y5_6;
            arr[8, 31] = y5_7;

            arr[9, 0] = q6_0;
            arr[9, 1] = q6_1;
            arr[9, 2] = q6_2;
            arr[9, 3] = q6_3;
            arr[9, 4] = q6_4;

            arr[9, 5] = q6_5;
            arr[9, 6] = q6_6;
            arr[9, 7] = q6_7;
            arr[9, 8] = q6_8;
            arr[9, 9] = q6_9;

            arr[9, 10] = q6_10;
            arr[9, 11] = q6_11;
            arr[9, 12] = q6_12;

            arr[9, 13] = l90;
            arr[9, 14] = l91;
            arr[9, 15] = l92;

            arr[9, 16] = a6_0;
            arr[9, 17] = a6_1;
            arr[9, 18] = a6_2;
            arr[9, 19] = a6_3;
            arr[9, 20] = a6_4;

            arr[9, 21] = a6_5;
            arr[9, 22] = a6_6;
            arr[9, 23] = a6_7;

            arr[9, 24] = y6_0;
            arr[9, 25] = y6_1;
            arr[9, 26] = y6_2;
            arr[9, 27] = y6_3;
            arr[9, 28] = y6_4;

            arr[9, 29] = y6_5;
            arr[9, 30] = y6_6;
            arr[9, 31] = y6_7;

            arr[10, 1] = q7_1;
            arr[10, 2] = q7_2;
            arr[10, 3] = q7_3;
            arr[10, 4] = q7_4;

            arr[10, 5] = q7_5;
            arr[10, 6] = q7_6;
            arr[10, 7] = q7_7;
            arr[10, 8] = q7_8;
            arr[10, 9] = q7_9;

            arr[10, 10] = q7_10;
            arr[10, 11] = q7_11;

            arr[10, 13] = l100;
            arr[10, 14] = l101;
            arr[10, 15] = l102;

            arr[10, 17] = a7_1;
            arr[10, 18] = a7_2;
            arr[10, 19] = a7_3;
            arr[10, 20] = a7_4;

            arr[10, 21] = a7_5;
            arr[10, 22] = a7_6;
            arr[10, 23] = a7_7;

            arr[10, 25] = y7_1;
            arr[10, 26] = y7_2;
            arr[10, 27] = y7_3;

            arr[10, 29] = y7_5;
            arr[10, 30] = y7_6;
            arr[10, 31] = y7_7;

            arr[11, 5] = q8_5;
            arr[11, 6] = q8_6;
            arr[11, 7] = q8_7;

            arr[11, 29] = y8_5;
            arr[11, 30] = y8_6;
            arr[11, 31] = y8_7;

            arr[12, 5] = q9_5;
            arr[12, 6] = q9_6;
            arr[12, 7] = q9_7;

            arr[12, 29] = y9_5;
            arr[12, 30] = y9_6;
            arr[12, 31] = y9_7;

            arr[13, 5] = q10_5;
            arr[13, 6] = q10_6;
            arr[13, 7] = q10_7;

            arr[13, 29] = y10_5;
            arr[13, 30] = y10_6;
            arr[13, 31] = y10_7;

            arr[14, 5] = q11_5;
            arr[14, 6] = q11_6;
            arr[14, 7] = q11_7;

            arr[14, 28] = y11_4;
            arr[14, 29] = y11_5;
            arr[14, 30] = y11_6;

            arr[15, 5] = q12_5;
            arr[15, 6] = q12_6;
            arr[15, 7] = q12_7;

            arr[15, 27] = y12_3;
            arr[15, 28] = y12_4;
            arr[15, 29] = y12_5;

            arr[16, 5] = q13_5;
            arr[16, 6] = q13_6;
            arr[16, 7] = q13_7;

            arr[17, 5] = q14_5;
            arr[17, 6] = q14_6;
            arr[17, 7] = q14_7;
            arr[17, 8] = q14_8;

            arr[18, 5] = q15_5;
            arr[18, 6] = q15_6;
            arr[18, 7] = q15_7;
            arr[18, 8] = q15_8;

            arr[19, 5] = q16_5;
            arr[19, 6] = q16_6;
            arr[19, 7] = q16_7;

        }

        private void collapsed()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (arr[i, j] != null)
                    {
                        arr[i, j].Visibility = System.Windows.Visibility.Collapsed;
                    }
                }
            }
        }

        private void visible(int count)
        {
            if (x)
            {
                if (count < 20)
                {
                    for (int i = 0; i < 32; i++)
                    {
                        if (arr[count, i] != null)
                            arr[count, i].Visibility = System.Windows.Visibility.Visible;
                    }
                }
                else
                {
                    if (count <= 49 && count >= 30)
                    {
                        for (int i = 0; i < 32; i++)
                        {
                            if (arr[49 - count, i] != null)
                                arr[49 - count, i].Visibility = System.Windows.Visibility.Collapsed;
                        }
                    }
                }

            }
            else
            {
                if (count < 32)
                {
                    for (int i = 0; i <= count && i < 20; i++)
                    {
                        for (int j = 0; j <= count; j++)
                        {
                            if (arr[i, j] != null)
                            {
                                if (arr[i, j].Visibility == System.Windows.Visibility.Collapsed)
                                    arr[i, j].Visibility = System.Windows.Visibility.Visible;
                            }
                        }
                    }
                }
                else
                {
                    if (count <= 61 && count >= 42)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            if (arr[i, 73 - count] != null)
                            {
                                if (arr[i, 73 - count].Visibility == System.Windows.Visibility.Visible)
                                    arr[i, 73 - count].Visibility = System.Windows.Visibility.Collapsed;
                            }
                        }
                        for (int j = 0; j < 32; j++)
                        {
                            if (arr[61 - count, j] != null)
                            {
                                if (arr[61 - count, j].Visibility == System.Windows.Visibility.Visible)
                                    arr[61 - count, j].Visibility = System.Windows.Visibility.Collapsed;
                            }
                        }
                    }

                }
            }
        }
    }
}

        
