using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Navigation;

namespace GameXepHinh.Controller
{
    class Update_Matrix
    {
        Texture2D khoi1;
        Texture2D khoi2;
        Texture2D khoi3;
        Texture2D khoi4;
        Texture2D khoi5;
        Texture2D khoi6;
        Vector2 toado_khoi;
        Vector2 toado_khoi2;
        Vector2 toado_khoi3;
        Vector2 toado_khoi4;
        Texture2D gameover;
        Vector2 td_gameover;
        Vector2 td_gameover2;
        SoundEffect at_dichuyen;
        SoundEffect at_xoa;
        SoundEffect at_thua;
        Texture2D levelup;
        Vector2 td_levelup;
        bool IsDrawLevel = false;
       /* bool Isphatnhac = false;*/
        public static int[,] matrix = new int[28, 10];
        public static int[,] matrix2 = new int[28, 10];
        public static int[,] matrix3 = new int[28, 10];
        public static int[,] matrix_mau = new int[28, 10];
        public static int[,] matrix_bong = new int[28, 10];
        public static int[,] matrix_mau2 = new int[28, 10];
        List<int> k_hang = new List<int>();
        int I_gameover = 0;
        int mang_mau = 0;
        SpriteFont sprifont;
        SoundEffect at_levelUp;
        public static Khoitao kt = new Khoitao();
        public static bool IsEndRow = false;
        public static bool IsDaChay = false;
        public static bool IsGameOver = false;
        bool IsEndKhoi = false;
        List<int> List_kieu = new List<int>();
        List<int> List_khoi = new List<int>();
        public static List<int> Im_Index = new List<int>();
        public static List<int> Im_Index2 = new List<int>();
        int second = 0;
        int second1 = 0;
        int count_hang = 0;
        int Y_khoixoa = 0;
        public static Vector2 Vector_Matran = new Vector2(0, 0);
        public static bool IsDelete = false;
        public static void restart_mt(int mau)
        {
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (matrix2[i, j] != 3)
                    {
                        matrix_mau[i, j] = -1;
                    }
                }
            //sp.Begin();
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (matrix2[i, j] == 1)
                    {
                        matrix_mau[i, j] = mau;
                    }
                    if (matrix2[i, j] == 0)
                    {
                        matrix_mau[i, j] = -1;
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
                        || Update_Matrix.matrix[i, j] == 1 && Update_Matrix.matrix[i, j - 1] == 3)
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
            bool IsEndRow1 = false;
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (i == 27 && Update_Matrix.matrix[i, j] == 1
                        || Update_Matrix.matrix[i, j] == 1 && Update_Matrix.matrix[i + 1, j] == 3)
                    {
                        IsEndRow1 = true;
                    }
                }
            return IsEndRow1;
        }
        public static bool EndGame()
        {
            for (int j = 0; j < 10; j++)
            {
                if (Update_Matrix.matrix[5, j] == 3)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsXoay(int x, int y)
        {
            bool IsXoay = false;
            int Now_kieu = 0;
            Now_kieu = kt.kieu;
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    switch (Now_kieu)
                    {
                        case 1: kt.kieu = 2;
                            //     kt.Khoitao_KhoiL(x);
                            break;
                        case 2: break;
                    }
                }
            return IsXoay;
        }
        //         public void LoadContent2(ContentManager Content)
        //         {
        //             khoi = Content.Load<Texture2D>("Imgs/tetris-" + Controller.CheckNote.Read_Block());
        //           //  toado_khoi = new Vector2(280, 400);
        //         }
        public void LoadContent1(ContentManager Content)
        {
            //             for (int i = 0; i < 28; i++)
            //                 for (int j = 0; j < 10; j++)
            //                 {
            //                     matrix_mau[i, j] = -1;
            //                 }
            //             for (int i = 0; i < 28; i++)
            //                 for (int j = 0; j < 10; j++)
            //                 {
            //                     matrix_mau2[i, j] = -1;
            //                 }
            at_levelUp = Content.Load<SoundEffect>("Music/levelup");
            sprifont = Content.Load<SpriteFont>("Capdo");
            td_levelup = new Vector2(100, 300);
            levelup = Content.Load<Texture2D>("Imgs/levelup");
            at_dichuyen = Content.Load<SoundEffect>("Music/down");
            at_xoa = Content.Load<SoundEffect>("Music/delete");
            at_thua = Content.Load<SoundEffect>("Music/lost");
            // at_dichuyen.Play();
            /*    khoi = Content.Load<Texture2D>("Imgs/tetris-"+ Controller.CheckNote.Read_Block());*/
            khoi1 = Content.Load<Texture2D>("Imgs/tetris-2");
            khoi2 = Content.Load<Texture2D>("Imgs/tetris-3");
            khoi3 = Content.Load<Texture2D>("Imgs/tetris-5");
            khoi4 = Content.Load<Texture2D>("Imgs/tetris-1");
            khoi5 = Content.Load<Texture2D>("Imgs/tetris-6");
            khoi6 = Content.Load<Texture2D>("Imgs/tetris-8");

            toado_khoi = new Vector2(280, 400);
            toado_khoi2 = new Vector2(150, 400);
            toado_khoi3 = new Vector2(100, 400);
            toado_khoi4 = new Vector2(40, 400);
            td_gameover = new Vector2(35, 280);
            gameover = Content.Load<Texture2D>("Imgs/gameover");
        }
        public void LoadContent(ContentManager Content)
        {
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    matrix_mau[i, j] = -1;
                }
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    matrix_mau2[i, j] = -1;
                }
            at_levelUp = Content.Load<SoundEffect>("Music/levelup");
            sprifont = Content.Load<SpriteFont>("Capdo");
            td_levelup = new Vector2(100, 300);
            levelup = Content.Load<Texture2D>("Imgs/levelup");
            at_dichuyen = Content.Load<SoundEffect>("Music/down");
            at_xoa = Content.Load<SoundEffect>("Music/delete");
            at_thua = Content.Load<SoundEffect>("Music/lost");
            // at_dichuyen.Play();
            /*    khoi = Content.Load<Texture2D>("Imgs/tetris-"+ Controller.CheckNote.Read_Block());*/
            khoi1 = Content.Load<Texture2D>("Imgs/tetris-2");
            khoi2 = Content.Load<Texture2D>("Imgs/tetris-3");
            khoi3 = Content.Load<Texture2D>("Imgs/tetris-5");
            khoi4 = Content.Load<Texture2D>("Imgs/tetris-1");
            khoi5 = Content.Load<Texture2D>("Imgs/tetris-6");
            khoi6 = Content.Load<Texture2D>("Imgs/tetris-8");

            toado_khoi = new Vector2(280, 400);
            toado_khoi2 = new Vector2(150, 400);
            toado_khoi3 = new Vector2(100, 400);
            toado_khoi4 = new Vector2(40, 400);
            td_gameover = new Vector2(0, 280);//35
            td_gameover2 = new Vector2(500, 280);//35
            gameover = Content.Load<Texture2D>("Imgs/gameover");
            //   kt.New_KhoiL();
            //  kt.kieu = 1;

            DateTime de = DateTime.Now;
            /*  kt.kieu = (de.Hour + de.Minute + de.Second) % 4 + 1;*/
            Random rd = new Random();
            kt.kieu = rd.Next(1, 1000) % 4 + 1;
            kt.Loai_Khoi = rd.Next(1, 1000) % 7 + 1;
            int mau = rd.Next(1, 1000) % 6 + 1;
            mang_mau = mau;
            kt.Khoitao_Khoi(4, 4);
            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (Update_Matrix.matrix[i, j] == 1)
                    {
                        matrix_mau[i, j] = mang_mau;
                    }
                }
            Im_Index.Add(mau);

            // toado_khoi = new Vector2(390, 580);
        }
        private Texture2D get_khoinho()
        {
            Texture2D t;
            t = khoi1;
            if (Controller.CheckNote.Read_Block().Equals("2"))
            {
                t = khoi1;
                return t;
            }
            if (Controller.CheckNote.Read_Block().Equals("3"))
            {
                t = khoi2;
                return t;
            }
            if (Controller.CheckNote.Read_Block().Equals("5"))
            {
                t = khoi3;
                return t;
            }
            if (Controller.CheckNote.Read_Block().Equals("1"))
            {
                t = khoi4;
                return t;
            }
            if (Controller.CheckNote.Read_Block().Equals("6"))
            {
                t = khoi5;
                return t;
            }
            if (Controller.CheckNote.Read_Block().Equals("8"))
            {
                t = khoi6;
                return t;
            }
            return t;
        }
        public void DrawLevel(SpriteBatch sp)
        {

            if (Hinhnen.diem == 0)
            {
                sp.DrawString(sprifont, Hinhnen.diem.ToString(), new Vector2(410, 380), Color.White);
            }
            else
                sp.DrawString(sprifont, Hinhnen.diem.ToString(), new Vector2(397, 380), Color.White);
            if (Hinhnen.diem < 200)
            {
                Hinhnen.level = 1;
                sp.DrawString(sprifont, Hinhnen.level.ToString(), new Vector2(410, 270), Color.White);
                return;
            }
            if (Hinhnen.diem >= 200 && Hinhnen.diem < 790)
            {
                if (!IsDrawLevel)
                {
                    second1 = second1 + 1;
                    if (second1 < 40)
                    {
                        at_levelUp.Play();
                        sp.Draw(levelup, td_levelup, Color.White);
                        /*second1 = 0;*/
                    }
                }
                if (second1 == 40)
                {
                    IsDrawLevel = true;
                    second1 = 0;
                }
                Hinhnen.level = 2;
                sp.DrawString(sprifont, Hinhnen.level.ToString(), new Vector2(410, 270), Color.White);
                return;
            }
            if (Hinhnen.diem >= 790 && Hinhnen.diem < 1430)
            {
                if (IsDrawLevel)
                {
                    second1 = second1 + 1;

                    if (second1 < 40)
                    {
                        at_levelUp.Play();

                        sp.Draw(levelup, td_levelup, Color.White);
                        /*second1 = 0;*/
                    }
                }
                if (second1 == 40) { IsDrawLevel = false; second1 = 0; }
                Hinhnen.level = 3;
                sp.DrawString(sprifont, Hinhnen.level.ToString(), new Vector2(410, 270), Color.White);
                return;
            }
            if (Hinhnen.diem >= 1430 && Hinhnen.diem < 2240)
            {

                if (!IsDrawLevel)
                {
                    second1 = second1 + 1;
                    if (second1 < 40)
                    {
                        sp.Draw(levelup, td_levelup, Color.White);
                        /*second1 = 0;*/
                    }
                }
                if (second1 == 40)
                {
                    IsDrawLevel = true;
                    second1 = 0;
                }
                Hinhnen.level = 4;
                sp.DrawString(sprifont, Hinhnen.level.ToString(), new Vector2(410, 270), Color.White);
                return;
            }
            if (Hinhnen.diem >= 2240 && Hinhnen.diem < 3240)
            {

                if (IsDrawLevel)
                {
                    second1 = second1 + 1;

                    if (second1 < 40)
                    {
                        sp.Draw(levelup, td_levelup, Color.White);
                        /*second1 = 0;*/
                    }
                }
                if (second1 == 40) { IsDrawLevel = false; second1 = 0; }
                Hinhnen.level = 5;
                sp.DrawString(sprifont, Hinhnen.level.ToString(), new Vector2(410, 270), Color.White);
                return;
            }
            if (Hinhnen.diem >= 3240 && Hinhnen.diem < 4450)
            {

                if (!IsDrawLevel)
                {
                    second1 = second1 + 1;
                    if (second1 < 40)
                    {
                        sp.Draw(levelup, td_levelup, Color.White);
                        /*second1 = 0;*/
                    }
                }
                if (second1 == 40)
                {
                    IsDrawLevel = true;
                    second1 = 0;
                }
                Hinhnen.level = 6;
                sp.DrawString(sprifont, Hinhnen.level.ToString(), new Vector2(410, 270), Color.White);
                return;
            }
            if (Hinhnen.diem >= 4450 && Hinhnen.diem < 5890)
            {
                if (IsDrawLevel)
                {
                    second1 = second1 + 1;

                    if (second1 < 40)
                    {
                        sp.Draw(levelup, td_levelup, Color.White);
                        /*second1 = 0;*/
                    }
                }
                if (second1 == 40) { IsDrawLevel = false; second1 = 0; }
                Hinhnen.level = 7;
                sp.DrawString(sprifont, Hinhnen.level.ToString(), new Vector2(410, 270), Color.White);
                return;
            }
            if (Hinhnen.diem >= 5890 && Hinhnen.diem < 7580)
            {
                if (!IsDrawLevel)
                {
                    second1 = second1 + 1;
                    if (second1 < 40)
                    {
                        sp.Draw(levelup, td_levelup, Color.White);
                        /*second1 = 0;*/
                    }
                }
                if (second1 == 40)
                {
                    IsDrawLevel = true;
                    second1 = 0;
                }
                Hinhnen.level = 8;
                sp.DrawString(sprifont, Hinhnen.level.ToString(), new Vector2(410, 270), Color.White);
                return;
            }
            if (Hinhnen.diem >= 7580)
            {
                if (IsDrawLevel)
                {
                    second1 = second1 + 1;

                    if (second1 < 40)
                    {
                        sp.Draw(levelup, td_levelup, Color.White);
                        /*second1 = 0;*/
                    }
                }
                if (second1 == 40) { IsDrawLevel = false; second1 = 0; }
                Hinhnen.level = 9;
                sp.DrawString(sprifont, Hinhnen.level.ToString(), new Vector2(410, 270), Color.White);
                return;
            }
        }
        public void DrawGameOver(SpriteBatch sp)
        {
            for (int i = 5; i < 28; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        matrix_mau[i, j] = -1;
                        matrix[i, j] = 0;
                        matrix2[i, j] = 0;
                        matrix3[i, j] = 0;
                        return;
                    }
                }
            }
        }
        public void Draw(SpriteBatch sp)
        {
            Texture2D k;
            k = get_khoinho();
            for (int i = 6; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (Update_Matrix.matrix[i, j] == 1 && matrix_mau[i, j] != -1 || Update_Matrix.matrix[i, j] == 3 && matrix_mau[i, j] != -1)
                    {
                        sp.Draw(k, new Vector2(37 + j * 30, 30 * (i - 6)) + Vector_Matran, new Microsoft.Xna.Framework.Rectangle(matrix_mau[i, j] * 30, 0, 30, 30), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                    }
                }
            for (int i = 6; i < 28; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (matrix_bong[i, j] == 4 && matrix_mau2[i, j] != -1)
                    {
                        sp.Draw(k, new Vector2(37 + j * 30, 30 * (i - 6)), new Microsoft.Xna.Framework.Rectangle(matrix_mau2[i, j] * 30, 0, 30, 30), Color.White * 0.3f, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                    }
                }
            if (count_hang > 0)
            {
                if (second < 50)
                {
                    toado_khoi = new Vector2(280, 30 * (Y_khoixoa - 6));
                    if (count_hang == 2)
                    {
                        //giữa
                        sp.Draw(khoi1, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 30f) ? (toado_khoi.X + 2f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.X + 58f + 1f * second) : (toado_khoi.X + 58f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 30f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.Y - 145f) : (toado_khoi.Y - 145f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(0 * 30, 0, 30, 30), Color.White, second / 50f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        //bên phải 1
                        sp.Draw(khoi2, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 10f) ? (toado_khoi.X + 5f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.X + 30f + 2f * second) : (toado_khoi.X + 30f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 10f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.Y - 50f) : (toado_khoi.Y - 50f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(0 * 30, 0, 30, 30), Color.White, second / 40f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi3, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 15f) ? (toado_khoi.X - 50f + 5f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.X - 50f + 45f + 2f * second) : (toado_khoi.X - 50f + 45f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.Y - 75f) : (toado_khoi.Y - 75f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(1 * 30, 0, 30, 30), Color.White, second / 30f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        sp.Draw(khoi4, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 20f) ? (toado_khoi.X - 100f + 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.X - 100f + 60f + 2f * second) : (toado_khoi.X - 100f + 60f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 20f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 100f) : (toado_khoi.Y - 100f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(2 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);

                        //bên phải 2
                        sp.Draw(khoi1, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 15f) ? (toado_khoi.X + 10f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.X + 90f + 5f * second) : (toado_khoi.X + 90f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 10f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.Y - 150f) : (toado_khoi.Y - 150f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(5 * 30, 0, 30, 30), Color.White, second / 5f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi5, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 20f) ? (toado_khoi.X - 50f + 10f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.X - 50f + 120f + 5f * second) : (toado_khoi.X - 50f + 120f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 20f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 10f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 200f) : (toado_khoi.Y - 200f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(4 * 30, 0, 30, 30), Color.White, second / 10f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        sp.Draw(khoi3, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 10f) ? (toado_khoi.X - 150f + 10f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.X - 150f + 60f + 5f * second) : (toado_khoi.X - 150f + 60f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 10f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 10f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.Y - 100f) : (toado_khoi.Y - 100f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(3 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);

                        //bên trái
                        sp.Draw(khoi1, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 15f) ? (toado_khoi.X - 50f - 5f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.X - 75f - 50f - 2f * second) : (toado_khoi.X - 111f - 50f - 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 75f) : (toado_khoi.Y - 75f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(2 * 30, 0, 30, 30), Color.White, second / 15f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi2, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 20f) ? (toado_khoi.X - 100f - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.X - 100f - 100f - 2f * second) : (toado_khoi.X - 146f - 100f - 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 20f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 100f) : (toado_khoi.Y - 100f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(1 * 30, 0, 30, 30), Color.White, second / 30f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi5, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 10f) ? (toado_khoi.X - 150f - 5f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.X - 50f - 150f - 2f * second) : (toado_khoi.X - 76f - 150f - 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 75f) : (toado_khoi.Y - 75f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(6 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                    }
                    else if (count_hang == 1)
                    {
                        sp.Draw(khoi3, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 30f) ? (toado_khoi.X + 2f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.X + 58f + 1f * second) : (toado_khoi.X + 58f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 30f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.Y - 145f) : (toado_khoi.Y - 145f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(0 * 30, 0, 30, 30), Color.White, second / 50f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        //bên phải 1
                        sp.Draw(khoi2, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 20f) ? (toado_khoi.X - 100f + 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.X - 100f + 60f + 2f * second) : (toado_khoi.X - 100f + 60f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 20f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 100f) : (toado_khoi.Y - 100f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(2 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        //bên phải 2
                        sp.Draw(khoi5, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 10f) ? (toado_khoi.X - 150f + 10f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.X - 150f + 60f + 5f * second) : (toado_khoi.X - 150f + 60f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 10f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 10f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.Y - 100f) : (toado_khoi.Y - 100f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(3 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);

                        //bên trái
                        sp.Draw(khoi3, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 20f) ? (toado_khoi.X - 100f - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.X - 100f - 100f - 2f * second) : (toado_khoi.X - 146f - 100f - 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 20f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 100f) : (toado_khoi.Y - 100f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(1 * 30, 0, 30, 30), Color.White, second / 30f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi5, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 10f) ? (toado_khoi.X - 150f - 5f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.X - 50f - 150f - 2f * second) : (toado_khoi.X - 76f - 150f - 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 75f) : (toado_khoi.Y - 75f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(6 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                    }
                    else if (count_hang == 3)
                    {
                        sp.Draw(khoi1, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 30f) ? (toado_khoi.X + 2f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.X + 58f + 1f * second) : (toado_khoi.X + 58f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 30f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.Y - 145f) : (toado_khoi.Y - 145f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(0 * 30, 0, 30, 30), Color.White, second / 50f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        //bên phải 1
                        sp.Draw(khoi2, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 10f) ? (toado_khoi.X + 5f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.X + 30f + 2f * second) : (toado_khoi.X + 30f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 10f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.Y - 50f) : (toado_khoi.Y - 50f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(0 * 30, 0, 30, 30), Color.White, second / 40f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi3, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 15f) ? (toado_khoi.X - 50f + 5f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.X - 50f + 45f + 2f * second) : (toado_khoi.X - 50f + 45f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.Y - 75f) : (toado_khoi.Y - 75f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(1 * 30, 0, 30, 30), Color.White, second / 30f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        sp.Draw(khoi4, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 20f) ? (toado_khoi.X - 100f + 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.X - 100f + 60f + 2f * second) : (toado_khoi.X - 100f + 60f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 20f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 100f) : (toado_khoi.Y - 100f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(2 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        sp.Draw(khoi6, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 25f) ? (toado_khoi.X - 150f + 5f * second) : (((1f * second >= 25f) && (1f * second < 29f)) ? (toado_khoi.X - 150f + 75f + 2f * second) : (toado_khoi.X - 150f + 75f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 25f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 25f) && (1f * second < 29f)) ? (toado_khoi.Y - 125f) : (toado_khoi.Y - 125f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(3 * 30, 0, 30, 30), Color.White, second / 10f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        //bên phải 2
                        sp.Draw(khoi1, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 15f) ? (toado_khoi.X + 10f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.X + 90f + 5f * second) : (toado_khoi.X + 90f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 10f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.Y - 150f) : (toado_khoi.Y - 150f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(5 * 30, 0, 30, 30), Color.White, second / 5f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi5, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 20f) ? (toado_khoi.X - 50f + 10f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.X - 50f + 120f + 5f * second) : (toado_khoi.X - 50f + 120f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 20f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 10f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 200f) : (toado_khoi.Y - 200f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(4 * 30, 0, 30, 30), Color.White, second / 10f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        sp.Draw(khoi6, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 25f) ? (toado_khoi.X - 100f + 10f * second) : (((1f * second >= 25f) && (1f * second < 29f)) ? (toado_khoi.X - 100f + 90f + 5f * second) : (toado_khoi.X - 100f + 90f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 25f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 10f * second) : (((1f * second >= 25f) && (1f * second < 29f)) ? (toado_khoi.Y - 250f) : (toado_khoi.Y - 250f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(5 * 30, 0, 30, 30), Color.White, second / 15f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        sp.Draw(khoi3, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 10f) ? (toado_khoi.X - 150f + 10f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.X - 150f + 60f + 5f * second) : (toado_khoi.X - 150f + 60f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 10f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 10f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.Y - 100f) : (toado_khoi.Y - 100f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(3 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);

                        //bên trái
                        sp.Draw(khoi1, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 15f) ? (toado_khoi.X - 50f - 5f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.X - 75f - 50f - 2f * second) : (toado_khoi.X - 111f - 50f - 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 75f) : (toado_khoi.Y - 75f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(2 * 30, 0, 30, 30), Color.White, second / 15f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi2, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 20f) ? (toado_khoi.X - 100f - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.X - 100f - 100f - 2f * second) : (toado_khoi.X - 146f - 100f - 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 20f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 100f) : (toado_khoi.Y - 100f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(1 * 30, 0, 30, 30), Color.White, second / 30f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi5, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 10f) ? (toado_khoi.X - 150f - 5f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.X - 50f - 150f - 2f * second) : (toado_khoi.X - 76f - 150f - 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 75f) : (toado_khoi.Y - 75f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(6 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                    }
                    else if (count_hang == 4)
                    {
                        sp.Draw(khoi1, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 30f) ? (toado_khoi.X + 2f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.X + 58f + 1f * second) : (toado_khoi.X + 58f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 30f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.Y - 145f) : (toado_khoi.Y - 145f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(0 * 30, 0, 30, 30), Color.White, second / 50f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        //bên phải 1
                        sp.Draw(khoi2, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 10f) ? (toado_khoi.X + 5f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.X + 30f + 2f * second) : (toado_khoi.X + 30f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 10f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.Y - 50f) : (toado_khoi.Y - 50f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(0 * 30, 0, 30, 30), Color.White, second / 40f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi3, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 15f) ? (toado_khoi.X - 50f + 5f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.X - 50f + 45f + 2f * second) : (toado_khoi.X - 50f + 45f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.Y - 75f) : (toado_khoi.Y - 75f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(1 * 30, 0, 30, 30), Color.White, second / 30f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        sp.Draw(khoi4, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 20f) ? (toado_khoi.X - 100f + 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.X - 100f + 60f + 2f * second) : (toado_khoi.X - 100f + 60f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 20f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 100f) : (toado_khoi.Y - 100f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(2 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        sp.Draw(khoi6, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 25f) ? (toado_khoi.X - 150f + 5f * second) : (((1f * second >= 25f) && (1f * second < 29f)) ? (toado_khoi.X - 150f + 75f + 2f * second) : (toado_khoi.X - 150f + 75f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 25f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 25f) && (1f * second < 29f)) ? (toado_khoi.Y - 125f) : (toado_khoi.Y - 125f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(3 * 30, 0, 30, 30), Color.White, second / 10f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        sp.Draw(khoi6, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 30f) ? (toado_khoi.X - 200f + 5f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.X - 200f + 150f + 2f * second) : (toado_khoi.X - 200f + 150f + 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 30f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.Y - 150f) : (toado_khoi.Y - 150f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(3 * 30, 0, 30, 30), Color.White, second / 10f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);

                        //bên phải 2
                        sp.Draw(khoi1, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 15f) ? (toado_khoi.X + 10f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.X + 90f + 5f * second) : (toado_khoi.X + 90f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 10f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.Y - 150f) : (toado_khoi.Y - 150f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(5 * 30, 0, 30, 30), Color.White, second / 5f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi5, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 20f) ? (toado_khoi.X - 50f + 10f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.X - 50f + 120f + 5f * second) : (toado_khoi.X - 50f + 120f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 20f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 10f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 200f) : (toado_khoi.Y - 200f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(4 * 30, 0, 30, 30), Color.White, second / 10f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        sp.Draw(khoi6, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 25f) ? (toado_khoi.X - 100f + 10f * second) : (((1f * second >= 25f) && (1f * second < 29f)) ? (toado_khoi.X - 100f + 90f + 5f * second) : (toado_khoi.X - 100f + 90f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 25f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 10f * second) : (((1f * second >= 25f) && (1f * second < 29f)) ? (toado_khoi.Y - 250f) : (toado_khoi.Y - 250f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(5 * 30, 0, 30, 30), Color.White, second / 15f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        sp.Draw(khoi3, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 10f) ? (toado_khoi.X - 150f + 10f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.X - 150f + 60f + 5f * second) : (toado_khoi.X - 150f + 60f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 10f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 10f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.Y - 100f) : (toado_khoi.Y - 100f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(3 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        sp.Draw(khoi3, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 30f) ? (toado_khoi.X - 200f + 30f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.X - 150f + 80f + 5f * second) : (toado_khoi.X - 200f + 70f + 6f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 30f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 30f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.Y - 300f) : (toado_khoi.Y - 300f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(3 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                        //bên trái
                        sp.Draw(khoi1, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 15f) ? (toado_khoi.X - 50f - 5f * second) : (((1f * second >= 15f) && (1f * second < 19f)) ? (toado_khoi.X - 75f - 50f - 2f * second) : (toado_khoi.X - 111f - 50f - 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 75f) : (toado_khoi.Y - 75f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(2 * 30, 0, 30, 30), Color.White, second / 15f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi2, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 20f) ? (toado_khoi.X - 100f - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.X - 100f - 100f - 2f * second) : (toado_khoi.X - 146f - 100f - 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 20f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 100f) : (toado_khoi.Y - 100f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(1 * 30, 0, 30, 30), Color.White, second / 30f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi5, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 10f) ? (toado_khoi.X - 150f - 5f * second) : (((1f * second >= 10f) && (1f * second < 14f)) ? (toado_khoi.X - 50f - 150f - 2f * second) : (toado_khoi.X - 76f - 150f - 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 15f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 20f) && (1f * second < 24f)) ? (toado_khoi.Y - 75f) : (toado_khoi.Y - 75f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(6 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                        sp.Draw(khoi5, new Vector2((toado_khoi.X + 1f * second) < (toado_khoi.X + 30f) ? (toado_khoi.X - 200f - 5f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.X - 150f - 200f - 2f * second) : (toado_khoi.X - 96f - 200f - 3f * second)), (toado_khoi.Y + 1f * second) < (toado_khoi.Y + 30f)/*tăng cái này cao lên*/ ? (toado_khoi.Y - 5f * second) : (((1f * second >= 30f) && (1f * second < 34f)) ? (toado_khoi.Y - 95f) : (toado_khoi.Y - 95f + 6f * second))), new Microsoft.Xna.Framework.Rectangle(6 * 30, 0, 30, 30), Color.White, second / 20f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);// đến giây thứ 20 thì bắt đầu rơi xuống
                    }
                    second = second + 1;
                }
                if (second == 50)
                {
                    count_hang = 0;
                    second = 0;
                    IsDelete = false;
                }
            }

            if (IsGameOver)
            {
                DrawGameOver(sp);
                I_gameover += 1;
                if (I_gameover < 3000)
                {
                    sp.Draw(gameover, new Vector2(td_gameover.X + I_gameover * 10f, td_gameover.Y), Color.White);

                    sp.Draw(gameover, new Vector2(td_gameover2.X - I_gameover * 10f, td_gameover2.Y), Color.White);
                }
            }
            DrawLevel(sp);
        }
        public void Khoitao_khoinho()
        {
            if (kt.Loai_Khoi2 == 1 && kt.kieu2 == 2)
            {
                kt.Khoitao_Khoinho(7, 4);
                return;
            }
            if (kt.Loai_Khoi2 == 1 && kt.kieu2 == 1 || kt.Loai_Khoi2 == 1 && kt.kieu2 == 3)
            {
                kt.Khoitao_Khoinho(8, 3);
                return;
            }
            if (kt.Loai_Khoi2 == 1 && kt.kieu2 == 4)
            {
                kt.Khoitao_Khoinho(7, 3);
                return;
            }
            //khoi2

            if (kt.Loai_Khoi2 == 2 && kt.kieu2 == 1 || kt.Loai_Khoi2 == 2 && kt.kieu2 == 3)
            {
                kt.Khoitao_Khoinho(8, 4);
                return;
            }
            if (kt.Loai_Khoi2 == 2 && kt.kieu2 == 2 || kt.Loai_Khoi2 == 2 && kt.kieu2 == 4)
            {
                kt.Khoitao_Khoinho(7, 2);
                return;
            }
            //khoi3

            if (kt.Loai_Khoi2 == 3 && kt.kieu2 == 1 || kt.Loai_Khoi2 == 3 && kt.kieu2 == 3)
            {
                kt.Khoitao_Khoinho(8, 3);
                return;
            }

            if (kt.Loai_Khoi2 == 3 && kt.kieu2 == 2 || kt.Loai_Khoi2 == 3 && kt.kieu2 == 4)
            {
                kt.Khoitao_Khoinho(7, 3);
                return;
            }
            //Khoi4

            if (kt.Loai_Khoi2 == 4 && kt.kieu2 == 1)
            {
                kt.Khoitao_Khoinho(8, 3);
                return;
            }

            if (kt.Loai_Khoi2 == 4 && kt.kieu2 == 2)
            {
                kt.Khoitao_Khoinho(7, 2);
                return;
            }

            if (kt.Loai_Khoi2 == 4 && kt.kieu2 == 3)
            {
                kt.Khoitao_Khoinho(8, 4);
                return;
            }

            if (kt.Loai_Khoi2 == 4 && kt.kieu2 == 4)
            {
                kt.Khoitao_Khoinho(7, 3);
                return;
            }
            //khoi 5
            if (kt.Loai_Khoi2 == 5)
            {
                kt.Khoitao_Khoinho(7, 3);
                return;
            }
            //Khoi6
            if (kt.Loai_Khoi2 == 6 && kt.kieu2 == 1)
            {
                kt.Khoitao_Khoinho(7, 4);
                return;
            }
            if (kt.Loai_Khoi2 == 6 && kt.kieu2 == 2)
            {
                kt.Khoitao_Khoinho(8, 4);
                return;
            }
            if (kt.Loai_Khoi2 == 6 && kt.kieu2 == 3)
            {
                kt.Khoitao_Khoinho(7, 3);
                return;
            }
            if (kt.Loai_Khoi2 == 6 && kt.kieu2 == 4)
            {
                kt.Khoitao_Khoinho(8, 3);
                return;
            }
            //khoi 7
            if (kt.Loai_Khoi2 == 7 && kt.kieu2 == 1 || kt.Loai_Khoi2 == 7 && kt.kieu2 == 3)
            {
                kt.Khoitao_Khoinho(8, 4);
                return;
            }
            if (kt.Loai_Khoi2 == 7 && kt.kieu2 == 2 || kt.Loai_Khoi2 == 7 && kt.kieu2 == 4)
            {
                kt.Khoitao_Khoinho(7, 2);
                return;
            }
        }
        public void Update(GameTimer gameTime)
        {
           
            if (!Hinhnen.IsPause)
            {

                if (!IsGameOver)
                {
                    if (Controller.CheckNote.Read_Volume())
                        at_dichuyen.Play();
                    if (IsEndRow && IsDaChay)
                    {
                        for (int m = 0; m < 28; m++)
                            for (int n = 0; n < 10; n++)
                            {
                                matrix_bong[m, n] = 0;
                                matrix_mau2[m, n] = -1;
                            }
                        // if(List_kieu.Count>0)
                        kt.kieu = List_kieu[0];
                        //if (List_khoi.Count > 0)
                        kt.Loai_Khoi = List_khoi[0];
                        Im_Index.Clear();
                        Im_Index.Add(Im_Index2[0]);

                        kt.Khoitao_Khoi(4, 4);

                        restart_mt(Im_Index[0]);
                        IsEndRow = false;
                        IsEndKhoi = false;
                        /*IsDaChay = false;*/
                    }
                    if (!IsEndKhoi)
                    {
                        for (int i = 0; i < 28; i++)
                            for (int j = 0; j < 10; j++)
                            {
                                Hinhnen.matrix_nho[i, j] = 0;
                            }
                        DateTime de = DateTime.Now;
                        List_kieu.Clear();
                        List_khoi.Clear();
                        Im_Index2.Clear();
                        Random rd = new Random();
                        List_kieu.Add((rd.Next(1000)) % 4 + 1);
                        List_khoi.Add((rd.Next(1000)) % 7 + 1);//(
                        int mau = (rd.Next(1000)) % 6 + 1;
                        // mang_mau = mau;
                        Im_Index2.Add(mau);
                        kt.kieu2 = List_kieu[0];
                        kt.Loai_Khoi2 = List_khoi[0];
                        Khoitao_khoinho();
                        IsEndKhoi = true;
                        IsDaChay = true;
                    }
                    //chỉ cần có 1 hàng cuối cùng =1 thì dừng lại
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (i == 27 && Update_Matrix.matrix[i, j] == 1 || Update_Matrix.matrix[i, j] == 1 && Update_Matrix.matrix[i + 1, j] == 3)
                            {
                                IsEndRow = true;
                            }
                        }

                    //gán chỉ số tương ứng MT1 = MT2

                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1 && i + 1 < 28 && Update_Matrix.matrix[i + 1, j] != 3 && !IsEndRow)
                            {
                                Update_Matrix.matrix2[i + 1, j] = 1;
                                //restart_mt(Im_Index[0]);
                                matrix_mau[i + 1, j] = Im_Index[0];
                            }
                        }
                    //Xóa chỉ số cũ của MT1

                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1 && IsEndRow)
                            {
                                Update_Matrix.matrix2[i, j] = 3;
                                matrix_mau[i, j] = Im_Index[0];
                                // restart_mt(Im_Index[0]);
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix[i, j] = 0;
                                //  matrix_mau[i, j] = -1;
                            }
                        }
                    //Tạo lại MT1
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (!IsEndRow)
                            {
                                Update_Matrix.matrix[i, j] = Update_Matrix.matrix2[i, j];
                            }
                        }
                    XoaHang();
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (matrix2[i, j] != 3)
                            {
                                matrix2[i, j] = 0;
                            }
                        }
                    getbong();
                }
                else
                {
                   

                }

            }


        }
        private bool IsAdd(List<int> x, int y)
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
        public void getbong()
        {
            if (Controller.CheckNote.Read_Bong())
            {
                if (!EndRow())
                {
                    for (int m = 0; m < 28; m++)
                        for (int n = 0; n < 10; n++)
                        {
                            matrix_bong[m, n] = 0;
                            matrix_mau2[m, n] = -1;
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
        public void XoaHang()
        {
            for (int i = 0; i < 28; i++)
            {
                if (matrix[i, 0] == 3 && matrix[i, 1] == 3 && matrix[i, 2] == 3 && matrix[i, 3] == 3 && matrix[i, 4] == 3
                    && matrix[i, 5] == 3 && matrix[i, 6] == 3 && matrix[i, 7] == 3 && matrix[i, 8] == 3 && matrix[i, 9] == 3)
                {
                    k_hang.Add(i);
                    IsDelete = true;
                    matrix_mau[i, 0] = -1;
                    matrix_mau[i, 1] = -1;
                    matrix_mau[i, 2] = -1;
                    matrix_mau[i, 3] = -1;
                    matrix_mau[i, 4] = -1;
                    matrix_mau[i, 5] = -1;
                    matrix_mau[i, 6] = -1;
                    matrix_mau[i, 7] = -1;
                    matrix_mau[i, 8] = -1;
                    matrix_mau[i, 9] = -1;
                    matrix[i, 0] = 0;
                    matrix[i, 1] = 0;
                    matrix[i, 2] = 0;
                    matrix[i, 3] = 0;
                    matrix[i, 4] = 0;
                    matrix[i, 5] = 0;
                    matrix[i, 6] = 0;
                    matrix[i, 7] = 0;
                    matrix[i, 8] = 0;
                    matrix[i, 9] = 0;
                    matrix2[i, 0] = 0;
                    matrix2[i, 1] = 0;
                    matrix2[i, 2] = 0;
                    matrix2[i, 3] = 0;
                    matrix2[i, 4] = 0;
                    matrix2[i, 5] = 0;
                    matrix2[i, 6] = 0;
                    matrix2[i, 7] = 0;
                    matrix2[i, 8] = 0;
                    matrix2[i, 9] = 0;
                    matrix3[i, 0] = 0;
                    matrix3[i, 1] = 0;
                    matrix3[i, 2] = 0;
                    matrix3[i, 3] = 0;
                    matrix3[i, 4] = 0;
                    matrix3[i, 5] = 0;
                    matrix3[i, 6] = 0;
                    matrix3[i, 7] = 0;
                    matrix3[i, 8] = 0;
                    matrix3[i, 9] = 0;
                    if (Controller.CheckNote.Read_Volume())
                    {
                        at_xoa.Play();
                    }
                }
            }
            if (k_hang.Count > 0)
            {
                for (int m = 0; m < k_hang.Count; m++)
                {
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (i < k_hang[m] && matrix[i, j] == 3)
                            {
                                matrix3[i + 1, j] = 3;
                                //matrix[i+1, j] = 3;
                                matrix_mau[i + 1, j] = matrix_mau[i, j];
                            }
                            else if (i > k_hang[m] && matrix[i, j] == 3)
                            {
                                matrix3[i, j] = 3;
                                matrix_mau[i, j] = matrix_mau[i, j];
                                //   matrix[i, j] = 0;
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (i < k_hang[m] && matrix[i, j] == 3)
                            {
                                matrix[i, j] = 0;
                                matrix2[i, j] = 0;
                                /* matrix_mau[i, j] = -1;*/
                            }
                        }


                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix3[i, j] = 1;
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (Update_Matrix.matrix[i, j] == 1)
                            {
                                Update_Matrix.matrix[i, j] = 0;
                                Update_Matrix.matrix2[i, j] = 0;
                                /*  matrix_mau[i, j] = -1;*/
                            }
                        }
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            Update_Matrix.matrix[i, j] =

                                Update_Matrix.matrix3[i, j];
                            Update_Matrix.matrix2[i, j] =

                               Update_Matrix.matrix3[i, j];
                        }
                    //  restart_mt(Im_Index[0]);
                    //      IsEndRow = true;
                    for (int i = 0; i < 28; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            matrix3[i, j] = 0;
                        }
                }
                count_hang = k_hang.Count;
                Y_khoixoa = k_hang[count_hang - 1];
                Update_Score();
                k_hang.Clear();
                //k = -1;
            }
        }
        public void Update_Score()
        {
            if (Hinhnen.level == 1)
            {
                if (count_hang == 1)
                {
                    Hinhnen.diem = Hinhnen.diem + 10;
                    return;
                }
                if (count_hang == 2)
                {
                    Hinhnen.diem = Hinhnen.diem + 30;
                    return;
                }
                if (count_hang == 3)
                {
                    Hinhnen.diem = Hinhnen.diem + 60;
                    return;
                }
                if (count_hang == 4)
                {
                    Hinhnen.diem = Hinhnen.diem + 100;
                    return;
                }
                return;
            }
            if (Hinhnen.level == 2)
            {
                if (count_hang == 1)
                {
                    Hinhnen.diem = Hinhnen.diem + 14;
                    return;
                }
                if (count_hang == 2)
                {
                    Hinhnen.diem = Hinhnen.diem + 42;
                    return;
                }
                if (count_hang == 3)
                {
                    Hinhnen.diem = Hinhnen.diem + 84;
                    return;
                }
                if (count_hang == 4)
                {
                    Hinhnen.diem = Hinhnen.diem + 140;
                    return;
                }
                return;
            }
            if (Hinhnen.level == 3)
            {
                if (count_hang == 1)
                {
                    Hinhnen.diem = Hinhnen.diem + 16;
                    return;
                }
                if (count_hang == 2)
                {
                    Hinhnen.diem = Hinhnen.diem + 48;
                    return;
                }
                if (count_hang == 3)
                {
                    Hinhnen.diem = Hinhnen.diem + 96;
                    return;
                }
                if (count_hang == 4)
                {
                    Hinhnen.diem = Hinhnen.diem + 160;
                    return;
                }
                return;
            }
            if (Hinhnen.level == 4)
            {
                if (count_hang == 1)
                {
                    Hinhnen.diem = Hinhnen.diem + 18;
                    return;
                }
                if (count_hang == 2)
                {
                    Hinhnen.diem = Hinhnen.diem + 54;
                    return;
                }
                if (count_hang == 3)
                {
                    Hinhnen.diem = Hinhnen.diem + 108;
                    return;
                }
                if (count_hang == 4)
                {
                    Hinhnen.diem = Hinhnen.diem + 180;
                    return;
                }
                return;
            }
            if (Hinhnen.level == 5)
            {
                if (count_hang == 1)
                {
                    Hinhnen.diem = Hinhnen.diem + 20;
                    return;
                }
                if (count_hang == 2)
                {
                    Hinhnen.diem = Hinhnen.diem + 60;
                    return;
                }
                if (count_hang == 3)
                {
                    Hinhnen.diem = Hinhnen.diem + 120;
                    return;
                }
                if (count_hang == 4)
                {
                    Hinhnen.diem = Hinhnen.diem + 200;
                    return;
                }
                return;
            }
            if (Hinhnen.level == 6)
            {
                if (count_hang == 1)
                {
                    Hinhnen.diem = Hinhnen.diem + 24;
                    return;
                }
                if (count_hang == 2)
                {
                    Hinhnen.diem = Hinhnen.diem + 66;
                    return;
                }
                if (count_hang == 3)
                {
                    Hinhnen.diem = Hinhnen.diem + 132;
                    return;
                }
                if (count_hang == 4)
                {
                    Hinhnen.diem = Hinhnen.diem + 220;
                    return;
                }
                return;
            }
            if (Hinhnen.level == 7)
            {
                if (count_hang == 1)
                {
                    Hinhnen.diem = Hinhnen.diem + 24;
                    return;
                }
                if (count_hang == 2)
                {
                    Hinhnen.diem = Hinhnen.diem + 72;
                    return;
                }
                if (count_hang == 3)
                {
                    Hinhnen.diem = Hinhnen.diem + 144;
                    return;
                }
                if (count_hang == 4)
                {
                    Hinhnen.diem = Hinhnen.diem + 240;
                    return;
                }
                return;
            }
            if (Hinhnen.level == 8)
            {
                if (count_hang == 1)
                {
                    Hinhnen.diem = Hinhnen.diem + 26;
                    return;
                }
                if (count_hang == 2)
                {
                    Hinhnen.diem = Hinhnen.diem + 78;
                    return;
                }
                if (count_hang == 3)
                {
                    Hinhnen.diem = Hinhnen.diem + 156;
                    return;
                }
                if (count_hang == 4)
                {
                    Hinhnen.diem = Hinhnen.diem + 260;
                    return;
                }
                return;
            }
            if (Hinhnen.level == 9)
            {
                if (count_hang == 1)
                {
                    Hinhnen.diem = Hinhnen.diem + 28;
                    return;
                }
                if (count_hang == 2)
                {
                    Hinhnen.diem = Hinhnen.diem + 84;
                    return;
                }
                if (count_hang == 3)
                {
                    Hinhnen.diem = Hinhnen.diem + 168;
                    return;
                }
                if (count_hang == 4)
                {
                    Hinhnen.diem = Hinhnen.diem + 280;
                    return;
                }
                return;
            }
        }
        public void DrawRoi1o(SpriteBatch sp)
        {

        }

    }
}
