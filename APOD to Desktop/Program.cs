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
            // Get and store the directory location for the user local app data path.
            Properties.Settings.Default.AppFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\APOD to Desktop\\";

            // If the APOD to Desktop user location does not exist, create it now.
            if (!Directory.Exists(Properties.Settings.Default.AppFolder))
            {
                Directory.CreateDirectory(Properties.Settings.Default.AppFolder);
            }

            // Check to see if an argument is passed in; if not, open FormMain.
            if (args.Length == 0 || args[0] != "UpdateAPOD")
            {
                Application.EnableVisualStyles();
                Application.Run(new FormMain());
            }
            else if (args[0] == "UpdateAPOD")
            {
                UpdateAPOD();
            }

            // Run the storage manager function if necessary.
            if (Properties.Settings.Default.MaxUsage != 0)
                StorageManager();
        }

        /// <summary>
        /// Called to check for and update the APOD used as a Desktop Wallpaper.
        /// </summary>
        public static void UpdateAPOD()
        {
            // Try to get the image every ten seconds over a 2 minute time span.
            for (int i = 0; i < 12; i++)
            {
                // Wait to see if a network is up before running through the application.
                if (CheckForInternetConnection())
                {
                    try
                    {
                        DateTime today = DateTime.Today;

                        // If we already have an APOD for today, don't try to get another one.
                        if(File.Exists(Properties.Settings.Default.AppFolder + "apod_" + today.ToString("d").Replace("/", "_") + ".jpg"))
                            return;

                        GetApod.FindApodImage();
                        DesktopManager.Set(Properties.Settings.Default.AppFolder + "apod_" + today.ToString("d").Replace("/", "_") + ".jpg");
                        return;
                    }
                    catch
                    {
                        break;
                    }
                }

                // Put the application to sleep for ten seconds if we didn't find a connection to the APOD site.
                Thread.Sleep(10000);
            }
        }

        /// <summary>
        /// Checks for an internet connection to the APOD website.
        /// </summary>
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

        /// <summary>
        /// Manages the amount of storage space used by the application if a limit is set.
        /// </summary>
        public static void StorageManager()
        {
            double currentUsage = FormSettings.DirSize(new DirectoryInfo(Properties.Settings.Default.AppFolder));

            // Compare the current usage in bytes to the max usage, converted to bytes.
            while (currentUsage > (Properties.Settings.Default.MaxUsage) * 1000000)
            {
                // Delete the oldest image.
                FileSystemInfo fileInfo = new DirectoryInfo(Properties.Settings.Default.AppFolder).GetFileSystemInfos().OrderByDescending(fi => fi.CreationTime).Last();
                File.Delete(fileInfo.FullName);

                // Recalculate the current usage.
                currentUsage = FormSettings.DirSize(new DirectoryInfo(Properties.Settings.Default.AppFolder));
            }
        }
    }
}
