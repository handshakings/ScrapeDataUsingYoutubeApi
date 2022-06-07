﻿using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace YTSearchQueryLib
{
    public class YTSearchQueryUI 
    {
        public async Task<string> GetYTDataUIAsync(string userinput) 
        {
            UserInput ui = JsonConvert.DeserializeObject<UserInput>(userinput);
            List<YouTubeService> ytServices = new List<YouTubeService>();
            foreach(string apiKey in ui.ApiKeys)
            {
                ytServices.Add(new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = apiKey,
                    ApplicationName = "MyAppName"+new Random().Next(1,100).ToString()
                }));
            }

            double noOfPages = ui.NoOfVideos / 50;
            int pageCounter = 1;
            int rowCounter = 1;
            List<YTDataModel> ytData = new List<YTDataModel>();
            int ytServicesCounter = 0;
            while (pageCounter <= noOfPages)
            {
                ytServicesCounter = (pageCounter > ytServices.Count) ? 0 : ytServicesCounter;
                var searchListRequest = ytServices[ytServicesCounter].Search.List("id,snippet");
                searchListRequest.Q = ui.SearchQuery;
                searchListRequest.MaxResults = 100;

                try
                {
                    var searchListResponse = await searchListRequest.ExecuteAsync();
                    searchListRequest.PageToken = searchListResponse.NextPageToken;

                    foreach (var searchResult in searchListResponse.Items)
                    {
                        try
                        {
                            var searchVidioRequest = ytServices[ytServicesCounter].Videos.List("snippet,statistics");
                            searchVidioRequest.Id = searchResult.Id.VideoId;
                            var searchVidioResponse = await searchVidioRequest.ExecuteAsync();

                            var searchChannelRequest = ytServices[ytServicesCounter].Channels.List("id,snippet,statistics");
                            searchChannelRequest.Id = searchResult.Snippet.ChannelId;
                            var searchChannelResponse = await searchChannelRequest.ExecuteAsync();

                            var searchCommentsRequest = ytServices[ytServicesCounter].CommentThreads.List("id,snippet,replies");
                            searchCommentsRequest.TextFormat = CommentThreadsResource.ListRequest.TextFormatEnum.PlainText;
                            searchCommentsRequest.VideoId = searchResult.Id.VideoId;
                            var searchCommentsResponse = await searchCommentsRequest.ExecuteAsync();

                            string commentAndReplyText = GetAllCommentsAndReplies(searchCommentsResponse, searchCommentsRequest);
                            EmailFinder emailFinder = new EmailFinder();
                            string email = emailFinder.SearchEmail(searchResult.Snippet.Description + " " + searchChannelResponse.Items[0].Snippet.Description + " " + commentAndReplyText);
                            string links = emailFinder.SearchLinks(searchResult.Snippet.Description + " " + searchChannelResponse.Items[0].Snippet.Description + " " + commentAndReplyText);

                            YTDataModel yTDataModel = new YTDataModel
                            {
                                SNo = rowCounter,
                                VideoUrl = "https://www.youtube.com/watch?v=" + searchResult.Id.VideoId,
                                VideoTitle = searchResult.Snippet.Title.Replace(",", " "),
                                VideoDescription = searchResult.Snippet.Description.Replace(",", " "),
                                VideoViews = searchVidioResponse.Items[0].Statistics.ViewCount.ToString(),
                                VideoLikes = searchVidioResponse.Items[0].Statistics.LikeCount.ToString(),
                                VideoDislikes = searchVidioResponse.Items[0].Statistics.DislikeCount.ToString(),
                                VideoPublishedDate = searchVidioResponse.Items[0].Snippet.PublishedAt.ToString(),
                                ChannelName = searchChannelResponse.Items[0].Snippet.Title.Replace(",", " "),
                                ChannelDescription = searchChannelResponse.Items[0].Snippet.Description.Replace(",", " "),
                                ChannelUrl = "https://www.youtube.com/channel/" + searchChannelResponse.Items[0].Id,
                                ChannelSubscribers = searchChannelResponse.Items[0].Statistics.SubscriberCount.ToString(),
                                ChannelVideos = searchChannelResponse.Items[0].Statistics.VideoCount.ToString(),
                                ChannelViews = searchChannelResponse.Items[0].Statistics.ViewCount.ToString(),
                                ChannelCreatedDate = searchChannelResponse.Items[0].Snippet.PublishedAt.ToString(),
                                Email = email,
                                Links = links
                            };
                            ytData.Add(yTDataModel);

                            rowCounter++;
                        }
                        catch (Exception ex)
                        {
                            rowCounter++;
                            continue;
                        }
                    }
                    pageCounter++;
                    ytServicesCounter++;
                }
                catch (Exception ex)
                {
                    pageCounter++;
                    ytServicesCounter++;
                    continue;
                }   
            }
            return JsonConvert.SerializeObject(ytData);       
        }


        public string GetAllCommentsAndReplies(CommentThreadListResponse searchCommentsResponse, CommentThreadsResource.ListRequest searchCommentsRequest)
        {
            string commentAndReplyText = null;
            //while (searchCommentsResponse.NextPageToken.Length > 0)
            {

                foreach (var item in searchCommentsResponse.Items)
                {

                    string allComments = item.Snippet.TopLevelComment.Snippet.TextDisplay;
                    string allReplies = null;
                    if (item.Replies != null)
                    {
                        foreach (var reply in item.Replies.Comments)
                        {
                            allReplies += reply.Snippet.TextDisplay;
                        }
                    }
                    commentAndReplyText += allComments + " " + allReplies;

                    //searchCommentsRequest.PageToken = searchCommentsResponse.NextPageToken;
                    //searchCommentsResponse = await searchCommentsRequest.ExecuteAsync();
                }
            }
            return commentAndReplyText;
        }
    }
}