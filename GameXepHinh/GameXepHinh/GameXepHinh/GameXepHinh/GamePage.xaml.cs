using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameXepHinh.Controller;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;
using AMobiSDK;
using Microsoft.Xna.Framework.Media;

namespace GameXepHinh
{
    public partial class GamePage : PhoneApplicationPage
    {

        ContentManager contentManager;
       // Song baihat;
        UIElementRenderer uiRenderer;
        GameTimer timer;
        SpriteBatch spriteBatch;
        //   Texture2D khoi;
        //    Vector2 toado_khoi;
        Hinhnen hinhnen;
        //    int ImageIndex = 0;
        //      Khoi_L khoiL;
        Update_Matrix Update_mt = new Update_Matrix();
        public int Lindex { get; set; }
        int count = 0;
        // public static int[,] matrix = new int[23, 10];
        // public static int[,] matrix2 = new int[23, 10];
        //     IList<Khoi_L> list = new List<Khoi_L>();
        public static double countUpdate = 0;
      // DrawPause drawpause;
        public GamePage()
        {
            InitializeComponent();
          
            // Get the content manager from the application
            contentManager = (Application.Current as App).Content;
            hinhnen = new Hinhnen();
        //   drawpause = new DrawPause();
            Lindex = 0;
            //    khoiL = new Khoi_L();
            // list.Add(khoiL);
            // Create a timer for this page
            timer = new GameTimer();
            timer.UpdateInterval = TimeSpan.FromMilliseconds(5);
            timer.Update += OnUpdate;
            timer.Draw += OnDraw;
            LayoutUpdated += new EventHandler(GamePage_LayoutUpdated);

        }

       
        protected void OnNavigatingFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            AdManager.OnNavigatingFrom(webBrowser1);
            // MessageBox.Show("Load câu hỏi");
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AdManager.setWidgetCode("10e6dfa400f2b15c6d23e1ed7ab8af5a");
            AdManager advertisement = new AdManager();
            advertisement.OnNavigationTo(this, webBrowser1);

            btncb4.Visibility = Visibility.Collapsed;
            cb_kieu4.Visibility = Visibility.Collapsed;
            btncb5.Visibility = Visibility.Collapsed;
            cb_kieu5.Visibility = Visibility.Collapsed;
            btncb6.Visibility = Visibility.Collapsed;
            cb_kieu6.Visibility = Visibility.Collapsed;
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
               // myAudio.Source = new Uri("Audio/menubg.mp3", UriKind.RelativeOrAbsolute);
               // myAudio.Play();
            }
            else { cb_amthanh.IsChecked = false; }
            if (Controller.CheckNote.Read_Bong())
            {
                cb_hienbong.IsChecked = true;
            }
            else { cb_hienbong.IsChecked = false; }
//             int width = (int)ActualWidth;
//             int height = (int)ActualHeight;
//             uiRenderer = new UIElementRenderer(this, width, height);
            // Set the sharing mode of the graphics device to turn on XNA rendering
            SharedGraphicsDeviceManager.Current.GraphicsDevice.SetSharingMode(true);
         /*   Gr_pause.btn_pause.Visibility = Visibility.Visible;*/
         
           Gr_pause.Visibility = Visibility.Collapsed;
           Grbtn_Pause.Visibility = Visibility.Visible;
           Gr_choimoi.Visibility = Visibility.Collapsed;
           Gr_thoat.Visibility = Visibility.Collapsed;
           Gr_Caidat.Visibility = Visibility.Collapsed;
            /*   at_thua = contentManager.Load<SoundEffect>("Music/lost");*/
            // Update_Matrix.IsGameOver = false;
       
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(SharedGraphicsDeviceManager.Current.GraphicsDevice);
            hinhnen.LoadContent(contentManager);
            
      //    drawpause.LoadContent(contentManager);
            //   khoi = contentManager.Load<Texture2D>("Imgs/tetris-1");
            //  toado_khoi= new Vector2(100,10);
            //     khoiL.LoadContent(contentManager);
            // TODO: use this.content to load your game content here
            if (!Update_Matrix.IsEndRow&&!Hinhnen.IsPause)
                {
            Update_mt.LoadContent(contentManager);
                }
            else Update_mt.LoadContent1(contentManager);
            if (Hinhnen.IsPause) Gr_pause.Visibility = Visibility.Visible;
         
            // Start the timer
            timer.Start();

            //AdManager.setWidgetCode("10e6dfa400f2b15c6d23e1ed7ab8af5a");
            //AdManager advestisement = new AdManager();
            //advestisement.OnNavigationTo(this, null, null, banner320x50);
            //base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Stop the timer+
         
           Hinhnen.IsPause = true;
           Gr_pause.Visibility = Visibility.Visible;
//             Update_Matrix.IsEndRow = false;
//             Update_Matrix.IsDaChay = false;
          
            timer.Stop();
            // Set the sharing mode of the graphics device to turn off XNA rendering
            SharedGraphicsDeviceManager.Current.GraphicsDevice.SetSharingMode(false);
            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Allows the page to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        private void OnUpdate(object sender, GameTimerEventArgs e)
        {
            // TODO: Add your update logic here


            if (Hinhnen.IsPause)
            {
                hinhnen.Update(timer);
             
            }
            else
            {
                hinhnen.Update(timer);
                /* timer.Stop();*/
                countUpdate += e.ElapsedTime.TotalSeconds;
                if (Update_Matrix.IsEndRow)
                    Update_mt.Update(timer);
                if (Hinhnen.level == 1 && countUpdate >= 1f)
                {
                    //       khoiL.Update(timer);
                    Update_mt.Update(timer);
                    countUpdate = 0;
                    return;
                }
                if (Hinhnen.level == 2 && countUpdate >= 0.8f)
                {
                    //       khoiL.Update(timer);
                    Update_mt.Update(timer);
                    countUpdate = 0;
                    return;
                }
                if (Hinhnen.level == 3 && countUpdate >= 0.64f)
                {
                    //       khoiL.Update(timer);
                    Update_mt.Update(timer);
                    countUpdate = 0;
                    return;
                }
                if (Hinhnen.level == 4 && countUpdate >= 0.512f)
                {
                    //       khoiL.Update(timer);
                    Update_mt.Update(timer);
                    countUpdate = 0;
                    return;
                }

                if (Hinhnen.level == 5 && countUpdate >= 0.4096f)
                {
                    //       khoiL.Update(timer);
                    Update_mt.Update(timer);
                    countUpdate = 0;
                    return;
                }
                if (Hinhnen.level == 6 && countUpdate >= 0.32768f)
                {
                    //       khoiL.Update(timer);
                    Update_mt.Update(timer);
                    countUpdate = 0;
                    return;
                }
                if (Hinhnen.level == 7 && countUpdate >= 0.262144f)
                {
                    //       khoiL.Update(timer);
                    Update_mt.Update(timer);
                    countUpdate = 0;
                    return;
                }
                if (Hinhnen.level == 8 && countUpdate >= 0.2097152f)
                {
                    //       khoiL.Update(timer);
                    Update_mt.Update(timer);
                    countUpdate = 0;
                    return;
                }
                if (Hinhnen.level == 9 && countUpdate >= 0.1f)
                {
                    //       khoiL.Update(timer);
                    Update_mt.Update(timer);
                    countUpdate = 0;
                    return;
                }

                if (Update_Matrix.IsGameOver)
                {
                    MediaPlayer.Stop();
                    count = count + 1;
                    if (count == 900)
                    {
                        NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.RelativeOrAbsolute));
                    }
                }
            }
        }
        void GamePage_LayoutUpdated(object sender, EventArgs e)
        {
            int width = (int)ActualWidth;
            int height = (int)ActualHeight;
            if (uiRenderer != null &&
                 uiRenderer.Texture != null &&
                 uiRenderer.Texture.Width == width &&
                 uiRenderer.Texture.Height == height)
            {
                return;
            }
            // Ensure the page size is valid
            if (width <= 0 || height <= 0)
                return;
            //UIElementRenderer
            //    uiRenderer = this.get();
            // Do we already have a UIElementRenderer of the correct size?


            // Before constructing a new UIElementRenderer, be sure to Dispose the old one
            if (uiRenderer != null)
                uiRenderer.Dispose();

            uiRenderer = new UIElementRenderer(this, width, height);


        }
        /// <summary>
        /// Allows the page to draw itself.
        /// </summary>
        private void OnDraw(object sender, GameTimerEventArgs e)
        {
            uiRenderer.Render();
            SharedGraphicsDeviceManager.Current.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            hinhnen.Draw(spriteBatch);
            Update_mt.Draw(spriteBatch);

            spriteBatch.Draw(uiRenderer.Texture,Vector2.Zero,Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hinhnen.IsPause = true;
            st_thoat.Begin();
            Gr_thoat.Visibility = Visibility.Visible;
        }
        private void btn_choitiep_Click(object sender, RoutedEventArgs e)
        {
            Hinhnen.IsPause = false;
            Gr_pause.Visibility = Visibility.Collapsed;
        }

        private void btn_choilai_Click(object sender, RoutedEventArgs e)
        {
            st_choimoi.Begin();
            Gr_pause.Visibility = Visibility.Collapsed;
            Gr_choimoi.Visibility = Visibility.Visible;
        }

        private void btn_caidat_Click(object sender, RoutedEventArgs e)
        {
            Gr_Caidat.Visibility = Visibility.Visible;
        }

        private void btn_thoat_Click(object sender, RoutedEventArgs e)
        {
            st_thoat.Begin();
            Gr_thoat.Visibility = Visibility.Visible;
            Gr_pause.Visibility = Visibility.Collapsed;
            
        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            Hinhnen.IsPause = true;
            st_pause.Begin();
            Gr_pause.Visibility = Visibility.Visible;
            
        }

        private void btn_dongy_Click(object sender, RoutedEventArgs e)
        {
            Hinhnen.IsPause = false;
            Gr_pause.Visibility = Visibility.Collapsed;
            Gr_choimoi.Visibility = Visibility.Collapsed;
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    Update_Matrix.matrix[i, j] = 0;
                    Update_Matrix.matrix2[i, j] = 0;
                    Update_Matrix.matrix3[i, j] = 0;
                    Update_Matrix.matrix_mau[i, j] = 0;
                    Update_Matrix.matrix_bong[i, j] = 0;
                    Update_Matrix.matrix_mau2[i, j] = 0;
                }
            Hinhnen.level = 9;
            Hinhnen.diem = 0;
            Update_Matrix.IsEndRow = false;
            Update_mt.LoadContent(contentManager);
        }

        private void btn_huybo_Click(object sender, RoutedEventArgs e)
        {
           
            Hinhnen.IsPause = false;
            Gr_pause.Visibility = Visibility.Collapsed;
            Gr_choimoi.Visibility = Visibility.Collapsed;
        }

        private void btn_dongy1_Click(object sender, RoutedEventArgs e)
        {
            Gr_thoat.Visibility = Visibility.Collapsed;
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_huybo1_Click(object sender, RoutedEventArgs e)
        {
            Gr_thoat.Visibility = Visibility.Collapsed;
            Hinhnen.IsPause = false;
            Gr_pause.Visibility = Visibility.Collapsed;
            Gr_choimoi.Visibility = Visibility.Collapsed;
        }

        private void cb_kieu3_Checked(object sender, RoutedEventArgs e)
        {
            cb_kieu1.IsChecked = false;
            cb_kieu3.IsChecked = true;
            cb_kieu2.IsChecked = false;
            cb_kieu4.IsChecked = false;
            cb_kieu5.IsChecked = false;
            cb_kieu6.IsChecked = false;
            Controller.CheckNote.Write_Block("5");
       
//                     Update_mt.LoadContent2(contentManager);
                }

        private void cb_kieu2_Checked(object sender, RoutedEventArgs e)
        {
            cb_kieu1.IsChecked = false;
            cb_kieu3.IsChecked = false;
            cb_kieu2.IsChecked = true;
            cb_kieu4.IsChecked = false;
            cb_kieu5.IsChecked = false;
            cb_kieu6.IsChecked = false;
            Controller.CheckNote.Write_Block("3");
      
            /* hinhnen.LoadContent2(contentManager);*/
           //  Update_mt.LoadContent2(contentManager);
         }

        private void cb_kieu1_Checked(object sender, RoutedEventArgs e)
        {
            cb_kieu1.IsChecked = true;
            cb_kieu3.IsChecked = false;
            cb_kieu2.IsChecked = false;
            cb_kieu4.IsChecked = false;
            cb_kieu5.IsChecked = false;
            cb_kieu6.IsChecked = false;
            Controller.CheckNote.Write_Block("2");
     
          /*  hinhnen.LoadContent2(contentManager);*/
            /// Update_mt.LoadContent2(contentManager);

        }

        private void btn_Dong_Click(object sender, RoutedEventArgs e)
        {
            Hinhnen.IsPause = false;
            Gr_Caidat.Visibility = Visibility.Collapsed;
            Gr_pause.Visibility = Visibility.Collapsed;
        }

        private void cb_kieu4_Checked(object sender, RoutedEventArgs e)
        {
            cb_kieu1.IsChecked = false;
            cb_kieu3.IsChecked = false;
            cb_kieu2.IsChecked = false;
            cb_kieu4.IsChecked = true;
            cb_kieu5.IsChecked = false;
            cb_kieu6.IsChecked = false;
            Controller.CheckNote.Write_Block("1");
        }

        private void cb_kieu5_Checked(object sender, RoutedEventArgs e)
        {
            cb_kieu1.IsChecked = false;
            cb_kieu3.IsChecked = false;
            cb_kieu2.IsChecked = false;
            cb_kieu4.IsChecked = false;
            cb_kieu5.IsChecked = true;
            cb_kieu6.IsChecked = false;
            Controller.CheckNote.Write_Block("6");
        }

        private void cb_kieu6_Checked(object sender, RoutedEventArgs e)
        {
            cb_kieu1.IsChecked = false;
            cb_kieu3.IsChecked = false;
            cb_kieu2.IsChecked = false;
            cb_kieu4.IsChecked = false;
            cb_kieu5.IsChecked = false;
            cb_kieu6.IsChecked = true;
            Controller.CheckNote.Write_Block("8");
        }

        private void cb_amthanh_Checked(object sender, RoutedEventArgs e)
        {
            Controller.CheckNote.Write_Volume(true);
            Menu.nhacgame = true;
            hinhnen.LoadContent1(contentManager);
           // MediaPlayer.Play(Hinhnen.baihat);
        }

        private void cb_hienbong_Checked(object sender, RoutedEventArgs e)
        {
            Controller.CheckNote.Write_Bong(true);
        }

        private void cb_hienbong_Unchecked(object sender, RoutedEventArgs e)
        {
            Controller.CheckNote.Write_Bong(false);
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    Update_Matrix.matrix_bong[i, j] = 0;
                }
        }

        private void cb_amthanh_Unchecked(object sender, RoutedEventArgs e)
        {
            Controller.CheckNote.Write_Volume(false);
            Menu.nhacgame = false;
            MediaPlayer.Stop();
        }
    }
}