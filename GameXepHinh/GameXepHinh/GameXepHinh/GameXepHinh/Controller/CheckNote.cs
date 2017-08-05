using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;

namespace GameXepHinh.Controller
{
    public static class CheckNote
    {
        public static bool Isthongbao = false;
        public static void Note()
        {
            if (!Isthongbao)
            {
                if (MediaPlayer.State == MediaState.Playing)
                {
                    MessageBoxResult m = MessageBox.Show("Bạn có muốn nghe nhạc nền của game không?", "Đổi nhạc nền", MessageBoxButton.OKCancel);
                    if (m == MessageBoxResult.OK)
                    {
                        Menu.nhacgame = true;
                        MediaPlayer.Stop();
                        Write_Volume(Menu.nhacgame);
                    }
                    else
                    {
                        Menu.nhacgame = false;
                        Write_Volume(Menu.nhacgame);
                    }
                }
                Isthongbao = true;
            }

        }
        public static bool Read_Volume()
        {
            bool result = true;
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists("Volume.txt"))
            {
                StreamReader readFile = new StreamReader(new IsolatedStorageFileStream("Volume.txt", FileMode.Open, storage));
                result = Convert.ToBoolean(readFile.ReadLine()); //Int32.Parse(myString);
                // reader.Close();
                // reader.Dispose();
                readFile.Close();
                //  fileStream.Close();
                // fileStream.Dispose();
            }
            storage.Dispose();
            return result;
        }
        public static void Write_Volume(bool x)
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists("Volume.txt"))
            {
                storage.DeleteFile("Volume.txt");
            }
            StreamWriter write = new StreamWriter(new IsolatedStorageFileStream("Volume.txt", FileMode.CreateNew, storage));// Open a file in Create mode
            StringWriter str = new StringWriter();
            str.WriteLine(x);
            write.Write(str.ToString());
            write.Close();
            write.Dispose();
            //stream.Close();
            // stream.Dispose();
            storage.Dispose();
        }
        public static bool Read_Bong()
        {
            bool result = true;
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists("Bong.txt"))
            {
                StreamReader readFile = new StreamReader(new IsolatedStorageFileStream("Bong.txt", FileMode.Open, storage));
                result = Convert.ToBoolean(readFile.ReadLine()); //Int32.Parse(myString);
                // reader.Close();
                // reader.Dispose();
                readFile.Close();
                //  fileStream.Close();
                // fileStream.Dispose();
            }
            storage.Dispose();
            return result;
        }
        public static void Write_Bong(bool x)
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists("Bong.txt"))
            {
                storage.DeleteFile("Bong.txt");
            }
            StreamWriter write = new StreamWriter(new IsolatedStorageFileStream("Bong.txt", FileMode.CreateNew, storage));// Open a file in Create mode
            StringWriter str = new StringWriter();
            str.WriteLine(x);
            write.Write(str.ToString());
            write.Close();
            write.Dispose();
            //stream.Close();
            // stream.Dispose();
            storage.Dispose();
        }
        public static String Read_Block()
        {
            string result = "3";
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists("Block.txt"))
            {
                StreamReader readFile = new StreamReader(new IsolatedStorageFileStream("Block.txt", FileMode.Open, storage));
                result = readFile.ReadLine(); //Int32.Parse(myString);
                // reader.Close();
                // reader.Dispose();
                readFile.Close();
                //  fileStream.Close();
                // fileStream.Dispose();
            }
            storage.Dispose();
            return result;
        }
        public static void Write_Block(string t)
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists("Block.txt"))
            {
                storage.DeleteFile("Block.txt");
            }
            StreamWriter write = new StreamWriter(new IsolatedStorageFileStream("Block.txt", FileMode.CreateNew, storage));// Open a file in Create mode
            StringWriter str = new StringWriter();
            str.WriteLine(t);
            write.Write(str.ToString());
            write.Close();
            write.Dispose();
            //stream.Close();
            // stream.Dispose();
            storage.Dispose();
        }
    }
}
