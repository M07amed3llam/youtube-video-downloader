using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Downloader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter the URL of the video: ");
            string url = Console.ReadLine();

            Console.Write("Enter the title of the video: ");
            string title = Console.ReadLine();

            Console.Write("Enter the path where you want to save the video: ");
            string path = Console.ReadLine();

            var video = new Video(url);
            await video.Download(title, path);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
