using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
using STOP_Music.Model;

namespace STOP_Music.Controller
{
    internal class DataHelper
    {
        private const string ConnectionString = @"isostore:/Timers.sdf";
        public static string FileName = "Timers.sdf";

        public bool CreateDatabase()
        {
            bool created = false;
            using (var context = new TimersContext(ConnectionString))
            {
                if (!context.DatabaseExists())
                {
                    string[] names = GetType().Assembly.GetManifestResourceNames();
                    string name = names.Where(n => n.EndsWith(FileName)).FirstOrDefault();
                    if (name != null)
                    {
                        using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
                        {
                            if (resourceStream != null)
                            {
                                using (
                                    IsolatedStorageFile myIsolatedStorage =
                                        IsolatedStorageFile.GetUserStoreForApplication())
                                {
                                    using (
                                        var fileStream = new IsolatedStorageFileStream(FileName, FileMode.Create,
                                            myIsolatedStorage))
                                    {
                                        using (var writer = new BinaryWriter(fileStream))
                                        {
                                            long length = resourceStream.Length;
                                            var buffer = new byte[32];
                                            int readCount = 0;
                                            using (var reader = new BinaryReader(resourceStream))
                                            {
                                                // read file in chunks in order to reduce memory consumption and increase performance
                                                while (readCount < length)
                                                {
                                                    int actual = reader.Read(buffer, 0, buffer.Length);
                                                    readCount += actual;
                                                    writer.Write(buffer, 0, actual);
                                                }
                                            }
                                        }
                                    }
                                }
                                created = true;
                            }
                            else
                            {
                                context.CreateDatabase();
                                created = true;
                            }
                        }
                    }
                    else
                    {
                        context.CreateDatabase();
                        created = true;
                    }
                }
            }
            return created;
        }

        public static void DeleteDatabase()
        {
            using (var context = new TimersContext(ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    // delete database if it exist
                    context.DeleteDatabase();
                }
            }
        }

        public static bool AddTimer(Timer _timer)
        {
            using (var context = new TimersContext(ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    bool result = context.Timer.Any(timer => timer.ID == _timer.ID); // true if exists
                    if (result) return false;
                    try
                    {
                        context.Timer.InsertOnSubmit(_timer);
                        context.SubmitChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool DeleteTimer(Timer _timer)
        {
            using (var context = new TimersContext(ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    try
                    {
                        IEnumerable<Timer> timers = (from t in context.Timer where t.ID == _timer.ID select t);
                        context.Timer.DeleteAllOnSubmit(timers);
                        context.SubmitChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static IList<Timer> GetTimers()
        {
            using (var context = new TimersContext(ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    IQueryable<Timer> query = from jn in context.Timer select jn;
                    return query.ToList();
                }
            }

            return null;
        }
    }
}