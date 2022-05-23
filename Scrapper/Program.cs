using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using YTSearchQueryApiLib;

namespace Scrapper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("API Keys:");
            Console.WriteLine("AIzaSyCYIN8MNBnZ2wj13EC6obq14wToWYAiMeM");
            Console.WriteLine("AIzaSyC5lmdB4ynaUVE8xoXI5I-dL0WhW7rhY3Q");
            Console.WriteLine("AIzaSyBI_4QXpocUgOlkaLPdKfxiJ3mW_DkXtdQ");
            Console.WriteLine("AIzaSyD6ozTlBO_Vo3a-Jg4w4WzQ57lEiYqzJfg");
            Console.WriteLine("________________________________");

            Console.WriteLine("Please Enter Search Query");
            string searchQuery = Console.ReadLine();
            Console.WriteLine("Please Enter Number of Videos (Multiple of 50)");
            double noOfVideos = double.Parse(Console.ReadLine());
            Console.WriteLine("Please paste API Key (Copy one of above OR simply press enter)");
            string apiKey = Console.ReadLine();
            await Run(searchQuery,noOfVideos,apiKey);
        }

        static async Task Run(string searchQuery, double noOfVideos, string apiKey)
        {
            FileStream fileStream = new FileStream(searchQuery + ".csv", FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine("SNo,Video URL,Video Title,Video Views,Video Likes,Video Dislikes,Published Date,Channel Name,Channel URL,Subscribers,Total Videos,Total Views,Channel Created Date,Email,Social Links");

            YTSearchQuery yTSearchQuery = new YTSearchQuery();
            List<string> ytData = await yTSearchQuery.GetYTData(searchQuery, noOfVideos, apiKey);

            foreach(string item in ytData)
            {
                writer.WriteLine(item);
                writer.Flush();
                fileStream.Flush();
            }

            writer.Close();
            fileStream.Close();

        }


    }
}
