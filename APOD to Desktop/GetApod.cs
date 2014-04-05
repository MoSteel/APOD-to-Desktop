using System;
using System.Net;
using System.IO;

namespace APOD_to_Desktop
{
    class GetApod
    {
        /// <summary>
        /// Read the APOD website and locate the URL needed to retrieve the APOD.
        /// </summary>
        public static void FindApodImage()
        {
            // If the APOD to Desktop user location does not exist, create it now.
            if (!Directory.Exists(Properties.Settings.Default.AppFolder))
            {
                Directory.CreateDirectory(Properties.Settings.Default.AppFolder);
            }

            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            String htmlCode = client.DownloadString("http://apod.nasa.gov/apod/astropix.html");

            // Replace all html breaks for line seperators.
            htmlCode = htmlCode.Replace("<br>", "\r\n");

            using (StreamWriter writer = new StreamWriter(Properties.Settings.Default.AppFolder + "test.txt"))
            {
                writer.Write(htmlCode);
            }

            using (StreamReader reader = new StreamReader(Properties.Settings.Default.AppFolder + "test.txt"))
            {
                String line = String.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("<a href=\"image"))
                    {
                        char[] charsToTrim = { '"', '>' };
                        line = line.Remove(0, 9);
                        line = line.TrimEnd(charsToTrim);
                        line = "http://apod.nasa.gov/apod/" + line;
                        GetApodImage(line);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the APOD.
        /// </summary>
        /// <param name="url">Web url of the APOD image.</param>
        public static void GetApodImage(string url)
        {
            using (WebClient Client = new WebClient())
            {
                // Put todays date into the image filename.
                DateTime today = DateTime.Today;
                Console.WriteLine("Saving to " + "apod_" + today.ToString("d").Replace("/", "_") + ".jpg");
                Client.DownloadFile(url, Properties.Settings.Default.AppFolder + "apod_" + today.ToString("d").Replace("/", "_") + ".jpg");
            }
        }
    }
}
