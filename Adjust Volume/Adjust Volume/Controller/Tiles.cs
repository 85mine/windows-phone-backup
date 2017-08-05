using Adjust_Volume.Resources;

namespace Adjust_Volume.Controller
{
    class Tiles
    {
        public static readonly Tile Wifi = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Wifi400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Wifi400" + ".png",
            KeyValue = ShortcutValue.Wifi
        };

        public static readonly Tile Cellular = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Cellular400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Cellular400" + ".png",
            KeyValue = ShortcutValue.Cellular
        };

        public static readonly Tile Bluetooth = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Bluetooth400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Bluetooth400" + ".png",
            KeyValue = ShortcutValue.Bluetooth
        };

        public static readonly Tile Location = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Location400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Location400" + ".png",
            KeyValue = ShortcutValue.Location
        };

        public static readonly Tile Airplane = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Airplane400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Airplane400" + ".png",
            KeyValue = ShortcutValue.Airplane
        };

        public static readonly Tile Accounts = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Accounts400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Accounts400" + ".png",
            KeyValue = ShortcutValue.Accounts
        };

        public static readonly Tile LockScreen = new Tile
        {
            BackgroundImage = AppResources.Tiles + "LockScreen400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "LockScreen400" + ".png",
            KeyValue = ShortcutValue.LockScreen
        };

        public static readonly Tile Rotation = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Rotation400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Rotation400" + ".png",
            KeyValue = ShortcutValue.Rotation
        };

        public static readonly Tile Back = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Back400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Back400" + ".png",
            KeyValue = ShortcutValue.Back
        };

        public static readonly Tile Play = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Play400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Play400" + ".png",
            KeyValue = ShortcutValue.Play
        };

        public static readonly Tile Pause = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Pause400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Pause400" + ".png",
            KeyValue = ShortcutValue.Pause
        };

        public static readonly Tile Next = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Next400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Next400" + ".png",
            KeyValue = ShortcutValue.Next
        };

        public static readonly Tile Mute = new Tile
        {
            BackgroundImage = AppResources.Tiles + "Mute400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "Mute400" + ".png",
            KeyValue = ShortcutValue.Mute
        };

        public static readonly Tile BatterySaver = new Tile
        {
            BackgroundImage = AppResources.Tiles + "BatterySaver400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "BatterySaver400" + ".png",
            KeyValue = ShortcutValue.BatterySaver
        };

        public static readonly Tile LockPhone = new Tile
        {
            BackgroundImage = AppResources.Tiles + "LockPhone400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "LockPhone400" + ".png",
            KeyValue = ShortcutValue.LockPhone
        };

        public static readonly Tile FlashLight = new Tile
        {
            BackgroundImage = AppResources.Tiles + "FlashLight400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "FlashLight400" + ".png",
            KeyValue = ShortcutValue.FlashLight
        };

        public static readonly Tile StopMusic = new Tile
        {
            BackgroundImage = AppResources.Tiles + "StopMusic400" + ".png",
            SmallbackgroundImage = AppResources.Tiles + "StopMusic400" + ".png",
            KeyValue = ShortcutValue.StopMusic
        };


        public static void PinShortcut(Tile tile)
        {
            Common.CreateFlipTile(AppResources.ViewNavigationExtend, tile.KeyValue, tile.SmallbackgroundImage,
                                                    tile.BackgroundImage);
        }

    }

    public class Tile
    {
        public string KeyValue
        {
            get { return _keyValue; }
            set { _keyValue = value; }
        }

        public string SmallbackgroundImage
        {
            get { return _smallbackgroundImage; }
            set { _smallbackgroundImage = value; }
        }

        public string BackgroundImage
        {
            get { return _backgroundImage; }
            set { _backgroundImage = value; }
        }

        private string _keyValue;
        private string _smallbackgroundImage;
        private string _backgroundImage;
    }
}
