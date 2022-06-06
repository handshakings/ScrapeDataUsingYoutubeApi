using System;
using System.Windows.Forms;
using YTSearchQueryApiLib;

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
        }

        private void ImportApiKeys(object sender, EventArgs e)
        {
            ImportFile(label1);
        }
        private void ImportFile(Label label)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                label.Text = ofd.FileName;
            }
        }


        private void StartSearchQueryScraping(object sender, EventArgs e)
        {
            UserInput userInput = new UserInput
            {
                SearchQuery = textBox1.Text,
                NoOfVideos = double.Parse(comboBox1.Text),
                ApiKesyFile = label1.Text
            };

        }

    }
}
