using System;
using System.Threading.Tasks;
using Windows.Networking.Proximity;

namespace Quick_Controls_V2.Model
{
    internal class Bluetooth
    {
        public static async Task<bool> Enabled()
        {
            // Search for all paired devices
            PeerFinder.AlternateIdentities["Bluetooth:Paired"] = "";

            try
            {
                await PeerFinder.FindAllPeersAsync();

                // Handle the result of the FindAllPeersAsync call
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x8007048F)
                {
                    return false;
                }
            }
            return true;
        }
    }
}