using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using YTSearchQueryLib;

namespace ScrapperUI
{
    public partial class Form1 : Form
    {
        public delegate void LabelUpdaterDelegate(string a);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        public void UpdateLabel(string scrappedRowCount)
        {
            label4.Text = scrappedRowCount;
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
            else if (((Button)sender).Name == button9.Name)
            {
                ImportFile(label12);
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


        private void StartScrapping(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if(label1.Text != "" && textBox1.Text != "")
                {
                    button7.Enabled = false;
                    button2.Text = "Scrapping...";
                    StartSearchQueryVideoScraping();
                    button7.Text = "Open "+textBox1.Text + ".csv";
                }
                else
                {
                    MessageBox.Show("Please provide all inputs");
                }  
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                if (label7.Text != "" && label9.Text != "")
                {
                    button7.Enabled = false;
                    button2.Text = "Scrapping...";
                    StartChannelsListScrapping();
                    button7.Text = "Open Pages list.csv";
                }
                else
                {
                    MessageBox.Show("Please provide file(s)");
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (label12.Text != "" && textBox2.Text != "")
                {
                    button7.Enabled = false;
                    button2.Text = "Scrapping...";
                    StartSearchQueryChannelScraping();
                    button7.Text = "Open Pages list.csv";
                }
                else
                {
                    MessageBox.Show("Please provide file(s)");
                }
            }
        }
        private async void StartSearchQueryVideoScraping()
        {
            UserInput userInput = new UserInput
            {
                SearchQuery = textBox1.Text,
                ScrapeRecordCount = double.Parse(comboBox1.Text),
                ApiKeys = File.ReadAllText(label1.Text).Split('\n')
            };
            YTSearchQueryUI yTSearchQueryUI = new YTSearchQueryUI();
            string ui = JsonConvert.SerializeObject(userInput);
            string ytData = await yTSearchQueryUI.ScrapeVideosBySearchQuery(ui,new LabelUpdaterDelegate(UpdateLabel));
            List<YTDataModel> ytDataModels = JsonConvert.DeserializeObject<List<YTDataModel>>(ytData);
            FillDataInCsv(ytDataModels);
            button2.Text = "Start Scrapping";
            button7.Enabled = true;
        }

        private async void StartSearchQueryChannelScraping()
        {
            UserInput userInput = new UserInput
            {
                SearchQuery = textBox2.Text,
                ScrapeRecordCount = double.Parse(comboBox3.Text),
                ApiKeys = File.ReadAllText(label12.Text).Split('\n')
            };
            YTSearchQueryUI yTSearchQueryUI = new YTSearchQueryUI();
            string ui = JsonConvert.SerializeObject(userInput);
            string ytData = await yTSearchQueryUI.ScrapeChannelsBySearchQuery(ui, new LabelUpdaterDelegate(UpdateLabel));
            List<YTDataModel> ytDataModels = JsonConvert.DeserializeObject<List<YTDataModel>>(ytData);
            FillDataInCsv(ytDataModels);
            button2.Text = "Start Scrapping";
            button7.Enabled = true;
        }
        private async void StartChannelsListScrapping()
        {
            UserInput userInput = new UserInput
            {
                ScrapeRecordCount = double.Parse(comboBox2.Text),
                ApiKeys = File.ReadAllText(label7.Text).Split('\n')
            };
            string[] channelsList = File.ReadAllText(label9.Text).Split('\n');
            YTSearchQueryUI yTSearchQueryUI = new YTSearchQueryUI();
            string ui = JsonConvert.SerializeObject(userInput);
            string ytData = await yTSearchQueryUI.ScrapeChannelsByChannelsList(ui, channelsList, new LabelUpdaterDelegate(UpdateLabel));
            List<YTDataModel> ytDataModels = JsonConvert.DeserializeObject<List<YTDataModel>>(ytData);
            FillDataInCsv(ytDataModels);
            button2.Text = "Start Scrapping";
            button7.Enabled = true;
        }


        private void FillDataInCsv(List<YTDataModel> ytDataModels)
        {
            string name = textBox1.Text != "" ? textBox1.Text + ".csv" :
                          textBox2.Text != "" ? textBox2.Text + ".csv" :
                          "Pages list.csv";

            FileStream fileStream = new FileStream(name, FileMode.Append);
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
            header = (chaDescription.Checked) ? header+",Channel Description" : header;
            header = (chaURL.Checked) ? header+",Channel URL" : header;
            header = (chaSubscribers.Checked) ? header+",Channel Subscribers" : header;
            header = (chaVideos.Checked) ? header+",Channel Videos" : header;
            header = (chaViews.Checked) ? header+",Channel Views" : header;
            header = (chaCreationDate.Checked) ? header+",Channel Creation Date" : header;
            header = (chaThumbnail.Checked) ? header+",Thumbnail Path" : header;
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
            row = (chaDescription.Checked) ? row + ","+ytDataModel.ChannelDescription : row;
            row = (chaURL.Checked) ? row + ","+ytDataModel.ChannelUrl : row;
            row = (chaSubscribers.Checked) ? row + ","+ytDataModel.ChannelSubscribers : row;
            row = (chaVideos.Checked) ? row + ","+ytDataModel.ChannelVideos : row;
            row = (chaViews.Checked) ? row + ","+ytDataModel.ChannelViews : row;
            row = (chaCreationDate.Checked) ? row + ","+ytDataModel.ChannelCreatedDate : row;
            row = (chaThumbnail.Checked) ? row + ","+ytDataModel.ThumbnailPath : row;
            row = (email.Checked) ? row + "," + "\"" + ytDataModel.Email.Trim() + "\"" : row;
            row = (email.Checked) ? row + "," + "\"" + ytDataModel.Links.Trim() + "\"" : row;
            return row;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label4.Text = "";
            textBox1.Text = "";
            button7.Text = "Open CSV File";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            label7.Text = "";
            label4.Text = "";
            button7.Text = "Open CSV File";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string csvFileName = button7.Text.Substring(5);
            Process.Start(csvFileName);
        }


    }
}
