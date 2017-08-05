using Quick_Lock.Resources;

namespace Quick_Lock.Controls
{
    internal class Tiles
    {
        public static readonly Tile LockPhone = new Tile
        {
            BackgroundImage = AppResources.Tiles + "LockPhone" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "LockPhone" + ".png",
            KeyValue = ShortcutValue.LockPhone
        };

        public static void PinShortcut(Tile tile)
        {
            if (tile.KeyValue == ShortcutValue.FlashLight)
            {
                Common.CreateFlipTile(AppResources.ViewMainExtend, tile.KeyValue, tile.SmallbackgroundImage,
                    tile.BackgroundImage);
            }
            else
            {
                Common.CreateFlipTile(AppResources.ViewNavigationExtend, tile.KeyValue, tile.SmallbackgroundImage,
                    tile.BackgroundImage);
            }
        }
    }

    public class Tile
    {
        public string KeyValue { get; set; }

        public string SmallbackgroundImage { get; set; }

        public string BackgroundImage { get; set; }
    }
}