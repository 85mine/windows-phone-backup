using GameXepHinh.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace GameXepHinh
{
    class Hinhnen
    {
        Texture2D hinhnen;
        Vector2 toado_hinhnen;
        Texture2D khungchoi;
        Vector2 toado_khungchoi;
        Texture2D khungcapdo;
        Vector2 toado_capdo;
        Texture2D khungdiem;
        Vector2 toado_khungdiem;
        //         Texture2D btn_pause;
        Vector2 toado_pause;
        Texture2D btn_xuongnhanh;
        Texture2D btn_xuongnhanh2;
        Vector2 toado_xuongnhanh;
        Texture2D khoinho1;
        Texture2D khoinho2;
        Texture2D khoinho3;
        Texture2D khoinho4;
        Texture2D khoinho5;
        Texture2D khoinho6;
        Vector2 toado_khoinho;
        Rectangle r_btn1;
        Rectangle r_btn2;
        Rectangle r_btn3;
        Rectangle r_btn4;
        Rectangle r_pause;
        Rectangle r_xuongnhanh;
        public static String str_btn = "";
        public Vector2 start;
        public Vector2 stop;
        public Vector2 moved;
        SpriteFont sprifont;
        Texture2D levelup;
        Vector2 td_levelup;
        /* DrawPause drawpause;*/
        public static Song baihat;
        SoundEffect at_xoay;
        SoundEffect at_xuongnhanh;
        SoundEffect at_dichuyen;
        SoundEffect at_levelUp;

        public static String StrButton = "";
        public static int diem = 0;
        public static int level = 0;
        bool IsDrawLevel = false;
        public static bool IsPause = false;
        int count = 0;
        public bool gioihan_trai = false;
        public bool gioihan_phai = false;
        public bool IsXuongnhanh = false;
        public static int[,] matrix_nho = new int[28, 10];
        public DispatcherTimer timer = new DispatcherTimer();
        public static int second = 0;
        public static int second_nhay = 0;
        bool Isphatnhac = false;
        SoundEffect at_thua;

        public Hinhnen()
        {

            /* TouchPanel.EnabledGestures = GestureType.HorizontalDrag | GestureType.VerticalDrag | GestureType.Tap | GestureType.DragComplete;*/
        }
        private void MediaStateChanged(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Resume();
        }
        public void LoadContent1(ContentManager Content)
        {
            baihat = Content.Load<Song>("Music/gamebg2");
            if (Controller.CheckNote.Read_Volume())
            {
                MediaPlayer.Play(baihat);
            }
        }
        public void LoadContent(ContentManager Content)
        {
            baihat = Content.Load<Song>("Music/gamebg2");
            if (Controller.CheckNote.Read_Volume())
            {
                MediaPlayer.Play(baihat);
            }
            khoinho1 = Content.Load<Texture2D>("Imgs/tetris-2");
            khoinho2 = Content.Load<Texture2D>("Imgs/tetris-3");
            khoinho3 = Content.Load<Texture2D>("Imgs/tetris-5");
            khoinho4 = Content.Load<Texture2D>("Imgs/tetris-1");
            khoinho5 = Content.Load<Texture2D>("Imgs/tetris-6");
            khoinho6 = Content.Load<Texture2D>("Imgs/tetris-8");

            toado_khoinho = new Vector2(365, 500);//128
            at_xoay = Content.Load<SoundEffect>("Music/rotate");
            at_thua = Content.Load<SoundEffect>("Music/lost");

            at_xuongnhanh = Content.Load<SoundEffect>("Music/fastdown");
            at_dichuyen = Content.Load<SoundEffect>("Music/down");
            at_levelUp = Content.Load<SoundEffect>("Music/levelup");
            //             at_dichuyen = Content.Load<SoundEffect>("Music/down");
            //             at_dichuyen.Play(); 
            sprifont = Content.Load<SpriteFont>("Capdo");
            hinhnen = Content.Load<Texture2D>("Imgs/bg");
            toado_hinhnen = new Vector2(0, 0);
            khungchoi = Content.Load<Texture2D>("Imgs/khung-new");
            toado_khungchoi = new Vector2(10, 0);
            khungcapdo = Content.Load<Texture2D>("Imgs/khung-capdo");
            toado_capdo = new Vector2(362, 228);
            khungdiem = Content.Load<Texture2D>("Imgs/khung-diem");
            toado_khungdiem = new Vector2(362, 340);
            //             btn_pause = Content.Load<Texture2D>("Imgs/nut-pause");
            toado_pause = new Vector2(368, 28);

            btn_xuongnhanh = Content.Load<Texture2D>("Imgs/nut-xuongnhanh");
            btn_xuongnhanh2 = Content.Load<Texture2D>("Imgs/nut-xuongnhanh-press");
            toado_xuongnhanh = new Vector2(390, 580);

            td_levelup = new Vector2(100, 300);
            levelup = Content.Load<Texture2D>("Imgs/levelup");
            /*    drawpause.LoadContent(Content);*/

            r_pause = new Rectangle((int)toado_pause.X, (int)toado_pause.Y, 75, 75);
            r_xuongnhanh = new Rectangle((int)toado_xuongnhanh.X, (int)toado_xuongnhanh.Y, 75, 75);
        }
        private Texture2D get_khoinho()
        {
            Texture2D t;
            t = khoinho1;
            if (Controller.CheckNote.Read_Block().Equals("2"))
            {
                t = khoinho1;
                return t;
            }
            if (Controller.CheckNote.Read_Block().Equals("3"))
            {
                t = khoinho2;
                return t;
            }
            if (Controller.CheckNote.Read_Block().Equals("5"))
            {
                t = khoinho3;
                return t;
            }
            if (Controller.CheckNote.Read_Block().Equals("1"))
            {
                t = khoinho4;
                return t;
            }
            if (Controller.CheckNote.Read_Block().Equals("6"))
            {
                t = khoinho5;
                return t;
            }
            if (Controller.CheckNote.Read_Block().Equals("8"))
            {
                t = khoinho6;
                return t;
            }
            return t;
        }

        public void Draw(SpriteBatch sp)
        {
            //sp.Begin();

            if (Controller.CheckNote.Read_Volume())
            {
                MediaPlayer.Resume();
            }

            sp.Draw(hinhnen, toado_hinhnen, Color.White);

            if (!IsXuongnhanh)
            {
                sp.Draw(khungchoi, new Vector2(10, 0), Color.White);
                Update_Matrix.Vector_Matran = new Vector2(0, 0);
            }
            else
            {
                second_nhay = second_nhay + 1;
                if (second_nhay <= 5)
                {
                    sp.Draw(khungchoi, new Vector2(10, 10), Color.White);
                    Update_Matrix.Vector_Matran = new Vector2(0, 10);
                }
                else if (second_nhay > 5)
                {
                    sp.Draw(khungchoi, new Vector2(10, 0), Color.White);
                    Update_Matrix.Vector_Matran = new Vector2(0, 0);
                    second_nhay = 0;
                    IsXuongnhanh = false;
                }
            }
            sp.Draw(khungcapdo, toado_capdo, Color.White);
            sp.Draw(khungdiem, toado_khungdiem, Color.White);
            //   sp.Draw(btn_pause, toado_pause, Color.White);
            if (!IsXuongnhanh)
            {
                sp.Draw(btn_xuongnhanh, toado_xuongnhanh, Color.White);
            }
            else
            {
                sp.Draw(btn_xuongnhanh2, toado_xuongnhanh, Color.White);
            }

            if (!Update_Matrix.IsGameOver)
            {
                Texture2D k;
                k = get_khoinho();
                for (int i = 0; i < 28; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        if (matrix_nho[i, j] == 1)
                        {
                            sp.Draw(k, /*new Vector2(37 + 5*30,7*30)13*/new Vector2(322 + j * 30 * 0.6f, 40 + 30 * i * 0.6f), new Microsoft.Xna.Framework.Rectangle(Update_Matrix.Im_Index2[0] * 30, 0, 30, 30), Color.White, 0f, new Vector2(0, 0), 0.6f, SpriteEffects.None, 0);
                        }
                    }
            }


        }
        public bool EndLeft()
        {
            bool IsEndLeft = false;
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0 && Update_Matrix.matrix[i, j] == 1
                        || j - 1 > 0 && Update_Matrix.matrix[i, j] == 1 && Update_Matrix.matrix[i, j - 1] == 3)
                    {
                        IsEndLeft = true;
                    }
                }
            return IsEndLeft;
        }
        public bool EndRight()
        {
            bool IsEndRight = false;
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (j == 9 && Update_Matrix.matrix[i, j] == 1
                        || j + 1 < 10 && Update_Matrix.matrix[i, j] == 1 && Update_Matrix.matrix[i, j + 1] == 3)
                    {
                        IsEndRight = true;
                    }
                }
            return IsEndRight;
        }
        public bool EndRow()
        {
            bool IsEndRow = false;
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (i == 27 && Update_Matrix.matrix[i, j] == 1
                        || Update_Matrix.matrix[i, j] == 1 && Update_Matrix.matrix[i + 1, j] == 3)
                    {
                        IsEndRow = true;
                    }
                }
            return IsEndRow;
        }
        private void getbong()
        {
            if (Controller.CheckNote.Read_Bong())
            {
                if (!EndRow())
                {
                    for (int m = 0; m < 28; m++)
                        for (int n = 0; n < 10; n++)
                        {
                            Update_Matrix.matrix_bong[m, n] = 0;
                            Update_Matrix.matrix_mau2[m, n] = -1;
                        }
                    int x0 = 0;
                    int xmax = 0;
                    int k0 = 28;
                    int khoangcach = 0;
                    //  int addJ = -1;
                    List<int> J = new List<int>();
                    List<int> I = new List<int>();
                    List<int> k_so = new List<int>();
                    int kmin = 0;
                    int imax = 0;
                    List<int> I_max = new List<int>();
                    J.Add(-1);
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                if (!IsAdd(J, j)) J.Add(j);
                            }
                        }
                    for (int k = 0; k < J.Count; k++)
                    {
                        if (J[k] < 0)
                        {
                            J.RemoveAt(k);
                        }
                    }
                    for (int j = 0; j < J.Count; j++)
                    {
                        for (int x = 0; x < 28; x++)
                        {
                            for (int m = 0; m < 28; m++)
                            {
                                if (Update_Matrix.matrix[m, J[j]] == 1)
                                {
                                    if (m >= xmax) xmax = m;
                                }
                            }
                            if (Update_Matrix.matrix[x, J[j]] == 1)
                            {
                                if (x >= x0) x0 = x;
                            }
                            if (Update_Matrix.matrix[x, J[j]] == 3)
                            {
                                if (x <= k0 && x > xmax) k0 = x;
                            }
                        }
                        I.Add(k0 - x0 - 1);
                        xmax = 0;
                        x0 = 0;
                        k0 = 28;
                    }
                    if (I.Count > 0)
                        khoangcach = I[0];
                    for (int i = 0; i < I.Count; i++)
                    {
                        if (I[i] <= khoangcach)
                        {
                            khoangcach = I[i];
                        }
                    }

                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix_bong[i + khoangcach, j] = 4;
                                Update_Matrix.matrix_mau2[i + khoangcach, j] = Update_Matrix.Im_Index[0];
                            }

                        }
                    k_so.Clear();
                    I_max.Clear();
                    // IsXuongnhanh = false;
                }
            }
        }
        public void DichTrai(int n)
        {
            if (!Update_Matrix.IsGameOver)
            {
                List<int> I_gh = new List<int>();// list cac hang cua khoi chua 1
                List<int> I_cot = new List<int>();// list cac cot cua khoi chua 1
                List<int> I_kc = new List<int>();// list khoang cach tu khoi 1 den khoi 3
                int maxy = 0;
                int khoangcach = 0;
                I_gh.Add(-1);
                I_cot.Add(-1);
                for (int i = 0; i < 28; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        if (Update_Matrix.matrix[i, j] == 1)
                        {
                            if (!IsAdd(I_gh, i)) I_gh.Add(i);
                        }

                    }
                for (int i = 0; i < 28; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        if (Update_Matrix.matrix[i, j] == 1)
                        {
                            if (!IsAdd(I_cot, j)) I_cot.Add(j);
                        }

                    }
                for (int k = 0; k < I_gh.Count; k++)
                {
                    if (I_gh[k] < 0)
                    {
                        I_gh.RemoveAt(k);
                    }
                }
                for (int k = 0; k < I_cot.Count; k++)
                {
                    if (I_cot[k] < 0)
                    {
                        I_cot.RemoveAt(k);
                    }
                }
                int x1 = 9;
                int k3 = -1;
                maxy = 0;
                for (int k = 0; k < I_cot.Count; k++)
                {
                    if (I_cot[k] >= maxy)
                    {
                        maxy = I_cot[k];
                    }
                }
                for (int i = 0; i < I_gh.Count; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (Update_Matrix.matrix[I_gh[i], j] == 1)
                        {
                            if (j <= x1) x1 = j;
                        }
                        if (j < maxy && Update_Matrix.matrix[I_gh[i], j] == 3)
                        {
                            if (j >= k3) k3 = j;
                        }
                    }
                    I_kc.Add(x1 - k3 - 1);
                    x1 = 9;
                    k3 = -1;
                }

                if (I_kc.Count > 0)
                    khoangcach = I_kc[0];
                for (int i = 0; i < I_kc.Count; i++)
                {
                    if (I_kc[i] <= khoangcach)
                    {
                        khoangcach = I_kc[i];
                    }
                }
                if (n >= khoangcach) gioihan_trai = true;
                if (n < khoangcach) gioihan_trai = false;
                if (!EndLeft() && !gioihan_trai)
                {
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix2[i, j - n] = 1;
                                Update_Matrix.matrix_mau[i, j - n] = Update_Matrix.Im_Index[0];
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix[i, j] = 0;
                                //  Update_Matrix.matrix_mau[i, j] = -1;
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (!Update_Matrix.IsEndRow)
                            {
                                Update_Matrix.matrix[i, j] = Update_Matrix.matrix2[i, j];
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix2[i, j] != 3)
                            {
                                Update_Matrix.matrix2[i, j] = 0;
                                // Update_Matrix.matrix_mau[i,j] = -1;
                            }
                        }
                    //     Update_Matrix.restart_mt(Update_Matrix.Im_Index[0]);
                    Hinhnen.StrButton = "";
                }
                else if (!EndLeft() && gioihan_trai)
                {
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix2[i, j - khoangcach] = 1;
                                Update_Matrix.matrix_mau[i, j - khoangcach] = Update_Matrix.Im_Index[0];
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix[i, j] = 0;
                                // Update_Matrix.matrix_mau[i, j] = -1;
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (!Update_Matrix.IsEndRow)
                            {
                                Update_Matrix.matrix[i, j] = Update_Matrix.matrix2[i, j];
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix2[i, j] != 3)
                            {
                                Update_Matrix.matrix2[i, j] = 0;
                                //Update_Matrix.matrix_mau[i, j] = -1;
                            }
                        }
                    //   Update_Matrix.restart_mt(Update_Matrix.Im_Index[0]);
                }
                gioihan_trai = false;
                getbong();
            }
        }
        public void DichPhai(int n)
        {
            if (!Update_Matrix.IsGameOver)
            {
                List<int> I_gh = new List<int>();// list cac cot cua khoi chua 1
                List<int> I_kc = new List<int>();// list khoang cach tu khoi 1 den khoi 3
                List<int> I_cot = new List<int>();// list cac cot cua khoi chua 1
                int khoangcach = 0;
                int miny = 9;
                I_gh.Add(-1);
                I_cot.Add(-1);
                for (int i = 0; i < 28; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        if (Update_Matrix.matrix[i, j] == 1)
                        {
                            if (!IsAdd(I_gh, i)) I_gh.Add(i);
                        }

                    }
                for (int i = 0; i < 28; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        if (Update_Matrix.matrix[i, j] == 1)
                        {
                            if (!IsAdd(I_cot, j)) I_cot.Add(j);
                        }

                    }
                for (int k = 0; k < I_gh.Count; k++)
                {
                    if (I_gh[k] < 0)
                    {
                        I_gh.RemoveAt(k);
                    }
                }
                for (int k = 0; k < I_cot.Count; k++)
                {
                    if (I_cot[k] < 0)
                    {
                        I_cot.RemoveAt(k);
                    }
                }
                int x1 = 0;
                int k3 = 10;
                miny = 9;
                for (int k = 0; k < I_cot.Count; k++)
                {
                    if (I_cot[k] <= miny)
                    {
                        miny = I_cot[k];
                    }
                }
                for (int i = 0; i < I_gh.Count; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (Update_Matrix.matrix[I_gh[i], j] == 1)
                        {
                            if (j >= x1) x1 = j;
                        }
                        if (j > miny && Update_Matrix.matrix[I_gh[i], j] == 3)
                        {
                            if (j <= k3) k3 = j;
                        }
                    }
                    I_kc.Add(k3 - x1 - 1);
                    x1 = 0;
                    k3 = 10;
                }

                if (I_kc.Count > 0)
                    khoangcach = I_kc[0];
                for (int i = 0; i < I_kc.Count; i++)
                {
                    if (I_kc[i] <= khoangcach)
                    {
                        khoangcach = I_kc[i];
                    }
                }
                if (n >= khoangcach) gioihan_phai = true;
                if (n < khoangcach) gioihan_phai = false;
                if (!EndRight() && !gioihan_phai)
                {
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix2[i, j + n] = 1;
                                Update_Matrix.matrix_mau[i, j + n] = Update_Matrix.Im_Index[0];
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix[i, j] = 0;
                                //    Update_Matrix.matrix_mau[i, j] = -1;
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (!Update_Matrix.IsEndRow)
                            {
                                Update_Matrix.matrix[i, j] = Update_Matrix.matrix2[i, j];

                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix2[i, j] != 3)
                            {
                                Update_Matrix.matrix2[i, j] = 0;
                                //   Update_Matrix.matrix_mau[i, j] = -1;
                            }
                        }
                    Hinhnen.StrButton = "";
                }
                else if (!EndRight() && gioihan_phai)
                {
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix2[i, j + khoangcach] = 1;
                                Update_Matrix.matrix_mau[i, j + khoangcach] = Update_Matrix.Im_Index[0];
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix[i, j] = 0;
                                //  Update_Matrix.matrix_mau[i, j] = -1;
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (!Update_Matrix.IsEndRow)
                            {
                                Update_Matrix.matrix[i, j] = Update_Matrix.matrix2[i, j];

                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix2[i, j] != 3)
                            {
                                Update_Matrix.matrix2[i, j] = 0;
                                //   Update_Matrix.matrix_mau[i, j] = -1;
                            }
                        }

                }
                gioihan_phai = false;
                getbong();
            }
        }
        public void Xuong(int n)
        {
            if (!Update_Matrix.IsGameOver)
            {
                if (!EndRow())
                {
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1 && i + n < 28)
                            {
                                Update_Matrix.matrix2[i + n, j] = 1;
                                Update_Matrix.matrix_mau[i + n, j] = Update_Matrix.Im_Index[0];
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix[i, j] = 0;
                                //   Update_Matrix.matrix_mau[i, j] = -1; 
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (!Update_Matrix.IsEndRow)
                            {
                                Update_Matrix.matrix[i, j] = Update_Matrix.matrix2[i, j];

                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix2[i, j] != 3)
                            {
                                Update_Matrix.matrix2[i, j] = 0;
                                //   Update_Matrix.matrix_mau[i, j] = -1; 
                            }
                        }
                    getbong();
                }
            }
        }
        public bool IsAdd(List<int> x, int y)
        {
            bool dung = false;
            for (int k = 0; k < x.Count; k++)
            {
                if (y == x[k])
                {
                    dung = true;
                }
            }
            return dung;
        }
        public void XuongNhanh()
        {
            if (!Update_Matrix.IsGameOver)
            {
                if (!EndRow())
                {
                    int x0 = 0;
                    int xmax = 0;
                    int k0 = 28;
                    int khoangcach = 0;
                    //  int addJ = -1;
                    List<int> J = new List<int>();
                    List<int> I = new List<int>();
                    List<int> k_so = new List<int>();
                    int kmin = 0;
                    int imax = 0;
                    List<int> I_max = new List<int>();
                    J.Add(-1);
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                if (!IsAdd(J, j)) J.Add(j);
                            }
                        }
                    for (int k = 0; k < J.Count; k++)
                    {
                        if (J[k] < 0)
                        {
                            J.RemoveAt(k);
                        }
                    }
                    for (int j = 0; j < J.Count; j++)
                    {
                        for (int x = 0; x < 28; x++)
                        {
                            for (int m = 0; m < 28; m++)
                            {
                                if (Update_Matrix.matrix[m, J[j]] == 1)
                                {
                                    if (m >= xmax) xmax = m;
                                }
                            }
                            if (Update_Matrix.matrix[x, J[j]] == 1)
                            {
                                if (x >= x0) x0 = x;
                            }
                            if (Update_Matrix.matrix[x, J[j]] == 3)
                            {
                                if (x <= k0 && x > xmax) k0 = x;
                            }
                        }
                        I.Add(k0 - x0 - 1);
                        xmax = 0;
                        x0 = 0;
                        k0 = 28;
                    }
                    if (I.Count > 0)
                        khoangcach = I[0];
                    for (int i = 0; i < I.Count; i++)
                    {
                        if (I[i] <= khoangcach)
                        {
                            khoangcach = I[i];
                        }
                    }

                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix2[i + khoangcach, j] = 3;
                                Update_Matrix.matrix_mau[i + khoangcach, j] = Update_Matrix.Im_Index[0];
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix[i, j] = 0;
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (!Update_Matrix.IsEndRow)
                            {
                                Update_Matrix.matrix[i, j] = Update_Matrix.matrix2[i, j];

                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix2[i, j] != 3)
                            {
                                Update_Matrix.matrix2[i, j] = 0;
                            }
                        }
                    Update_Matrix.IsEndRow = true;
                    k_so.Clear();
                    I_max.Clear();
                    // IsXuongnhanh = false;
                }
            }
        }
        public void Xoay()
        {

            if (!Update_Matrix.IsGameOver)
            {
                if (!EndRow())
                {
                    int imax = 0;
                    int jmin = 0;
                    int kieu_change = 0;
                    kieu_change = Update_Matrix.kt.kieu;
                    List<int> i_max = new List<int>();
                    List<int> j_min = new List<int>();
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                i_max.Add(i);
                            }
                        }
                    if (i_max.Count > 0)
                        imax = i_max[0];
                    for (int k = 0; k < i_max.Count; k++)
                    {
                        if (i_max[k] >= imax) imax = i_max[k];
                    }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[imax, j] == 1)
                            {
                                j_min.Add(j);
                            }
                        }
                    if (j_min.Count > 0)
                        jmin = j_min[0];
                    for (int u = 0; u < j_min.Count; u++)
                    {
                        if (j_min[u] <= jmin) jmin = j_min[u];
                    }

                    switch (kieu_change)
                    {
                        case 1:
                            Update_Matrix.kt.kieu = 2;
                            if (Update_Matrix.kt.Loai_Khoi == 1)
                            {
                                if (jmin != 8 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin + 2))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                                /* Update_Matrix.matrix_mau[i, j] = -1;*/
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin + 2);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin + 2);
                                }
                                if (jmin != 8 && !Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin + 2) && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin + 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin + 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin + 1);
                                }
                                if (jmin == 8 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin + 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin + 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin + 1);
                                }
                            }
                            else if (Update_Matrix.kt.Loai_Khoi == 2)
                            {
                                if (jmin != 1 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 2))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin - 2);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin - 2);
                                }
                                if (jmin != 1 && !Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 2) && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin - 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin - 1);
                                }
                                if (jmin == 1 && Update_Matrix.kt.Kiemtra_Khoitao(imax, 0))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, 0);
                                    Update_Matrix.kt.Khoitao_mau(imax, 0);
                                }
                            }
                            else if (Update_Matrix.kt.Loai_Khoi == 3)
                            {
                                if (jmin != 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin);
                                }
                                if (jmin != 0 && !Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin) && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin + 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin + 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin + 1);
                                }
                                if (jmin == 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax, 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, 1);
                                }
                            }
                            else
                                if (Update_Matrix.kt.Loai_Khoi == 4)
                                {
                                    if (jmin != 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 1, jmin - 1))
                                    {
                                        for (int i = 0; i < 28; i++)
                                            for (int j = 0; j < 10; j++)
                                            {
                                                if (Update_Matrix.matrix[i, j] == 1)
                                                {
                                                    Update_Matrix.matrix[i, j] = 0;
                                                }
                                            }
                                        Update_Matrix.kt.Khoitao_Khoi(imax - 1, jmin - 1);
                                        Update_Matrix.kt.Khoitao_mau(imax - 1, jmin - 1);
                                    }
                                    if (jmin != 0 && !Update_Matrix.kt.Kiemtra_Khoitao(imax - 1, jmin - 1) && Update_Matrix.kt.Kiemtra_Khoitao(imax - 1, jmin))
                                    {
                                        for (int i = 0; i < 28; i++)
                                            for (int j = 0; j < 10; j++)
                                            {
                                                if (Update_Matrix.matrix[i, j] == 1)
                                                {
                                                    Update_Matrix.matrix[i, j] = 0;
                                                }
                                            }
                                        Update_Matrix.kt.Khoitao_Khoi(imax - 1, jmin);
                                        Update_Matrix.kt.Khoitao_mau(imax - 1, jmin);
                                    }
                                    if (jmin == 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 1, 0))
                                    {
                                        for (int i = 0; i < 28; i++)
                                            for (int j = 0; j < 10; j++)
                                            {
                                                if (Update_Matrix.matrix[i, j] == 1)
                                                {
                                                    Update_Matrix.matrix[i, j] = 0;
                                                }
                                            }
                                        Update_Matrix.kt.Khoitao_Khoi(imax - 1, 0);
                                        Update_Matrix.kt.Khoitao_mau(imax - 1, 0);
                                    }
                                }
                                else
                                    if (Update_Matrix.kt.Loai_Khoi == 6)
                                    {
                                        if (jmin != 8 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin))
                                        {
                                            for (int i = 0; i < 28; i++)
                                                for (int j = 0; j < 10; j++)
                                                {
                                                    if (Update_Matrix.matrix[i, j] == 1)
                                                    {
                                                        Update_Matrix.matrix[i, j] = 0;
                                                    }
                                                }
                                            Update_Matrix.kt.Khoitao_Khoi(imax, jmin);
                                            Update_Matrix.kt.Khoitao_mau(imax, jmin);
                                        }
                                        if (jmin == 8 && Update_Matrix.kt.Kiemtra_Khoitao(imax, 9))
                                        {
                                            for (int i = 0; i < 28; i++)
                                                for (int j = 0; j < 10; j++)
                                                {
                                                    if (Update_Matrix.matrix[i, j] == 1)
                                                    {
                                                        Update_Matrix.matrix[i, j] = 0;
                                                    }
                                                }
                                            Update_Matrix.kt.Khoitao_Khoi(imax, 9);
                                            Update_Matrix.kt.Khoitao_mau(imax, 9);
                                        }
                                    }
                                    else
                                        if (Update_Matrix.kt.Loai_Khoi == 7)
                                        {
                                            if (jmin >= 2 && jmin != 9 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 3, jmin - 2))
                                            {
                                                for (int i = 0; i < 28; i++)
                                                    for (int j = 0; j < 10; j++)
                                                    {
                                                        if (Update_Matrix.matrix[i, j] == 1)
                                                        {
                                                            Update_Matrix.matrix[i, j] = 0;
                                                        }
                                                    }
                                                Update_Matrix.kt.Khoitao_Khoi(imax - 3, jmin - 2);
                                                Update_Matrix.kt.Khoitao_mau(imax - 3, jmin - 2);
                                            }
                                            if (jmin >= 2 && jmin != 9 && !Update_Matrix.kt.Kiemtra_Khoitao(imax - 3, jmin - 2) && Update_Matrix.kt.Kiemtra_Khoitao(imax - 3, jmin - 3))
                                            {
                                                for (int i = 0; i < 28; i++)
                                                    for (int j = 0; j < 10; j++)
                                                    {
                                                        if (Update_Matrix.matrix[i, j] == 1)
                                                        {
                                                            Update_Matrix.matrix[i, j] = 0;
                                                        }
                                                    }
                                                Update_Matrix.kt.Khoitao_Khoi(imax - 3, jmin - 3);
                                                Update_Matrix.kt.Khoitao_mau(imax - 3, jmin - 3);
                                            }
                                            if (jmin == 1 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 3, 0) || jmin == 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 3, 0))
                                            {
                                                for (int i = 0; i < 28; i++)
                                                    for (int j = 0; j < 10; j++)
                                                    {
                                                        if (Update_Matrix.matrix[i, j] == 1)
                                                        {
                                                            Update_Matrix.matrix[i, j] = 0;
                                                        }
                                                    }
                                                Update_Matrix.kt.Khoitao_Khoi(imax - 3, 0);
                                                Update_Matrix.kt.Khoitao_mau(imax - 3, 0);
                                            }
                                            if (jmin == 9 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 3, 6))
                                            {
                                                for (int i = 0; i < 28; i++)
                                                    for (int j = 0; j < 10; j++)
                                                    {
                                                        if (Update_Matrix.matrix[i, j] == 1)
                                                        {
                                                            Update_Matrix.matrix[i, j] = 0;
                                                        }
                                                    }
                                                Update_Matrix.kt.Khoitao_Khoi(imax - 3, 6);
                                                Update_Matrix.kt.Khoitao_mau(imax - 3, 6);
                                            }
                                        }
                            // kt.kieu = 2;
                            break;
                        // return;
                        case 2:
                            Update_Matrix.kt.kieu = 3;
                            if (Update_Matrix.kt.Loai_Khoi == 1)
                            {
                                if (Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin - 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin - 1);
                                }
                            }
                            else if (Update_Matrix.kt.Loai_Khoi == 2)
                            {
                                if (jmin != 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin + 2))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin + 2);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin + 2);
                                }
                                if (jmin != 0 && !Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin) && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin + 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin + 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin + 1);
                                }
                                if (jmin == 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax, 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, 1);
                                }
                            }
                            else if (Update_Matrix.kt.Loai_Khoi == 3)
                            {
                                if (jmin != 1 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin);
                                }
                                if (jmin != 1 && !Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 2) && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin - 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin - 1);
                                }
                                if (jmin == 1 && Update_Matrix.kt.Kiemtra_Khoitao(imax, 0))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, 0);
                                    Update_Matrix.kt.Khoitao_mau(imax, 0);
                                }
                            }
                            if (Update_Matrix.kt.Loai_Khoi == 4)
                            {
                                if (jmin != 7 && Update_Matrix.kt.Kiemtra_Khoitao(imax + 1, jmin + 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax + 1, jmin + 1);
                                    Update_Matrix.kt.Khoitao_mau(imax + 1, jmin + 1);
                                }
                                if (jmin != 7 && !Update_Matrix.kt.Kiemtra_Khoitao(imax + 1, jmin + 3) && Update_Matrix.kt.Kiemtra_Khoitao(imax + 1, jmin + 2))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax + 1, jmin + 2);
                                    Update_Matrix.kt.Khoitao_mau(imax + 1, jmin + 2);
                                }
                                if (jmin == 7 && Update_Matrix.kt.Kiemtra_Khoitao(imax + 1, 9))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax + 1, 9);
                                    Update_Matrix.kt.Khoitao_mau(imax + 1, 9);
                                }
                            }
                            else
                                if (Update_Matrix.kt.Loai_Khoi == 6)
                                {
                                    if (jmin != 9 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 1, jmin - 1))
                                    {
                                        for (int i = 0; i < 28; i++)
                                            for (int j = 0; j < 10; j++)
                                            {
                                                if (Update_Matrix.matrix[i, j] == 1)
                                                {
                                                    Update_Matrix.matrix[i, j] = 0;
                                                }
                                            }
                                        Update_Matrix.kt.Khoitao_Khoi(imax - 1, jmin - 1);
                                        Update_Matrix.kt.Khoitao_mau(imax - 1, jmin - 1);
                                    }
                                    if (jmin != 9 && !Update_Matrix.kt.Kiemtra_Khoitao(imax - 1, jmin - 1) && Update_Matrix.kt.Kiemtra_Khoitao(imax - 1, jmin - 2))
                                    {
                                        for (int i = 0; i < 28; i++)
                                            for (int j = 0; j < 10; j++)
                                            {
                                                if (Update_Matrix.matrix[i, j] == 1)
                                                {
                                                    Update_Matrix.matrix[i, j] = 0;
                                                }
                                            }
                                        Update_Matrix.kt.Khoitao_Khoi(imax - 1, jmin - 2);
                                        Update_Matrix.kt.Khoitao_mau(imax - 1, jmin - 2);
                                    }
                                    if (jmin == 9 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 1, 7))
                                    {
                                        for (int i = 0; i < 28; i++)
                                            for (int j = 0; j < 10; j++)
                                            {
                                                if (Update_Matrix.matrix[i, j] == 1)
                                                {
                                                    Update_Matrix.matrix[i, j] = 0;
                                                }
                                            }
                                        Update_Matrix.kt.Khoitao_Khoi(imax - 1, 7);
                                        Update_Matrix.kt.Khoitao_mau(imax - 1, 7);
                                    }
                                }
                                else
                                    if (Update_Matrix.kt.Loai_Khoi == 7)
                                    {
                                        if (Update_Matrix.kt.Kiemtra_Khoitao(imax + 3, jmin + 2))
                                        {
                                            for (int i = 0; i < 28; i++)
                                                for (int j = 0; j < 10; j++)
                                                {
                                                    if (Update_Matrix.matrix[i, j] == 1)
                                                    {
                                                        Update_Matrix.matrix[i, j] = 0;
                                                    }
                                                }
                                            Update_Matrix.kt.Khoitao_Khoi(imax + 3, jmin + 2);
                                            Update_Matrix.kt.Khoitao_mau(imax + 3, jmin + 2);
                                        }
                                    }
                            break;
                        case 3:
                            Update_Matrix.kt.kieu = 4;
                            if (Update_Matrix.kt.Loai_Khoi == 1)
                            {
                                if (jmin != 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 1, jmin - 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax - 1, jmin - 1);
                                    Update_Matrix.kt.Khoitao_mau(imax - 1, jmin - 1);
                                }
                                if (jmin != 0 && !Update_Matrix.kt.Kiemtra_Khoitao(imax - 1, jmin - 1) && Update_Matrix.kt.Kiemtra_Khoitao(imax - 1, jmin))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax - 1, jmin);
                                    Update_Matrix.kt.Khoitao_mau(imax - 1, jmin);
                                }
                                if (jmin == 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 1, jmin))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax - 1, jmin);
                                    Update_Matrix.kt.Khoitao_mau(imax - 1, jmin);
                                }
                            }
                            else if (Update_Matrix.kt.Loai_Khoi == 2)
                            {
                                if (jmin != 1 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 2))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin - 2);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin - 2);
                                }
                                if (jmin != 1 && !Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 2) && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin - 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin - 1);
                                }
                                if (jmin == 1 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin - 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin - 1);
                                }
                            }
                            else if (Update_Matrix.kt.Loai_Khoi == 3)
                            {
                                if (jmin != 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin);
                                }
                                if (jmin != 0 && !Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin) && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin + 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin + 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin + 1);
                                }
                                if (jmin == 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax, 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, 1);
                                }
                            }
                            if (Update_Matrix.kt.Loai_Khoi == 4)
                            {
                                if (jmin != 9 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin - 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin - 1);
                                }
                                if (jmin != 9 && !Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 1) && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 2))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin - 2);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin - 2);
                                }
                                if (jmin == 9 && Update_Matrix.kt.Kiemtra_Khoitao(imax, 7))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, 7);
                                    Update_Matrix.kt.Khoitao_mau(imax, 7);
                                }
                            }
                            else
                                if (Update_Matrix.kt.Loai_Khoi == 6)
                                {
                                    if (jmin != 0 && jmin != 7 && Update_Matrix.kt.Kiemtra_Khoitao(imax + 1, jmin + 1))
                                    {
                                        for (int i = 0; i < 28; i++)
                                            for (int j = 0; j < 10; j++)
                                            {
                                                if (Update_Matrix.matrix[i, j] == 1)
                                                {
                                                    Update_Matrix.matrix[i, j] = 0;
                                                }
                                            }
                                        Update_Matrix.kt.Khoitao_Khoi(imax + 1, jmin + 1);
                                        Update_Matrix.kt.Khoitao_mau(imax + 1, jmin + 1);
                                    }
                                    if (jmin == 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax + 1, 1))
                                    {
                                        for (int i = 0; i < 28; i++)
                                            for (int j = 0; j < 10; j++)
                                            {
                                                if (Update_Matrix.matrix[i, j] == 1)
                                                {
                                                    Update_Matrix.matrix[i, j] = 0;
                                                }
                                            }
                                        Update_Matrix.kt.Khoitao_Khoi(imax + 1, 1);
                                        Update_Matrix.kt.Khoitao_mau(imax + 1, 1);
                                    }
                                    if (jmin == 7 && Update_Matrix.kt.Kiemtra_Khoitao(imax + 1, 8))
                                    {
                                        for (int i = 0; i < 28; i++)
                                            for (int j = 0; j < 10; j++)
                                            {
                                                if (Update_Matrix.matrix[i, j] == 1)
                                                {
                                                    Update_Matrix.matrix[i, j] = 0;
                                                }
                                            }
                                        Update_Matrix.kt.Khoitao_Khoi(imax + 1, 8);
                                        Update_Matrix.kt.Khoitao_mau(imax + 1, 8);
                                    }
                                }
                                else
                                    if (Update_Matrix.kt.Loai_Khoi == 7)
                                    {
                                        if (jmin >= 2 && jmin != 9 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 3, jmin - 2))
                                        {
                                            for (int i = 0; i < 28; i++)
                                                for (int j = 0; j < 10; j++)
                                                {
                                                    if (Update_Matrix.matrix[i, j] == 1)
                                                    {
                                                        Update_Matrix.matrix[i, j] = 0;
                                                    }
                                                }
                                            Update_Matrix.kt.Khoitao_Khoi(imax - 3, jmin - 2);
                                            Update_Matrix.kt.Khoitao_mau(imax - 3, jmin - 2);
                                        }
                                        if (jmin >= 2 && jmin != 9 && !Update_Matrix.kt.Kiemtra_Khoitao(imax - 3, jmin - 2) && Update_Matrix.kt.Kiemtra_Khoitao(imax - 3, jmin - 3))
                                        {
                                            for (int i = 0; i < 28; i++)
                                                for (int j = 0; j < 10; j++)
                                                {
                                                    if (Update_Matrix.matrix[i, j] == 1)
                                                    {
                                                        Update_Matrix.matrix[i, j] = 0;
                                                    }
                                                }
                                            Update_Matrix.kt.Khoitao_Khoi(imax - 3, jmin - 3);
                                            Update_Matrix.kt.Khoitao_mau(imax - 3, jmin - 3);
                                        }
                                        if (jmin == 1 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 3, 0) || jmin == 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 3, 0))
                                        {
                                            for (int i = 0; i < 28; i++)
                                                for (int j = 0; j < 10; j++)
                                                {
                                                    if (Update_Matrix.matrix[i, j] == 1)
                                                    {
                                                        Update_Matrix.matrix[i, j] = 0;
                                                    }
                                                }
                                            Update_Matrix.kt.Khoitao_Khoi(imax - 3, 0);
                                            Update_Matrix.kt.Khoitao_mau(imax - 3, 0);
                                        }
                                        if (jmin == 9 && Update_Matrix.kt.Kiemtra_Khoitao(imax - 3, 6))
                                        {
                                            for (int i = 0; i < 28; i++)
                                                for (int j = 0; j < 10; j++)
                                                {
                                                    if (Update_Matrix.matrix[i, j] == 1)
                                                    {
                                                        Update_Matrix.matrix[i, j] = 0;
                                                    }
                                                }
                                            Update_Matrix.kt.Khoitao_Khoi(imax - 3, 6);
                                            Update_Matrix.kt.Khoitao_mau(imax - 3, 6);
                                        }
                                    }
                            break;
                        case 4:
                            Update_Matrix.kt.kieu = 1;
                            if (Update_Matrix.kt.Loai_Khoi == 1)
                            {
                                if (Update_Matrix.kt.Kiemtra_Khoitao(imax + 1, jmin))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax + 1, jmin);
                                    Update_Matrix.kt.Khoitao_mau(imax + 1, jmin);
                                }
                            }
                            else if (Update_Matrix.kt.Loai_Khoi == 2)
                            {
                                if (jmin != 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin + 2))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin + 2);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin + 2);
                                }
                                if (jmin != 0 && !Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin) && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin + 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin + 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin + 1);
                                }
                                if (jmin == 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax, 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, 1);
                                }
                            }
                            else if (Update_Matrix.kt.Loai_Khoi == 3)
                            {
                                if (jmin != 1 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin);
                                }
                                if (jmin != 1 && !Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 2) && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin - 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin - 1);
                                }
                                if (jmin == 1 && Update_Matrix.kt.Kiemtra_Khoitao(imax, 0))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, 0);
                                    Update_Matrix.kt.Khoitao_mau(imax, 0);
                                }
                            }
                            if (Update_Matrix.kt.Loai_Khoi == 4)
                            {
                                if (jmin != 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin + 1))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin + 1);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin + 1);
                                }
                                if (jmin != 0 && !Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin - 1) && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, jmin);
                                    Update_Matrix.kt.Khoitao_mau(imax, jmin);
                                }
                                if (jmin == 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax, 0))
                                {
                                    for (int i = 0; i < 28; i++)
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (Update_Matrix.matrix[i, j] == 1)
                                            {
                                                Update_Matrix.matrix[i, j] = 0;
                                            }
                                        }
                                    Update_Matrix.kt.Khoitao_Khoi(imax, 0);
                                    Update_Matrix.kt.Khoitao_mau(imax, 0);
                                }
                            }
                            else
                                if (Update_Matrix.kt.Loai_Khoi == 6)
                                {
                                    if (jmin != 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin))
                                    {
                                        for (int i = 0; i < 28; i++)
                                            for (int j = 0; j < 10; j++)
                                            {
                                                if (Update_Matrix.matrix[i, j] == 1)
                                                {
                                                    Update_Matrix.matrix[i, j] = 0;
                                                }
                                            }
                                        Update_Matrix.kt.Khoitao_Khoi(imax, jmin);
                                        Update_Matrix.kt.Khoitao_mau(imax, jmin);
                                    }
                                    if (jmin != 0 && !Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin) && Update_Matrix.kt.Kiemtra_Khoitao(imax, jmin + 1))
                                    {
                                        for (int i = 0; i < 28; i++)
                                            for (int j = 0; j < 10; j++)
                                            {
                                                if (Update_Matrix.matrix[i, j] == 1)
                                                {
                                                    Update_Matrix.matrix[i, j] = 0;
                                                }
                                            }
                                        Update_Matrix.kt.Khoitao_Khoi(imax, jmin + 1);
                                        Update_Matrix.kt.Khoitao_mau(imax, jmin + 1);
                                    }
                                    if (jmin == 0 && Update_Matrix.kt.Kiemtra_Khoitao(imax, 1))
                                    {
                                        for (int i = 0; i < 28; i++)
                                            for (int j = 0; j < 10; j++)
                                            {
                                                if (Update_Matrix.matrix[i, j] == 1)
                                                {
                                                    Update_Matrix.matrix[i, j] = 0;
                                                }
                                            }
                                        Update_Matrix.kt.Khoitao_Khoi(imax, 1);
                                        Update_Matrix.kt.Khoitao_mau(imax, 1);
                                    }
                                }
                                else
                                    if (Update_Matrix.kt.Loai_Khoi == 7)
                                    {
                                        if (Update_Matrix.kt.Kiemtra_Khoitao(imax + 3, jmin + 2))
                                        {
                                            for (int i = 0; i < 28; i++)
                                                for (int j = 0; j < 10; j++)
                                                {
                                                    if (Update_Matrix.matrix[i, j] == 1)
                                                    {
                                                        Update_Matrix.matrix[i, j] = 0;
                                                    }
                                                }
                                            Update_Matrix.kt.Khoitao_Khoi(imax + 3, jmin + 2);
                                            Update_Matrix.kt.Khoitao_mau(imax + 3, jmin + 2);
                                        }
                                    }
                            break;
                    }
                    i_max.Clear();
                    j_min.Clear();
                }
                getbong();
            }
        }
        public void Update(GameTimer gameTime)
        {
            if (!Update_Matrix.IsGameOver)
            {
                Update_Matrix.IsGameOver = Update_Matrix.EndGame();
            }
            else
            {
                if (!Isphatnhac)
                {
                    if (Controller.CheckNote.Read_Volume())
                    {
                        at_thua.Play();
                        Isphatnhac = true;
                    }
                }
            }
            if (!Update_Matrix.IsGameOver)
            {
                if (!IsPause)
                {
                    TouchCollection touchs = TouchPanel.GetState();
                    foreach (TouchLocation touch in touchs)
                    {
                        if (touch.State == TouchLocationState.Pressed)
                        {
                            start = touch.Position;
                            moved = start;
                            count = 0;
                        }
                        if (touch.State == TouchLocationState.Moved)
                        {
                            count++;
                            if (touch.Position.X - moved.X > 15 && touch.Position.Y - moved.Y < 15)
                            {
                                DichPhai(1);
                                if (Controller.CheckNote.Read_Volume())
                                {
                                    at_dichuyen.Play();
                                }
                                moved = touch.Position;
                            }
                            else if (moved.X - touch.Position.X > 15 && moved.Y - touch.Position.Y < 15)
                            {
                                DichTrai(1);
                                if (Controller.CheckNote.Read_Volume())
                                {
                                    at_dichuyen.Play();
                                }
                                moved = touch.Position;
                            }
                            else
                            {
                                if (touch.Position.Y - moved.Y > 13)
                                {
                                    Xuong(1);
                                    if (Controller.CheckNote.Read_Volume())
                                    {
                                        at_dichuyen.Play();
                                    }
                                    moved = touch.Position;
                                }
                            }
                            //                             double k = Math.Sqrt((touch.Position.X - moved.X) * (touch.Position.X - moved.X) + (touch.Position.Y - moved.Y) * (touch.Position.Y - moved.Y));
                            //                             if (touch.Position.X < moved.X && k > 63.6)
                            //                             {
                            //                                 DichTrai(1);
                            //                                 moved = touch.Position;
                            //                             }
                            //                             if (touch.Position.X > moved.X && k > 63.6)
                            //                             {
                            //                                 DichPhai(1);
                            //                                 moved = touch.Position;
                            //                             }

                        }
                        if (touch.State == TouchLocationState.Released)
                        {
                            if (r_xuongnhanh.Contains((int)touch.Position.X, (int)touch.Position.Y))
                            {
                                IsXuongnhanh = true;
                                XuongNhanh();
                                if (Controller.CheckNote.Read_Volume())
                                {
                                    at_xuongnhanh.Play();
                                }
                            }
                            else
                                if (r_pause.Contains((int)touch.Position.X, (int)touch.Position.Y))
                                {
                                    /*  IsPause = true;*/
                                    /*MessageBox.Show("OK");*/
                                }
                                else
                                {
                                    stop.X = touch.Position.X;
                                    stop.Y = touch.Position.Y;
                                    if (Vector2.Distance(stop, start) < 10)
                                    {
                                        Xoay();
                                        if (Controller.CheckNote.Read_Volume())
                                        {
                                            at_xoay.Play();
                                        }
                                    }
                                    double u = Math.Sqrt((stop.X - moved.X) * (stop.X - moved.X) + (stop.Y - moved.Y) * (stop.Y - moved.Y));
                                    if (count > 20 && (stop.Y - start.Y)/ ((count / 30) < 1 ? 1 : count / 30) > 60 && u< 63.6)
                                    {
                                        IsXuongnhanh = true;
                                        XuongNhanh();
                                        if (Controller.CheckNote.Read_Volume())
                                        {
                                            at_xuongnhanh.Play();
                                        }
                                    }
                                     
                                    //                                     if ((count > 20 && (stop.Y - start.Y) / ((count / 30) < 0.5 ? 0.5 : count / 30) > 90 && ((stop.X - start.X) < 15))  || (count > 20 && (stop.Y - start.Y) / ((count / 30) < 0.5 ? 0.5 : count / 30) > 90 && ((start.X - stop.X) < 15)))
                                    //                                     {
                                    //                                         IsXuongnhanh = true;
                                    //                                         XuongNhanh();
                                    //                                         if (Controller.CheckNote.Read_Volume())
                                    //                                         {
                                    //                                             at_xuongnhanh.Play();
                                    //                                         }
                                    //                                     }
                                }
                        }


                    }
                }
                else
                {

                }
            }
            else
            {
                for (int i = 0; i < 28; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        Update_Matrix.matrix_bong[i, j] = 0;

                    }
            }

        }

    }
}
