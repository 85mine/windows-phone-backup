using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Resources;
using Microsoft.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using STOP_Music.Resources;

namespace STOP_Music.Controller
{
    internal class Music
    {
        public static async Task<bool> ClearHistory()
        {
            try
            {
                await Task.Run(new Action(CreateMediaHistory));
                //await Task.Factory.StartNew(new Action(CreateMediaHistory));
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Error, please try again :(");
            }

            return false;
        }

        public static void CreateMediaHistory()
        {
            try
            {
                for (int i = 0; i < 30; i++)
                {
                    //Create a snapshot of the page title
                    StreamResourceInfo sri =
                        Application.GetResourceStream(new Uri(AppResources.ImageHistory, UriKind.RelativeOrAbsolute));
                    var mediaHistoryItem = new MediaHistoryItem();
                    //<hubTileImageStream> must be a valid ImageStream.
                    mediaHistoryItem.ImageStream = sri.Stream;
                    mediaHistoryItem.Source = "";
                    mediaHistoryItem.Title = "STOP Music";
                    mediaHistoryItem.PlayerContext.Add("STOP Music" + i, "STOP Music");
                    MediaHistory mediaHistory = MediaHistory.Instance;
                    mediaHistory.WriteRecentPlay(mediaHistoryItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void StopMusic()
        {
            Controller.Controls.PlayMedia(AppResources.MusicQuickstop);
        }
    }
}