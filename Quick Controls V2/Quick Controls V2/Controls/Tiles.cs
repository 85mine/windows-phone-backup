using Quick_Controls_V2.Resources;

namespace Quick_Controls_V2.Controls
{
    internal class Tiles
    {
        public static readonly Tile Wifi = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Wifi" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Wifi" + ".png",
            KeyValue = ShortcutValue.Wifi
        };

        public static readonly Tile Cellular = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Cellular" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Cellular" + ".png",
            KeyValue = ShortcutValue.Cellular
        };

        public static readonly Tile Bluetooth = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Bluetooth" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Bluetooth" + ".png",
            KeyValue = ShortcutValue.Bluetooth
        };

        public static readonly Tile Location = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Location" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Location" + ".png",
            KeyValue = ShortcutValue.Location
        };

        public static readonly Tile Airplane = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Airplane" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Airplane" + ".png",
            KeyValue = ShortcutValue.Airplane
        };

        public static readonly Tile Accounts = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Accounts" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Accounts" + ".png",
            KeyValue = ShortcutValue.Accounts
        };

        public static readonly Tile LockScreen = new Tile
        {
            BackgroundImage = AppResources.Tiles + "LockScreen" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "LockScreen" + ".png",
            KeyValue = ShortcutValue.LockScreen
        };

        public static readonly Tile Rotation = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Rotation" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Rotation" + ".png",
            KeyValue = ShortcutValue.Rotation
        };

        public static readonly Tile Previous = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Previous" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Previous" + ".png",
            KeyValue = ShortcutValue.Previous
        };

        public static readonly Tile Play = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Play" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Play" + ".png",
            KeyValue = ShortcutValue.Play
        };

        public static readonly Tile Pause = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Pause" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Pause" + ".png",
            KeyValue = ShortcutValue.Pause
        };

        public static readonly Tile Next = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Next" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Next" + ".png",
            KeyValue = ShortcutValue.Next
        };

        public static readonly Tile Mute = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Mute" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Mute" + ".png",
            KeyValue = ShortcutValue.Mute
        };

        public static readonly Tile Battery = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Battery" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Battery" + ".png",
            KeyValue = ShortcutValue.Battery
        };

        public static readonly Tile LockPhone = new Tile
        {
            BackgroundImage = AppResources.Tiles + "LockPhone" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "LockPhone" + ".png",
            KeyValue = ShortcutValue.LockPhone
        };

        public static readonly Tile FlashLight = new Tile
        {
            BackgroundImage = AppResources.Tiles + "FlashLight" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "FlashLight" + ".png",
            KeyValue = ShortcutValue.FlashLight
        };

        public static readonly Tile StopMusic = new Tile
        {
            BackgroundImage = AppResources.Tiles + "StopMusic" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "StopMusic" + ".png",
            KeyValue = ShortcutValue.StopMusic
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