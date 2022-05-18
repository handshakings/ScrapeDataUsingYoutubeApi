using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace YTSeachByAPIV3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Run();
        }

        static async Task Run()
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyC5lmdB4ynaUVE8xoXI5I-dL0WhW7rhY3Q",
                ApplicationName = "MyAppName"
            });

            var searchListRequest = youtubeService.Search.List("id,snippet");
            searchListRequest.Q = "faisal masjid"; // Replace with your search term.
            searchListRequest.MaxResults = 5;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();


            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                var searchVidRequest = youtubeService.Videos.List("topLevelComment,snippet,contentDetails,player,recordingDetails,statistics,status,topicDetails");
                searchVidRequest.Id = searchResult.Id.VideoId;
                var searchVidResponse = await searchVidRequest.ExecuteAsync();

                var searchChaRequest = youtubeService.Channels.List("id,snippet,statistics");
                searchChaRequest.Id = searchResult.Snippet.ChannelId;
                var searchChaResponse = await searchChaRequest.ExecuteAsync();

                
            }


            Console.ReadLine();
        }

    }
}
