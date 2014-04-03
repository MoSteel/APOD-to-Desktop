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


namespace APOD_to_Desktop
{
    class Program
    {
        /// <summary>
        /// Handles passing in arguments to perform various functions.
        /// </summary>
        /// <param name="args">If no arguments display FormMain; "UpdateAPOD" = Check for new APOD image.</param>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0 || args[0] != "UpdateAPOD")
            {
                Application.EnableVisualStyles();
                Application.Run(new FormMain());
            }
            else if (args[0] == "UpdateAPOD")
            {
                UpdateAPOD();
            }
        }

        /// <summary>
        /// Called to check for and update the APOD used as a Desktop Wallpaper.
        /// </summary>
        public static void UpdateAPOD()
        {
            // Get and store the directory location for the user local app data path.
            string fileDestination = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            fileDestination = fileDestination + "\\APOD to Desktop\\";

            // Try to get the image every ten seconds over a 2 minute time span.
            for (int i = 0; i < 12; i++)
            {
                Console.Write("Cycle number: " + i.ToString());
                Console.WriteLine();

                // Wait to see if a network is up before running through the application.
                if (CheckForInternetConnection())
                {
                    try
                    {
                        GetApod.FindApodImage();
                        DateTime today = DateTime.Today;
                        DesktopManager.Set(fileDestination + "apod_" + today.ToString("d").Replace("/", "_") + ".jpg");

                        Console.Write("New wallpaper set.");
                        Console.WriteLine();
                        Console.Read();
                        return;
                    }
                    catch
                    {
                        Console.Write("An error occurred.");
                        Console.WriteLine();
                        break;
                    }
                }

                // Put the application to sleep for ten seconds.
                Console.Write("Sleeping 10 seconds...");
                Console.WriteLine();
                Thread.Sleep(10000);
            }
        }

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
    }
}
