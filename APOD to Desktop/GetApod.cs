using System;
using System.Net;
using System.IO;

namespace APOD_to_Desktop
{
    class GetApod
    {
        public static void FindApodImage()
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            String htmlCode = client.DownloadString("http://apod.nasa.gov/apod/astropix.html");

            // Replace all html breaks for line seperators.
            htmlCode = htmlCode.Replace("<br>", "\r\n");

            using (StreamWriter writer = new StreamWriter("test.txt"))
            {
                writer.Write(htmlCode);
            }

            using (StreamReader reader = new StreamReader("test.txt"))
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
            using (WebClient Client = new WebClient())
            {
                // Put todays date into the image filename.
                DateTime today = DateTime.Today;
                Console.WriteLine("Saving to " + "apod_" + today.ToString("d").Replace("/", "_") + ".jpg in directory " + AppDomain.CurrentDomain.BaseDirectory.ToString());
                Client.DownloadFile(url, "apod_" + today.ToString("d").Replace("/", "_") + ".jpg");
            }
        }
    }
}
