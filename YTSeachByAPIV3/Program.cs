﻿using Google.Apis.Services;
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
            searchListRequest.Q = searchQuery; 
            searchListRequest.MaxResults = 50;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            double noOfPages = Math.Round(Math.Ceiling(noOfVideos / 50));
            int c = 1;

            while(c <= noOfPages)
            {
                if(c > 1)
                {
                    searchListRequest.PageToken = searchListResponse.NextPageToken;
                    searchListResponse = await searchListRequest.ExecuteAsync();
                }
                foreach (var searchResult in searchListResponse.Items)
                {
                    c++;

                    var searchVidRequest = youtubeService.Videos.List("snippet,statistics");
                    searchVidRequest.Id = searchResult.Id.VideoId;
                    var searchVidResponse = await searchVidRequest.ExecuteAsync();
                    
                    var searchChaRequest = youtubeService.Channels.List("id,snippet,statistics");
                    searchChaRequest.Id = searchResult.Snippet.ChannelId;
                    var searchChaResponse = await searchChaRequest.ExecuteAsync();

                    var searchCommentsRequest = youtubeService.Comments.List("id,snippet");
                    searchCommentsRequest.Id = searchResult.Id.VideoId;
                    var searchCommentsResponse = await searchCommentsRequest.ExecuteAsync();
                    
                }
            }
            

            Console.WriteLine(c.ToString());
            Console.ReadLine();
        }

    }
}
