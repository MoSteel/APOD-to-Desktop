using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32;


namespace APOD_to_Desktop
{

    class DesktopManager
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam,
            string pvParam, uint fWinIni);

        /// <summary>
        /// Get the current wallpaper image.
        /// </summary>
        public static void Get()
        {
            string wallpaper;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            wallpaper = key.GetValue(@"Wallpaper", 0).ToString();

            // Rename to save as possible future option.
            Console.Write(wallpaper);
        }

        /// <summary>
        /// Set the new wallpaper to the APOD.
        /// </summary>
        /// <param name="path">Path of the saved image.</param>
        public static void Set(string path)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            string style = Properties.Settings.Default.Style;

            switch (style)
            {
                case "Fill":
                    key.SetValue(@"WallpaperStyle", "10");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case "Stretch":
                    key.SetValue(@"WallpaperStyle", "2");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case "Tile":
                    key.SetValue(@"WallpaperStyle", "0");
                    key.SetValue(@"TileWallpaper", "1");
                    break;
                case "Center":
                    key.SetValue(@"WallpaperStyle", "0");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case "Fit":
                    key.SetValue(@"WallpaperStyle", "6");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
            }

            key.Close();

            // Set the desktop wallpapaer by calling the Win32 API SystemParametersInfo  
            // with the SPI_SETDESKWALLPAPER desktop parameter. The changes should  
            // persist, and also be immediately visible. 
            if (!SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE))
            {
                throw new Win32Exception();
            }
        }
    }
}
