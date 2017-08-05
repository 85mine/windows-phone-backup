using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;
using Windows.Phone.Media.Capture;
using Windows.System;
using Microsoft.Phone.Controls;
using Quick_Controls_V2.Controls;
using Quick_Controls_V2.Model;
using Quick_Controls_V2.Resources;

namespace Quick_Controls_V2.Views
{
    public partial class Main : PhoneApplicationPage
    {
        #region Variable

        //Create Dispatchertimer for check state
        private const CameraSensorLocation SensorLocation = CameraSensorLocation.Back;

        private readonly DispatcherTimer _checkState = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(0.5)
        };

        //Access Camera
        private AudioVideoCaptureDevice _avDevice;
        //Access Sensor

        //Camera is ON ?
        private bool _cameraIsOn;

        //Checking State
        private int _state = (int)CheckState.State.Null;

        //Tutorial
        private readonly Popup _tutorial = new Popup
        {
            Child = new UserControls.Tutorial(),
            VerticalOffset = 0,
            HorizontalOffset = 0
        };

        //Get value from Navigation
        private const string Key = "Shortcut";

        private string _value = "";

        #endregion


        public Main()
        {
            InitializeComponent();

            //Check state
            _checkState.Tick += _checkState_Tick;
        }

        private async void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _tutorial.IsOpen = AppSetting.IsShowTutorial();

            //Starting checking
            if (!_checkState.IsEnabled)
            {
                _checkState.Start();
            }

            CoverStoryboard.Begin();

            #region Check NetWork State

            Common.SetStateNetWork(Wifi, WifiState, Model.Wifi.Enabled());
            Common.SetStateNetWork(Cellular, CellularState, Model.Cellular.Enabled());
            //Common.SetStateNetWork(Bluetooth, BluetoothState, Model.Bluetooth.Enabled().Result);
            Common.SetStateNetWork(Location, LocationState, Model.Location.Enabled());
            Common.SetStateNetWork(Airplane, AirplaneState, Model.Airplane.Enabled());

            #endregion

            if (NavigationContext.QueryString.TryGetValue(Key, out _value))
            {
                if (_value == ShortcutValue.FlashLight)
                {
                    if (!_cameraIsOn)
                    {
                        _avDevice = await AudioVideoCaptureDevice.OpenAsync(SensorLocation,
                            AudioVideoCaptureDevice.GetAvailableCaptureResolutions(SensorLocation).First());
                        _cameraIsOn = true;
                    }
                    if (_cameraIsOn)
                    {
                        Common.TurnOnFlashlight(FlashLight, _avDevice, SensorLocation);
                    }
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            #region Check NetWork State

            switch (_state)
            {
                case (int)CheckState.State.Airplane:
                    Common.SetStateNetWork(Airplane, AirplaneState, Model.Airplane.Enabled());
                    Common.SetStateNetWork(Wifi, WifiState, Model.Wifi.Enabled());
                    Common.SetStateNetWork(Cellular, CellularState, Model.Cellular.Enabled());
                    Common.SetStateNetWork(Bluetooth, BluetoothState, Model.Bluetooth.Enabled().Result);
                    break;
                case (int)CheckState.State.Wifi:
                    Common.SetStateNetWork(Wifi, WifiState, Model.Wifi.Enabled());
                    break;
                case (int)CheckState.State.Cellular:
                    Common.SetStateNetWork(Cellular, CellularState, Model.Cellular.Enabled());
                    break;
                case (int)CheckState.State.Bluetooth:
                    //Common.SetStateNetWork(Bluetooth, BluetoothState, Model.Bluetooth.Enabled().Result);
                    break;
                case (int)CheckState.State.Location:
                    Common.SetStateNetWork(Location, LocationState, Model.Location.Enabled());
                    break;
            }

            #endregion
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            //base.OnBackKeyPress(e);
            e.Cancel = true;
            Application.Current.Terminate();
        }

        #region Checking state

        private void _checkState_Tick(object sender, EventArgs e)
        {
            NameSong.Text = SongMusic.Name;
            ArtistsSong.Text = SongMusic.Artist;
            var ib = new ImageBrush { ImageSource = SongMusic.Albumcover };
            Cover.Fill = ib;
            Cover.Stretch = Stretch.UniformToFill;
            Common.ChangeButton(Play, Pause);
            BatteryPercent.Text = Model.BatteryInfo.BateryLevel + "%";
        }

        #endregion

        #region Shorcuts

        private void Wifi_Click(object sender, RoutedEventArgs e)
        {
            _state = (int)CheckState.State.Wifi;
            Controls.Navigation.Wifi();
        }

        private void Cellular_Click(object sender, RoutedEventArgs e)
        {
            _state = (int)CheckState.State.Cellular;
            Controls.Navigation.Cellular();
        }

        private void Bluetooth_Click(object sender, RoutedEventArgs e)
        {
            _state = (int)CheckState.State.Bluetooth;
            Controls.Navigation.Bluetooth();
        }

        private void Location_Click(object sender, RoutedEventArgs e)
        {
            _state = (int)CheckState.State.Location;
            Controls.Navigation.Location();
        }

        private void Airplane_Click(object sender, RoutedEventArgs e)
        {
            _state = (int)CheckState.State.Airplane;
            Controls.Navigation.Airplane();
        }

        private void Accounts_Click(object sender, RoutedEventArgs e)
        {
            Controls.Navigation.Accounts();
        }

        private void LockScreen_Click(object sender, RoutedEventArgs e)
        {
            Controls.Navigation.LockScreen();
        }

        private void Rotation_Click(object sender, RoutedEventArgs e)
        {
            Controls.Navigation.Rotation();
        }

        private void Battery_Click(object sender, RoutedEventArgs e)
        {
            Controls.Navigation.BatterySaver();
        }

        private async void STOPMusic_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("zune:navigate?appid=dcaaded7-03c8-4a62-a552-577db0dfdd2c"));
        }

        private void Rate_Click(object sender, RoutedEventArgs e)
        {
            Common.Rating();
        }

        #endregion

        #region Lock Phone

        private void LockPhone_Click(object sender, RoutedEventArgs e)
        {
            Common.LockPhone(FlashLight.IsChecked == true);
        }

        #endregion

        #region Navigate To Settings Page

        private void More_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(AppResources.ViewSettings, UriKind.RelativeOrAbsolute));
        }

        #endregion

        #region Adjust volume

        private void Mute_Click(object sender, RoutedEventArgs e)
        {
            Common.SetVolume(0, VolumeSlider, VolumeValue);
        }

        private void Volume_Click(object sender, RoutedEventArgs e)
        {
            Common.SetVolume(30, VolumeSlider, VolumeValue);
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (VolumeSlider == null)
                    return;
                VolumeValue.Text = Convert.ToUInt16(VolumeSlider.Value).ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VolumeSlider_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            Common.SetVolume(Convert.ToUInt16(VolumeSlider.Value));
        }

        #endregion

        #region Music Player Controls

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            MusicControls.Stop(AppResources.Quickstop);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            MusicControls.Next();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            MusicControls.Play();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            MusicControls.Back();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            MusicControls.Pause();
        }

        #endregion

        #region Navigate To My Store

        private void Copyright_Tap(object sender, GestureEventArgs e)
        {
            Common.GetMore(AppResources.TextPublisher);
        }

        #endregion

        #region ON/ OFF FlashLight

        private async void FlashLight_Checked(object sender, RoutedEventArgs e)
        {
            if (!_cameraIsOn)
            {
                _avDevice = await AudioVideoCaptureDevice.OpenAsync(SensorLocation,
                    AudioVideoCaptureDevice.GetAvailableCaptureResolutions(SensorLocation).First());
                _cameraIsOn = true;
            }
            if (_cameraIsOn)
            {
                Common.TurnOnFlashlight(FlashLight, _avDevice, SensorLocation);
            }
        }

        private void FlashLight_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_cameraIsOn)
            {
                Common.TurnOffFlashlight(FlashLight, _avDevice);
            }
        }

        private void FlashLight_Click(object sender, RoutedEventArgs e)
        {
        }

        #endregion

        #region Pin Buttons To Start

        private void Previous_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Previous);
        }

        private void Play_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Play);
        }

        private void Pause_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Pause);
        }

        private void Next_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Next);
        }

        private void Stop_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.StopMusic);
        }

        private void Mute_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Mute);
        }

        private void Volume_Hold(object sender, GestureEventArgs e)
        {
            Common.CreateIconicTile(AppResources.ViewVolumeExtend, "30",
                AppResources.smallIconImage, AppResources.iconImage, 30);
        }

        private void Wifi_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Wifi);
        }

        private void Cellular_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Cellular);
        }

        private void Bluetooth_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Bluetooth);
        }

        private void Location_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Location);
        }

        private void Airplane_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Airplane);
        }

        private void Accounts_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Accounts);
        }

        private void LockScreen_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.LockScreen);
        }

        private void Rotation_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Rotation);
        }

        private void LockPhone_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.LockPhone);
        }

        private void BatteryInfo_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.Battery);
        }

        private void FlashLight_Hold(object sender, GestureEventArgs e)
        {
            Tiles.PinShortcut(Tiles.FlashLight);
        }

        #endregion
    }
}