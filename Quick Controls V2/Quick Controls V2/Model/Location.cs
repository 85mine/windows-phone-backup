using System;
using Windows.Devices.Geolocation;

namespace Quick_Controls_V2.Model
{
    internal class Location
    {
        public static bool Enabled()
        {
            try
            {
                var locator = new Geolocator();

                if (locator.LocationStatus == PositionStatus.Disabled)
                {
                    return false;
                }
            }
            catch (Exception)
            {
            }

            return true;
        }
    }
}