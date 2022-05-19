using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Threading.Tasks;

namespace YTSeachByAPIV3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Please Enter Search Query");
            string searchQuery = Console.ReadLine();
            Console.WriteLine("Please Enter Number of Videos To scrap");
            double noOfVideos = double.Parse(Console.ReadLine());
            await Run(searchQuery,noOfVideos);
        }

        static async Task Run(string searchQuery, double noOfVideos)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyC5lmdB4ynaUVE8xoXI5I-dL0WhW7rhY3Q",
                ApplicationName = "MyAppName"
            });

            var searchListRequest = youtubeService.Search.List("id,snippet");
            searchListRequest.Q = searchQuery; // Replace with your search term.
            searchListRequest.MaxResults = 50;
           

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            double noOfPages = Math.Round(noOfVideos / 50);
            int c = 0;
            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                var searchVidRequest = youtubeService.Videos.List("snippet,statistics");
                searchVidRequest.Id = searchResult.Id.VideoId;
                var searchVidResponse = await searchVidRequest.ExecuteAsync();

                var searchChaRequest = youtubeService.Channels.List("id,snippet,statistics");
                searchChaRequest.Id = searchResult.Snippet.ChannelId;
                var searchChaResponse = await searchChaRequest.ExecuteAsync();

                var searchCommentsRequest = youtubeService.Comments.List("id,snippet");
                searchCommentsRequest.Id = searchResult.Id.VideoId;
                var searchCommentsResponse = await searchCommentsRequest.ExecuteAsync();

                
                c++;
            }

            Console.WriteLine(c.ToString());
            Console.ReadLine();
        }

    }
}
