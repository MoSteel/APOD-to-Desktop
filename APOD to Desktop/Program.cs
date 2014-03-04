using System;
using System.ServiceProcess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using Microsoft.Win32;

namespace APOD_to_Desktop
{
    public enum Style : int
    {
        Tile,
        Center,
        Stretch,
        Fit,
        Fill
    }

    class Program
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://apod.nasa.gov/apod/astropix.html"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            //DEBUG CODE, REPLACE WITH ACTUAL DEBUGGING
            using (StreamWriter debugWriter = new StreamWriter("Z:\\Users\\Tim\\Desktop\\log.txt"))
            {
                Console.SetOut(debugWriter);

                // Check if the startup setting has been changed; if True, make a startup key, if false, delete any existing startup keys.
                if (Properties.Settings.Default.RunAtStartup)
                {
                    RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    rk.SetValue("APOD_to_Desktop", Application.ExecutablePath.ToString());
                }
                else if (!Properties.Settings.Default.RunAtStartup)
                {
                    RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    rk.DeleteValue("APOD_to_Desktop", false);
                }

                // Try to get the image every ten seconds over a 2 minute time span.
                for (int i = 0; i < 12; i++)
                {
                    Console.Write("Cycle number: " + i.ToString());
                    Console.WriteLine();

                    // Wait to see if a network is up before running through the application.
                    if (CheckForInternetConnection())
                    {
                        // Check if we should get a new wallpaper or not.
                        if (Properties.Settings.Default.GetWallpaper)
                        {
                            try
                            {
                                GetApod.FindApodImage();
                                DateTime today = DateTime.Today;
                                DesktopManager.Set("apod_" + today.ToString("d").Replace("/", "_") + ".jpg");

                                Console.Write("New wallpaper set.");
                                Console.WriteLine();
                                Console.Read();
                                return;
                            }
                            catch
                            {
                                Console.Write("An error occurred.");
                                Console.WriteLine();
                            }
                        }


                    }

                    // Put the application to sleep for ten seconds.
                    Console.Write("Sleeping 10 seconds...");
                    Console.WriteLine();
                    Thread.Sleep(10000);
                }
            }
        }
    }
}
