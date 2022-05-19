using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.IO;
using System.Threading.Tasks;

namespace YTSeachByAPIV3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Please Enter Search Query");
            string searchQuery = Console.ReadLine();
            Console.WriteLine("Please Enter Number of Videos (Multiple of 50)");
            double noOfVideos = double.Parse(Console.ReadLine());
            await Run(searchQuery,noOfVideos);
        }

        static async Task Run(string searchQuery, double noOfVideos)
        {
            FileStream fileStream = new FileStream(searchQuery+".csv", FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine("SNo,Video URL,Video Title,Video Views,Video Likes,Video Dislikes,Published Date,Channel Name,Channel URL,Subscribers,Total Videos,Total Views,Channel Created Date,Email");

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyC5lmdB4ynaUVE8xoXI5I-dL0WhW7rhY3Q",
                ApplicationName = "MyAppName"
            });
           
            double noOfPages = Math.Round(Math.Ceiling(noOfVideos / 50));
            int pageCounter = 1;
            int rowCounter = 1;
            var searchListRequest = youtubeService.Search.List("id,snippet");
            searchListRequest.Q = searchQuery;
            searchListRequest.MaxResults = 100;
            Console.WriteLine("SNo\tVideo Title\tChannel Name");
            while (pageCounter <= noOfPages)
            {
                try
                {
                    var searchListResponse = await searchListRequest.ExecuteAsync();
                    searchListRequest.PageToken = searchListResponse.NextPageToken;

                    foreach (var searchResult in searchListResponse.Items)
                    {
                        try
                        {
                            var searchVidioRequest = youtubeService.Videos.List("snippet,statistics");
                            searchVidioRequest.Id = searchResult.Id.VideoId;
                            var searchVidResponse = await searchVidioRequest.ExecuteAsync();

                            var searchChannelRequest = youtubeService.Channels.List("id,snippet,statistics");
                            searchChannelRequest.Id = searchResult.Snippet.ChannelId;
                            var searchChaResponse = await searchChannelRequest.ExecuteAsync();

                            writer.Write(rowCounter.ToString());                            
                            writer.Write(",");
                            writer.Write("https://www.youtube.com/watch?v=" + searchResult.Id.VideoId);
                            writer.Write(",");
                            writer.Write(searchResult.Snippet.Title.Replace(","," "));
                            writer.Write(",");
                            //writer.Write(searchResult.Snippet.Description.Replace(",", " "));
                            //writer.Write(",");
                            //writer.WriteLine(searchVidResponse.Items[0].Snippet.Description);
                            writer.Write(searchVidResponse.Items[0].Statistics.ViewCount);
                            writer.Write(",");
                            writer.Write(searchVidResponse.Items[0].Statistics.LikeCount);
                            writer.Write(",");
                            writer.Write(searchVidResponse.Items[0].Statistics.DislikeCount);
                            writer.Write(",");
                            writer.Write(searchVidResponse.Items[0].Snippet.PublishedAt);
                            writer.Write(",");
                            writer.Write(searchChaResponse.Items[0].Snippet.Title.Replace(",", " "));
                            writer.Write(",");
                            writer.Write("https://www.youtube.com/channel/" + searchChaResponse.Items[0].Id);
                            writer.Write(",");
                            //writer.Write(searchChaResponse.Items[0].Snippet.Description.Replace(",", " "));
                            //writer.Write(",");
                            writer.Write(searchChaResponse.Items[0].Statistics.SubscriberCount);
                            writer.Write(",");
                            writer.Write(searchChaResponse.Items[0].Statistics.VideoCount);
                            writer.Write(",");
                            writer.Write(searchChaResponse.Items[0].Statistics.ViewCount);
                            writer.Write(",");
                            writer.Write(searchChaResponse.Items[0].Snippet.PublishedAt);
                            writer.Write(",");
                            string email = EmailFinder.SearchEmail(searchResult.Snippet.Description + " " + searchChaResponse.Items[0].Snippet.Description);
                            writer.Write("\"" + email.Trim() + "\"");
                            writer.Write("\n");
                            writer.Flush();
                            fileStream.Flush();
                            
                            Console.WriteLine(rowCounter + "\t" + searchResult.Snippet.Title + "\t" + searchChaResponse.Items[0].Snippet.Title);
                            rowCounter++;
                        }
                        catch (Exception)
                        {
                            rowCounter++;
                            continue;
                        }  
                    }
                    pageCounter++;
                }
                catch (Exception)
                {
                    pageCounter++;
                    continue;
                }  
            }
            writer.Close();
            fileStream.Close();
        }
    }
}
