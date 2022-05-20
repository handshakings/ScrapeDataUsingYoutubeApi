using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.IO;
using System.Threading.Tasks;

namespace YTSeachByAPIV3
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
            FileStream fileStream = new FileStream(searchQuery+".csv", FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine("SNo,Video URL,Video Title,Video Views,Video Likes,Video Dislikes,Published Date,Channel Name,Channel URL,Subscribers,Total Videos,Total Views,Channel Created Date,Email,Social Links");

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = (apiKey.Length > 30 ) ? apiKey : "AIzaSyC5lmdB4ynaUVE8xoXI5I-dL0WhW7rhY3Q",
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
                            var searchVidioResponse = await searchVidioRequest.ExecuteAsync();

                            var searchChannelRequest = youtubeService.Channels.List("id,snippet,statistics");
                            searchChannelRequest.Id = searchResult.Snippet.ChannelId;
                            var searchChannelResponse = await searchChannelRequest.ExecuteAsync();

                            var searchCommentsRequest = youtubeService.CommentThreads.List("id,snippet,replies");
                            searchCommentsRequest.TextFormat = CommentThreadsResource.ListRequest.TextFormatEnum.PlainText;
                            searchCommentsRequest.VideoId = searchResult.Id.VideoId;
                            var searchCommentsResponse = await searchCommentsRequest.ExecuteAsync();
                            string commentAndReplyText = GetAllCommentsAndReplies(searchCommentsResponse,searchCommentsRequest);
                            string email = EmailFinder.SearchEmail(searchResult.Snippet.Description + " " + searchChannelResponse.Items[0].Snippet.Description + " " + commentAndReplyText);
                            string links = EmailFinder.SearchLinks(searchResult.Snippet.Description + " " + searchChannelResponse.Items[0].Snippet.Description + " " + commentAndReplyText);

                            YTDataModel yTDataModel = new YTDataModel
                            {
                                SNo = rowCounter,
                                VideoUrl = "https://www.youtube.com/watch?v=" + searchResult.Id.VideoId,
                                VideoTitle = searchResult.Snippet.Title.Replace(",", " "),
                                VideoDescription = searchResult.Snippet.Description.Replace(","," "),
                                VideoViews = searchVidioResponse.Items[0].Statistics.ViewCount.ToString(),
                                VideoLikes = searchVidioResponse.Items[0].Statistics.LikeCount.ToString(),
                                VideoDislikes = searchVidioResponse.Items[0].Statistics.DislikeCount.ToString(),
                                VideoPublishedDate = searchVidioResponse.Items[0].Snippet.PublishedAt.ToString(),
                                ChannelName = searchChannelResponse.Items[0].Snippet.Title.Replace(",", " "),
                                ChannelDescription = searchChannelResponse.Items[0].Snippet.Description.Replace(","," "),
                                ChannelUrl = "https://www.youtube.com/channel/" + searchChannelResponse.Items[0].Id,
                                ChannelSubscribers = searchChannelResponse.Items[0].Statistics.SubscriberCount.ToString(),
                                ChannelVideos = searchChannelResponse.Items[0].Statistics.VideoCount.ToString(),
                                ChannelViews = searchChannelResponse.Items[0].Statistics.ViewCount.ToString(),
                                ChannelCreatedDate = searchChannelResponse.Items[0].Snippet.PublishedAt.ToString(),
                                Email = email,
                                Links = links
                            };
                            
                            writer.Write(yTDataModel.BuildDataRow(yTDataModel));
                            writer.Flush();
                            fileStream.Flush();
                            
                            Console.WriteLine(rowCounter + "\t" + searchResult.Snippet.Title);
                            rowCounter++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            rowCounter++;
                            continue;
                        }  
                    }
                    pageCounter++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    pageCounter++;
                    continue;
                }  
            }
            writer.Close();
            fileStream.Close();
            Console.ReadLine();
        }

        public static string GetAllCommentsAndReplies(CommentThreadListResponse searchCommentsResponse, CommentThreadsResource.ListRequest searchCommentsRequest)
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
