# Get Youtube Data API V3 Key

Go to
- Google Developer console
- Create Project
- Create Credential
- Api Key
- Copy API Key
- Library
- Youtube Data API V3
- Enbale

Now you can test API by this url
https://www.googleapis.com/youtube/v3/search?key=AIzaSyC5lmdB4ynaUVE8xoXI5I-dL0WhW7rhY3Q&type=video&part=snippet&maxResults=5&q=faisalmasjid


Go to next page by Search Result NextPageToken
# Youtube API Resources
## Search Resource
* Video ID 		(Id.VideoId)
* Video Url		https://www.youtube.com/watch?v=VideoId
* Channel Id		(Snippet.ChannelId)
* Channel Title		(Snippet.ChanneTitle)
* Video Title		(Snipper.Title)
* Video Description	(Snippet.Description)
* Published At		(Snippet.PublishedAt)

## Video Resource
* Channel Id		(Snippet.ChannelId)
    - Channel Url https://www.youtube.com/channel/ChannelId 	(It works for all channels)
	- https://www.youtube.com/c/ChannelTitle 		(It works for channels having custom channel names only)
* Channel Title		(Snippet.ChanneTitle)
* Video Title		(Snipper.Title)
* Video Description	(Snippet.Description)
* Published At		(Snippet.PublishedAt)
* Video Views			(Statistics.ViewCount)
* Video Likes			(Statistics.LikeCount)
* Video Dislikes		(Statistics.DislikeCount)
* Video Comments Count		(Statistics.CommentCount)

## Channel Resource
* Channel Id		(Id)
* Channel Description (About page)	(Snippet.Description)
* Country			(Snippet.Country)
* Custom URL		(Snippet.CustomUrl)
* Channel Creation Date	(Snippet.PublishedAt)
* Channel Title		(Snippet.Title)
* Subscribers		(Statistics.SubscriberCount)
* Hidden Subscribers	(Statistics.HiddenSubscriberCount (True/false))
* Video Count		(Statistics.VideoCount)
* Total Views Count	(Statistics.ViewCount)
* Total Comment Count	(Statistics.CommentCount)