using System;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;
using Quick_Controls_V2.Resources;

namespace Quick_Controls_V2.Model
{
    internal class SongMusic
    {
        private static string _name = "";
        private static string _artist = "";
        private static string _album = "";

        private static readonly BitmapImage _albumcover = new BitmapImage(new Uri(AppResources.ImageBackground +
                                                                                  new Random().Next(1, 9) +
                                                                                  ".png", UriKind.RelativeOrAbsolute));

        private static readonly BitmapImage Nocover = new BitmapImage(new Uri(AppResources.ImageBackground +
                                                                              new Random().Next(1, 9) +
                                                                              ".png", UriKind.RelativeOrAbsolute));


        public static string Name
        {
            get
            {
                if (MediaPlayer.State == MediaState.Paused || MediaPlayer.State == MediaState.Playing)
                {
                    _name = MediaPlayer.Queue.ActiveSong.Name;
                }

                return _name;
            }
        }

        public static string Artist
        {
            get
            {
                if (MediaPlayer.State == MediaState.Paused || MediaPlayer.State == MediaState.Playing)
                {
                    _artist = MediaPlayer.Queue.ActiveSong.Album.Artist.ToString();
                }
                return _artist;
            }
        }

        public static string Album
        {
            get
            {
                if (MediaPlayer.State == MediaState.Paused || MediaPlayer.State == MediaState.Playing)
                {
                    _album = MediaPlayer.Queue.ActiveSong.Album.Name;
                }
                return _album;
            }
        }

        public static BitmapImage Albumcover
        {
            get
            {
                if (MediaPlayer.State == MediaState.Paused || MediaPlayer.State == MediaState.Playing)
                {
                    Stream stream = MediaPlayer.Queue.ActiveSong.Album.GetAlbumArt();
                    if (stream == null)
                    {
                        return Nocover;
                    }
                    _albumcover.SetSource(stream);
                }

                return _albumcover;
            }
        }
    }
}