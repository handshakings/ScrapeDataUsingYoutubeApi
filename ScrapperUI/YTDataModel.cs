namespace ScrapperUI
{
    class YTDataModel
    {
        public int SNo { get; set; }
        //Video
        public string VideoUrl { get; set; }
        public string VideoTitle { get; set; }
        public string VideoDescription { get; set; }
        public string VideoViews { get; set; }
        public string VideoLikes { get; set; }
        public string VideoDislikes { get; set; }
        public string VideoPublishedDate { get; set; }

        //Channel
        public string ChannelName { get; set; }
        public string ChannelDescription { get; set; }
        public string ChannelUrl { get; set; }
        public string ChannelSubscribers { get; set; }
        public string ChannelVideos { get; set; }
        public string ChannelViews { get; set; }
        public string ChannelCreatedDate { get; set; }
        public string Email { get; set; }
        public string Links { get; set; }

        public string BuildDataRow(YTDataModel yTDataModel)
        {
            string data = yTDataModel.SNo+
                ","+VideoUrl+
                ","+VideoTitle+
                ","+VideoViews+
                ","+VideoLikes+
                ","+VideoDislikes+
                ","+VideoPublishedDate+
                ","+ChannelName+
                ","+ChannelUrl+
                ","+ChannelSubscribers+
                ","+ChannelVideos+
                ","+ChannelViews+
                ","+ChannelCreatedDate+
                "," + "\"" + Email.Trim() + "\"" +
                "," + "\"" + Links.Trim() + "\"" +
                "\n";
            return data;
        }
    }
}
