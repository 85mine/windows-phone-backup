using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;

namespace GameXepHinh.Controller
{
    public static class Check_Muakhoi
    {
        public static bool Read_khoi1()
        {
            bool result = false;
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists("check1.txt"))
            {
                StreamReader readFile = new StreamReader(new IsolatedStorageFileStream("check1.txt", FileMode.Open, storage));
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
        public static void Write_khoi1(bool x)
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists("check1.txt"))
            {
                storage.DeleteFile("check1.txt");
            }
            StreamWriter write = new StreamWriter(new IsolatedStorageFileStream("check1.txt", FileMode.CreateNew, storage));// Open a file in Create mode
            StringWriter str = new StringWriter();
            str.WriteLine(x);
            write.Write(str.ToString());
            write.Close();
            write.Dispose();
            //stream.Close();
            // stream.Dispose();
            storage.Dispose();
        }
        public static bool Read_khoi2()
        {
            bool result = false;
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists("check2.txt"))
            {
                StreamReader readFile = new StreamReader(new IsolatedStorageFileStream("check2.txt", FileMode.Open, storage));
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
        public static void Write_khoi2(bool x)
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists("check2.txt"))
            {
                storage.DeleteFile("check2.txt");
            }
            StreamWriter write = new StreamWriter(new IsolatedStorageFileStream("check2.txt", FileMode.CreateNew, storage));// Open a file in Create mode
            StringWriter str = new StringWriter();
            str.WriteLine(x);
            write.Write(str.ToString());
            write.Close();
            write.Dispose();
            //stream.Close();
            // stream.Dispose();
            storage.Dispose();
        }
        public static bool Read_khoi3()
        {
            bool result = false;
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists("check3.txt"))
            {
                StreamReader readFile = new StreamReader(new IsolatedStorageFileStream("check3.txt", FileMode.Open, storage));
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
        public static void Write_khoi3(bool x)
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists("check3.txt"))
            {
                storage.DeleteFile("check3.txt");
            }
            StreamWriter write = new StreamWriter(new IsolatedStorageFileStream("check3.txt", FileMode.CreateNew, storage));// Open a file in Create mode
            StringWriter str = new StringWriter();
            str.WriteLine(x);
            write.Write(str.ToString());
            write.Close();
            write.Dispose();
            //stream.Close();
            // stream.Dispose();
            storage.Dispose();
        }
    }
}
