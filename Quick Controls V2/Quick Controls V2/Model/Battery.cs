using Windows.Phone.Devices.Power;
using Microsoft.Phone.Info;

namespace Quick_Controls_V2.Model
{
    internal class BatteryInfo
    {
        public static int BateryLevel
        {
            get { return Battery.GetDefault().RemainingChargePercent; }
        }

        public static bool IsCharging
        {
            get { return DeviceStatus.PowerSource == PowerSource.External; }
        }
    }
}