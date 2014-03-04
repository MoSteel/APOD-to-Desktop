﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        public static void Get()
        {
            string wallpaper;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            wallpaper = key.GetValue(@"Wallpaper", 0).ToString();

            // Rename to save as possible future option.
            Console.Write(wallpaper);
        }

        public static void Set(string path)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            Style style = Properties.Settings.Default.Style;

            switch (style)
            {
                case Style.Tile:
                    key.SetValue(@"WallpaperStyle", "0");
                    key.SetValue(@"TileWallpaper", "1");
                    break;
                case Style.Center:
                    key.SetValue(@"WallpaperStyle", "0");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case Style.Stretch:
                    key.SetValue(@"WallpaperStyle", "2");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case Style.Fit: // (Windows 7 and later)
                    key.SetValue(@"WallpaperStyle", "6");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case Style.Fill: // (Windows 7 and later)
                    key.SetValue(@"WallpaperStyle", "10");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
            }

            key.Close();

            // If the specified image file is neither .bmp nor .jpg, - or - 
            // if the image is a .jpg file but the operating system is Windows Server  
            // 2003 or Windows XP/2000 that does not support .jpg as the desktop  
            // wallpaper, convert the image file to .bmp and save it to the  
            // %appdata%\Microsoft\Windows\Themes folder. 
            string ext = Path.GetExtension(path);
            if ((!ext.Equals(".bmp", StringComparison.OrdinalIgnoreCase) && !ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
                || (ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase)))
            {
                using (Image image = Image.FromFile(path))
                {
                    path = String.Format(@"{0}\Microsoft\Windows\Themes\{1}.bmp",
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        Path.GetFileNameWithoutExtension(path));
                    image.Save(path, ImageFormat.Bmp);
                }
            }

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
