using Microsoft.Phone.Net.NetworkInformation;

namespace Quick_Controls_V2.Model
{
    internal class Wifi
    {
        public static bool Enabled()
        {
            return DeviceNetworkInformation.IsWiFiEnabled;
        }
    }
}