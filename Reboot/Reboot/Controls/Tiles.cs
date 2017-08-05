using Reboot.Resources;

namespace Reboot.Controls
{
    internal class Tiles
    {
        public static readonly Tile Reboot = new Tile
        {
            BackgroundImage = AppResources.Tiles + "512x512" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "512x512" + ".png",
            WideBackgroundImage = AppResources.Tiles + "691x336" + ".png",
            KeyValue = ShortcutValue.Reboot
        };

        public static void PinShortcut(Tile tile)
        {
            Common.CreateFlipTile(AppResources.ViewNavigationExtend, tile.KeyValue, tile.SmallbackgroundImage,
                tile.BackgroundImage,tile.WideBackgroundImage);
        }
    }

    public class Tile
    {
        public string KeyValue { get; set; }

        public string SmallbackgroundImage { get; set; }

        public string BackgroundImage { get; set; }

        public string WideBackgroundImage { get; set; }
    }
}