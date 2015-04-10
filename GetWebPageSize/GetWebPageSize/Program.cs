using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    internal class Program
    {
        public const int Reperitions = 1000;

        private static void Main(string[] args)
        {
            string url = "http://www.jd.com";
            if (args.Length > 0)
            {
                url = args[0];
            }
            Console.Write(url);

            Task task = WriteWebRequestSizeAsync(url);
            try
            {
                while (!task.Wait(100))
                {
                    Console.Write(".");
                }
                Console.ReadKey();
            }
            catch (WebException)
            {
            }
            catch (IOException)
            {
            }
            catch (NotSupportedException)
            {
            }
        }

        private static async Task WriteWebRequestSizeAsync(string url)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                WebResponse response = await webRequest.GetResponseAsync();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string text = await reader.ReadToEndAsync();
                    Console.WriteLine(FormatBytes(text.Length));
                }
            }
            catch (Exception)
            {
            }
        }

        public static string FormatBytes(long bytes)
        {
            var magnitudes = new string[] { "GB", "MB", "KB", "Bytes" };
            var max = (long)Math.Pow(1024, magnitudes.Length);

            return
                String.Format("{1:##.##} {0}",
                    magnitudes.FirstOrDefault(magnitude => bytes > (max /= 1024)) ?? "0 Bytes",
                    (decimal) bytes/(decimal) max).Trim();
        }
    }
}