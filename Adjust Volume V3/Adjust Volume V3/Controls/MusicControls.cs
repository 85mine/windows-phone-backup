using System;
using Adjust_Volume_V3.Resources;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Adjust_Volume_V3.Controls
{
    internal class MusicControls
    {
        public static void Back()
        {
            FrameworkDispatcher.Update();
            if (MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.MovePrevious();
            }
        }

        public static void Next()
        {
            FrameworkDispatcher.Update();
            if (MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.MoveNext();
            }
        }

        public static void Play()
        {
            FrameworkDispatcher.Update();

            switch (MediaPlayer.State)
            {
                case MediaState.Playing:

                    var toast = new ToastPrompt
                    {
                        Message = AppResources.TextMusicIsPlaying,
                        FontSize = 30,
                    };
                    toast.Show();
                    break;

                case MediaState.Paused:

                    MediaPlayer.Resume();

                    break;

                case MediaState.Stopped:

                    var mediaLibrary = new MediaLibrary();

                    if (mediaLibrary.Songs.Count > 0)
                    {
                        MediaPlayer.Play(mediaLibrary.Songs);
                    }

                    break;
            }
        }

        public static void Pause()
        {
            FrameworkDispatcher.Update();
            if (MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.Pause();
            }
        }

        public static void Stop()
        {
            const string media = "Inception.mp3";

            try
            {
                FrameworkDispatcher.Update();
                Song track = Song.FromUri(" ", new Uri(media, UriKind.RelativeOrAbsolute));
                MediaPlayer.Play(track);
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error, please try again :(" + ex.Message);
            }
        }
    }
}