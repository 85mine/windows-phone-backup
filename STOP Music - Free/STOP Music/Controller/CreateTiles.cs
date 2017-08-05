using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using STOP_Music.Resources;

namespace STOP_Music.Controller
{
    internal class CreateTiles
    {

        public static FlipTile CreateImage(string timerInput)
        {
            var fliptile = new FlipTile();
            TextBlock hours;
            TextBlock minutes;
            TextBlock seconds;
            TextBlock hoursInput;
            TextBlock minutesInput;
            TextBlock secondsInput;
            Image backgroudImage;

            #region Create SmallBackgroundImage

            try
            {
                var smallBackgroundImage = new WriteableBitmap(300, 300); //Create Bitmap Empty

                hoursInput = new TextBlock
                {
                    Text = timerInput.Substring(0, 2) + "H",
                    FontSize = 50,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                minutesInput = new TextBlock
                {
                    Text = timerInput.Substring(2, 2) + "M",
                    FontSize = 40,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                secondsInput = new TextBlock
                {
                    Text = timerInput.Substring(4, 2) + "S",
                    FontSize = 30,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                backgroudImage = new Image
                {
                    Width = 300,
                    Height = 300,
                    Source = ByteToImageSource(AppResources._300x300),
                    Stretch = Stretch.UniformToFill
                };

                smallBackgroundImage.Render(backgroudImage, new TranslateTransform {X = 0, Y = 0});
                smallBackgroundImage.Render(hoursInput, new TranslateTransform {X = 30, Y = 117});
                smallBackgroundImage.Render(minutesInput, new TranslateTransform {X = 120, Y = 200});
                smallBackgroundImage.Render(secondsInput, new TranslateTransform {X = 35, Y = 240});
                smallBackgroundImage.Invalidate();
                fliptile.SmallBackgroundImage = SaveWriteableBitmapToIsolated(smallBackgroundImage, timerInput + "S");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Small" + ex.Message);
            }

            #endregion

            #region Create BackgroundImage

            try
            {
                var backgroundImage = new WriteableBitmap(400, 400); //Create Bitmap Empty

                hoursInput = new TextBlock
                {
                    Text = timerInput.Substring(0, 2),
                    FontSize = 90,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                hours = new TextBlock
                {
                    Text = "HOURS",
                    FontSize = 35,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                minutesInput = new TextBlock
                {
                    Text = timerInput.Substring(2, 2),
                    FontSize = 70,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                minutes = new TextBlock
                {
                    Text = "minutes",
                    FontSize = 30,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                secondsInput = new TextBlock
                {
                    Text = timerInput.Substring(4, 2),
                    FontSize = 45,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                seconds = new TextBlock
                {
                    Text = "seconds",
                    FontSize = 25,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                backgroudImage = new Image
                {
                    Width = 400,
                    Height = 400,
                    Source = ByteToImageSource(AppResources._400x400),
                    Stretch = Stretch.UniformToFill
                };

                backgroundImage.Render(backgroudImage, new TranslateTransform {X = 0, Y = 0});
                backgroundImage.Render(hoursInput, new TranslateTransform {X = 20, Y = 180});
                backgroundImage.Render(minutesInput, new TranslateTransform {X = 140, Y = 300});
                backgroundImage.Render(secondsInput, new TranslateTransform {X = 22, Y = 340});
                backgroundImage.Render(hours, new TranslateTransform {X = 27, Y = 160});
                backgroundImage.Render(minutes, new TranslateTransform {X = 143, Y = 275});
                backgroundImage.Render(seconds, new TranslateTransform {X = 25, Y = 320});
                backgroundImage.Invalidate();
                fliptile.BackgroundImage = SaveWriteableBitmapToIsolated(backgroundImage, timerInput + "M");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Medium" + ex.Message);
            }

            #endregion

            #region Create WideBackgroundImage

            try
            {
                var wideBackgroundImage = new WriteableBitmap(691, 336); //Create Bitmap Empty
                hoursInput = new TextBlock
                {
                    Text = timerInput.Substring(0, 2),
                    FontSize = 75,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                hours = new TextBlock
                {
                    Text = "HOURS",
                    FontSize = 30,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                minutesInput = new TextBlock
                {
                    Text = timerInput.Substring(2, 2),
                    FontSize = 60,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                minutes = new TextBlock
                {
                    Text = "minutes",
                    FontSize = 25,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                secondsInput = new TextBlock
                {
                    Text = timerInput.Substring(4, 2),
                    FontSize = 40,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                seconds = new TextBlock
                {
                    Text = "seconds",
                    FontSize = 20,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                backgroudImage = new Image
                {
                    Width = 691,
                    Height = 336,
                    Source = ByteToImageSource(AppResources._691x336),
                    Stretch = Stretch.UniformToFill
                };

                wideBackgroundImage.Render(backgroudImage, new TranslateTransform {X = 0, Y = 0});
                wideBackgroundImage.Render(hoursInput, new TranslateTransform {X = 20, Y = 150});
                wideBackgroundImage.Render(minutesInput, new TranslateTransform {X = 132, Y = 250});
                wideBackgroundImage.Render(secondsInput, new TranslateTransform {X = 22, Y = 285});
                wideBackgroundImage.Render(hours, new TranslateTransform {X = 25, Y = 130});
                wideBackgroundImage.Render(minutes, new TranslateTransform {X = 135, Y = 230});
                wideBackgroundImage.Render(seconds, new TranslateTransform {X = 25, Y = 270});
                wideBackgroundImage.Invalidate();
                fliptile.WideBackgroundImage = SaveWriteableBitmapToIsolated(wideBackgroundImage, timerInput + "W");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wide" + ex.Message);
            }

            #endregion

            return fliptile;
        }

        #region Converter Byte Array To ImageSource

        private static ImageSource ByteToImageSource(byte[] _byte)
        {
            try
            {
                var imageSource = new BitmapImage();
                using (var m = new MemoryStream(_byte))
                {
                    imageSource.SetSource(m);
                }
                return imageSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Converter Byte Array To ImageSource" + ex.Message);
            }

            return null;
        }

        #endregion

        #region Save WriteableBitmap To Isolated

        private static string SaveWriteableBitmapToIsolated(WriteableBitmap writeableBitmap, string timerInput)
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string uriImage;
                try
                {
                    using (
                        var imageStream = new IsolatedStorageFileStream("Shared/ShellContent/" + timerInput + ".png",
                            FileMode.Create, isf))
                    {
                        writeableBitmap.WritePNG(imageStream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SaveWriteableBitmap" + ex.Message);
                }

                uriImage = "isostore:/Shared/ShellContent/" + timerInput + ".png";

                return uriImage;
            }
        }

        #endregion
    }
}