using System;
using System.IO;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Video_Downloader
{
    class Video
    {
        private string _url;

        public Video(string url)
        {
            _url = url;
        }

        public async Task Download(string title, string path)
        {
            var youtube = new YoutubeClient();

            var video = await youtube.Videos.GetAsync(_url);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);

            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            var stream = await youtube.Videos.Streams.GetAsync(streamInfo);

            string fileName = $"{title}.{streamInfo.Container.Name}";
            string filePath = Path.Combine(path, fileName);

            using (var output = File.OpenWrite(filePath))
            {
                await stream.CopyToAsync(output);
            }

            Console.WriteLine($"Video '{title}' has been downloaded to {filePath}.");
        }
    }
}