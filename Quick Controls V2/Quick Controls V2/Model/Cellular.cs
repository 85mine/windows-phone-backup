using Microsoft.Phone.Net.NetworkInformation;

namespace Quick_Controls_V2.Model
{
    internal class Cellular
    {
        public static bool Enabled()
        {
            return DeviceNetworkInformation.IsCellularDataEnabled;
        }
    }
}