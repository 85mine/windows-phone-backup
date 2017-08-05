using System;
using System.Linq;
using Microsoft.Phone.Net.NetworkInformation;

namespace Quick_Controls_V2.Model
{
    internal class Airplane
    {
        public static bool Enabled()
        {
            try
            {
                if (!DeviceNetworkInformation.CellularMobileOperator.Any())
                    return true;
            }
            catch (Exception)
            {
            }

            return false;
        }
    }
}