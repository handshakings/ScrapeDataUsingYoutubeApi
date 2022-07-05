using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


namespace YTSearchQueryLib
{
    public class YTSearchQueryUI 
    {
        public async Task<string> ScrapeVideosBySearchQuery(string userinput, Delegate delegateFromUI) 
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

            double noOfPages = ui.ScrapeRecordCount / 50;
            int pageCounter = 1;
            int rowCounter = 1;
            List<YTDataModel> ytData = new List<YTDataModel>();
            int ytServicesCounter = 0;
            string nextPageToken = null;

            while (pageCounter <= noOfPages)
            {
                ytServicesCounter = (pageCounter > ytServices.Count) ? 0 : ytServicesCounter;
                var searchListRequest = ytServices[ytServicesCounter].Search.List("id,snippet");
                searchListRequest.Q = ui.SearchQuery;
                searchListRequest.MaxResults = 100;

                try
                {
                    searchListRequest.PageToken = nextPageToken != null ? nextPageToken : searchListRequest.PageToken;
                    var searchListResponse = await searchListRequest.ExecuteAsync();
                    nextPageToken = searchListResponse.NextPageToken;

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
                                VideoTitle = searchVidioResponse.Items[0].Snippet.Title.Replace(",", " "),
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

                            delegateFromUI.DynamicInvoke(rowCounter.ToString()+"/"+ui.ScrapeRecordCount);
                            
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

        public async Task<string> ScrapeChannelsByChannelsList(string userinput, string[] channelUrlList, Delegate delegateFromUI)
        {
            List<string> channelIDs = await GetChannelIdFromUrl(channelUrlList);
            UserInput ui = JsonConvert.DeserializeObject<UserInput>(userinput);
            List<YouTubeService> ytServices = new List<YouTubeService>();
            foreach (string apiKey in ui.ApiKeys)
            {
                ytServices.Add(new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = apiKey,
                    ApplicationName = "MyAppName" + new Random().Next(1, 100).ToString()
                }));
            }

            double noOfPages = ui.ScrapeRecordCount/5;
            int totalRows = int.Parse(ui.ScrapeRecordCount.ToString()) * channelUrlList.Length;
            int totalRowsCounter = 1;
            List<YTDataModel> ytData = new List<YTDataModel>();
            string nextPageToken = null;
            
            foreach(string channelId in channelIDs)
            {
                int pageCounter = 1;
                int rowCounter = 1;
                int ytServicesCounter = 0;
               
                while (pageCounter <= noOfPages)
                {
                    ytServicesCounter = (pageCounter > ytServices.Count) ? 0 : ytServicesCounter;
                    var searchListRequest = ytServices[ytServicesCounter].Search.List("id,snippet");
                    searchListRequest.Order = SearchResource.ListRequest.OrderEnum.ViewCount;//Most popular videos
                    searchListRequest.ChannelId = channelId;

                    try
                    {
                        searchListRequest.PageToken = nextPageToken != null ? nextPageToken : searchListRequest.PageToken;
                        var searchListResponse = await searchListRequest.ExecuteAsync();
                        nextPageToken = searchListResponse.NextPageToken;

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
                                delegateFromUI.DynamicInvoke(totalRowsCounter.ToString()+"/"+totalRows);
                                rowCounter++;
                                totalRowsCounter++;
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
            }
            return JsonConvert.SerializeObject(ytData);
        }



        public async Task<string> ScrapeChannelsBySearchQuery(string userinput, Delegate delegateFromUI)
        {
            UserInput ui = JsonConvert.DeserializeObject<UserInput>(userinput);
            List<YouTubeService> ytServices = new List<YouTubeService>();
            foreach (string apiKey in ui.ApiKeys)
            {
                ytServices.Add(new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = apiKey,
                    ApplicationName = "MyAppName" + new Random().Next(1, 100).ToString()
                }));
            }

            double noOfPages = ui.ScrapeRecordCount / 50;
            int pageCounter = 1;
            int rowCounter = 1;
            List<YTDataModel> ytData = new List<YTDataModel>();
            int ytServicesCounter = 0;
            WebClient webClient = new WebClient();
            string nextPageToken = null;

            while (pageCounter <= noOfPages)
            {
                ytServicesCounter = (pageCounter > ytServices.Count) ? 0 : ytServicesCounter;
                var searchListRequest = ytServices[ytServicesCounter].Search.List("id,snippet");
                searchListRequest.Q = ui.SearchQuery;
                searchListRequest.MaxResults = 100;
                searchListRequest.Type = "channel";
                //searchListRequest.RegionCode = "PK";
                searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
                //searchListRequest.Location = "25.2744/133.7751";

                try
                {
                    searchListRequest.PageToken = nextPageToken != null ? nextPageToken : searchListRequest.PageToken;
                    var searchListResponse = searchListRequest.Execute();
                    nextPageToken = searchListResponse.NextPageToken;
                    if(searchListResponse.Items.Count < 50)
                    {

                    }
                    foreach (var searchResult in searchListResponse.Items)
                    {
                        try
                        {
                            var searchChannelRequest = ytServices[ytServicesCounter].Channels.List("id,snippet,statistics");
                            searchChannelRequest.Id = searchResult.Snippet.ChannelId;
                            var searchChannelResponse = searchChannelRequest.Execute();

                            string chaUrl = "https://www.youtube.com/channel/" + searchChannelResponse.Items[0].Id;

                            //downlload channel thumbnael 
                            Thumbnail thumbnail = searchChannelResponse.Items[0].Snippet.Thumbnails.High;

                            string dirPath = Directory.GetCurrentDirectory() + "/Thumbnails/";
                            if (!Directory.Exists(dirPath))
                            {
                                Directory.CreateDirectory(dirPath);
                            }
                            string thumbnailTitle = rowCounter.ToString() + " " + searchChannelResponse.Items[0].Snippet.Title.Replace(",", " ");
                            thumbnailTitle = Regex.Replace(thumbnailTitle, @"[^a-zA-Z0-9\-\s]", "");
                            string thumbnailPath = dirPath + "/" + thumbnailTitle + ".jpg";

                            while (true)
                            {
                                try
                                {
                                    webClient.DownloadFile(thumbnail.Url, thumbnailPath);
                                    break;
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }

                            //var searchChaVideosRequest = ytServices[ytServicesCounter].Search.List("snippet");
                            //searchChaVideosRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
                            //searchChaVideosRequest.ChannelId = searchResult.Id.ChannelId;
                            //var searchChaVideosResponce = await searchChaVideosRequest.ExecuteAsync();

                            string publicData = "n";
                            //foreach (var item in searchChaVideosResponce.Items)
                            //{
                            //    publicData += item.Snippet.Description;
                            //}

                            EmailFinder emailFinder = new EmailFinder();
                            string email = emailFinder.SearchEmail(searchResult.Snippet.Description.Replace(",", " ") + " " + searchChannelResponse.Items[0].Snippet.Description.Replace(",", " ") + " " + publicData.Replace(",", " "));
                            string links = emailFinder.SearchLinks(searchResult.Snippet.Description.Replace(",", " ") + " " + searchChannelResponse.Items[0].Snippet.Description.Replace(",", " ") + " " + publicData.Replace(",", " "));

                            string[] filter = new[] { ",", ";", "\"", "\n", "'", "\r", ".", ":" };
                            string chaDesc = searchChannelResponse.Items[0].Snippet.Description.Replace("\"", " ");
                            foreach (string f in filter)
                            {
                                chaDesc.Replace(f, " ");
                            }

                            YTDataModel yTDataModel = new YTDataModel
                            {
                                SNo = rowCounter,
                                //VideoUrl = "https://www.youtube.com/watch?v=" + searchResult.Id.VideoId,
                                //VideoTitle = searchVidioResponse.Items[0].Snippet.Title.Replace(",", " "),
                                //VideoDescription = searchResult.Snippet.Description.Replace(",", " "),
                                //VideoViews = searchVidioResponse.Items[0].Statistics.ViewCount.ToString(),
                                //VideoLikes = searchVidioResponse.Items[0].Statistics.LikeCount.ToString(),
                                //VideoDislikes = searchVidioResponse.Items[0].Statistics.DislikeCount.ToString(),
                                //VideoPublishedDate = searchVidioResponse.Items[0].Snippet.PublishedAt.ToString(),
                                ChannelName = searchChannelResponse.Items[0].Snippet.Title.Replace(",", " "),
                                ThumbnailPath = thumbnailTitle,
                                ChannelDescription = "\"" + chaDesc + "\"",
                                ChannelUrl = chaUrl,
                                ChannelSubscribers = searchChannelResponse.Items[0].Statistics.SubscriberCount.ToString(),
                                ChannelVideos = searchChannelResponse.Items[0].Statistics.VideoCount.ToString(),
                                ChannelViews = searchChannelResponse.Items[0].Statistics.ViewCount.ToString(),
                                //ChannelCreatedDate = searchChannelResponse.Items[0].Snippet.PublishedAt.ToString(),
                                Email = email,
                                Links = links
                            };
                            ytData.Add(yTDataModel);

                            delegateFromUI.DynamicInvoke(rowCounter.ToString() + "/" + ui.ScrapeRecordCount);
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

        public async Task<List<string>> GetChannelIdFromUrl(string[] channelUrlList)
        {
            List<string> channelIDs = new List<string>();
            foreach(var channelUrl in channelUrlList)
            {
                string sp = channelUrl.Split(new string[] { "www.youtube.com/" }, StringSplitOptions.None)[1];
                if(sp.Substring(0,7) == "channel")
                {
                    string channelId = sp.Substring(8, 24);
                    channelIDs.Add(channelId);
                }
                else
                {
                    string res = await new HttpClient().GetStringAsync(channelUrl);
                    try
                    {
                        string channelId = res.Split(new string[] { "www.youtube.com/channel/" }, StringSplitOptions.None)[1].Substring(0, 24);
                        channelIDs.Add(channelId);
                    }
                    catch (Exception)
                    {
                        string channelId = res.Split(new string[] { "/channel/" }, StringSplitOptions.None)[1].Substring(0, 24);
                        channelIDs.Add(channelId);
                        continue;
                    }
             
                }
            }
            return channelIDs;
        }
        

    }
}
