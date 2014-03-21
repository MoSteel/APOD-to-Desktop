using System;
using System.Net;
using System.IO;

namespace APOD_to_Desktop
{
    class GetApod
    {
        public static void FindApodImage()
        {
            // Get and store the directory location for the user local app data path.
            string fileDestination = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            fileDestination = fileDestination + "\\APOD to Desktop\\";

            // If the APOD to Desktop user location does not exist, create it now.
            if (!Directory.Exists(fileDestination))
            {
                Directory.CreateDirectory(fileDestination);
            }

            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            String htmlCode = client.DownloadString("http://apod.nasa.gov/apod/astropix.html");

            // Replace all html breaks for line seperators.
            htmlCode = htmlCode.Replace("<br>", "\r\n");

            using (StreamWriter writer = new StreamWriter(fileDestination + "test.txt"))
            {
                writer.Write(htmlCode);
            }

            using (StreamReader reader = new StreamReader(fileDestination + "test.txt"))
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

        public static void GetApodImage(string url)
        {
            // Get and store the directory location for the user local app data path.
            string fileDestination = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            fileDestination = fileDestination + "\\APOD to Desktop\\";

            using (WebClient Client = new WebClient())
            {
                // Put todays date into the image filename.
                DateTime today = DateTime.Today;
                Console.WriteLine("Saving to " + "apod_" + today.ToString("d").Replace("/", "_") + ".jpg");
                Client.DownloadFile(url, fileDestination + "apod_" + today.ToString("d").Replace("/", "_") + ".jpg");
            }
        }
    }
}
