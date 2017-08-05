using System;
using System.Windows;
using Windows.System;
using Microsoft.Phone.Tasks;

namespace Quick_Controls_V2.Controls
{
    internal class Navigation
    {
        private static readonly ConnectionSettingsTask ObjConnectionTask = new ConnectionSettingsTask();

        private static readonly Version TargetedVersion = new Version(8, 0, 10492);

        public static bool IsTargetedVersion
        {
            get { return Environment.OSVersion.Version >= TargetedVersion; }
        }

        public static void Wifi()
        {
            ObjConnectionTask.ConnectionSettingsType = ConnectionSettingsType.WiFi;
            ObjConnectionTask.Show();
        }

        public static void Cellular()
        {
            ObjConnectionTask.ConnectionSettingsType = ConnectionSettingsType.Cellular;
            ObjConnectionTask.Show();
        }

        public static void Bluetooth()
        {
            ObjConnectionTask.ConnectionSettingsType = ConnectionSettingsType.Bluetooth;
            ObjConnectionTask.Show();
        }

        public static async void Location()
        {
            await Launcher.LaunchUriAsync(new Uri("ms-settings-location:"));
        }

        public static void Airplane()
        {
            ObjConnectionTask.ConnectionSettingsType = ConnectionSettingsType.AirplaneMode;
            ObjConnectionTask.Show();
        }

        public static async void Accounts()
        {
            await Launcher.LaunchUriAsync(new Uri("ms-settings-emailandaccounts:"));
        }

        public static async void LockScreen()
        {
            await Launcher.LaunchUriAsync(new Uri("ms-settings-lock:"));
        }

        public static async void Rotation()
        {
            if (IsTargetedVersion)
            {
                await Launcher.LaunchUriAsync(new Uri("ms-settings-screenrotation:"));
            }
            else
            {
                MessageBox.Show("Please upgrade to Windows Phone 8 Update 3");
            }
        }

        public static async void BatterySaver()
        {
            await Launcher.LaunchUriAsync(new Uri("ms-settings-power:"));
        }
    }
}