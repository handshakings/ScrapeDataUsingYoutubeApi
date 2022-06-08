using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using YTSearchQueryLib;

namespace ScrapperUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        
        private void ImportApiKeys(object sender, EventArgs e)
        {
            if(((Button)sender).Name == button1.Name)
            {
                ImportFile(label1);
            }
            else if (((Button)sender).Name == button3.Name)
            {
                ImportFile(label7);
            }
            else if (((Button)sender).Name == button4.Name)
            {
                ImportFile(label9);
            }

        }
        private void ImportFile(Label label)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                label.Text = ofd.FileName;
            }
        }


        private async void StartSearchQueryScraping(object sender, EventArgs e)
        {
            UserInput userInput = new UserInput
            {
                SearchQuery = textBox1.Text,
                NoOfVideos = double.Parse(comboBox1.Text),
                ApiKeys = File.ReadAllText(label1.Text).Split('\n')
            };
         
            YTSearchQueryUI yTSearchQueryUI = new YTSearchQueryUI();
            string ui = JsonConvert.SerializeObject(userInput);
            string ytData = await yTSearchQueryUI.GetYTDataUIAsync(ui);
            List<YTDataModel> ytDataModels = JsonConvert.DeserializeObject<List<YTDataModel>>(ytData);
            FillDataInCsv(ytDataModels);
        }

        private async void StartChannelsListScrapping(object sender, EventArgs e)
        {
            UserInput userInput = new UserInput
            {
                NoOfVideos = double.Parse(comboBox2.Text),
                ApiKeys = File.ReadAllText(label7.Text).Split('\n')
            };
            string[] channelsList = File.ReadAllText(label9.Text).Split('\n');
            YTSearchQueryUI yTSearchQueryUI = new YTSearchQueryUI();
            string ui = JsonConvert.SerializeObject(userInput);
            await yTSearchQueryUI.GetYTDataUIAsync(ui, channelsList);
        }


        private void FillDataInCsv(List<YTDataModel> ytDataModels)
        {
            FileStream fileStream = new FileStream(textBox1.Text + ".csv", FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(BuildHeader());
            int rowCounter = 1;
            foreach(YTDataModel model in ytDataModels)
            {
                writer.WriteLine(BuildRow(model,rowCounter));
                writer.Flush();
                fileStream.Flush();
                rowCounter++;
            }
            writer.Close();
            fileStream.Close();
        }
        private string BuildHeader()
        {
            string header = "SNo";
            header = (vidURL.Checked) ? header+",Video URL" : header;
            header = (vidTitle.Checked) ? header+",Video Title" : header;
            header = (vidViews.Checked) ? header+",Video Views" : header;
            header = (vidLikes.Checked) ? header+",Video LIkes" : header;
            header = (vidDislikes.Checked) ? header+",Video Dislikes" : header;
            header = (vidPublishedDate.Checked) ? header+",Video Published Date" : header;
            header = (chaName.Checked) ? header+",Channel Name" : header;
            header = (chaURL.Checked) ? header+",Channel URL" : header;
            header = (chaSubscribers.Checked) ? header+",Channel Subscribers" : header;
            header = (chaVideos.Checked) ? header+",Channel Videos" : header;
            header = (chaViews.Checked) ? header+",Channel Views" : header;
            header = (chaCreationDate.Checked) ? header+",Channel Creation Date" : header;
            header = (email.Checked) ? header+",Email" : header;
            header = (socialLinks.Checked) ? header+",Social Links" : header;
            return header;
        }
        private string BuildRow(YTDataModel ytDataModel, int sno)
        {
            string row = sno.ToString();
            row = (vidURL.Checked) ? row + ","+ytDataModel.VideoUrl : row;
            row = (vidTitle.Checked) ? row + ","+ytDataModel.VideoTitle : row;
            row = (vidViews.Checked) ? row + ","+ytDataModel.VideoViews : row;
            row = (vidLikes.Checked) ? row + ","+ytDataModel.VideoLikes : row;
            row = (vidDislikes.Checked) ? row + ","+ytDataModel.VideoDislikes : row;
            row = (vidPublishedDate.Checked) ? row + ","+ytDataModel.VideoPublishedDate : row;
            row = (chaName.Checked) ? row + ","+ytDataModel.ChannelName : row;
            row = (chaURL.Checked) ? row + ","+ytDataModel.ChannelUrl : row;
            row = (chaSubscribers.Checked) ? row + ","+ytDataModel.ChannelSubscribers : row;
            row = (chaVideos.Checked) ? row + ","+ytDataModel.ChannelVideos : row;
            row = (chaViews.Checked) ? row + ","+ytDataModel.ChannelViews : row;
            row = (chaCreationDate.Checked) ? row + ","+ytDataModel.ChannelCreatedDate : row;
            row = (email.Checked) ? row + "," + "\"" + ytDataModel.Email.Trim() + "\"" : row;
            row = (email.Checked) ? row + "," + "\"" + ytDataModel.Links.Trim() + "\"" : row;
            return row;
        }

        
    }
}
