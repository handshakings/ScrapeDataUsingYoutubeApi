namespace ScrapperUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.vidURL = new System.Windows.Forms.CheckBox();
            this.vidTitle = new System.Windows.Forms.CheckBox();
            this.vidViews = new System.Windows.Forms.CheckBox();
            this.vidLikes = new System.Windows.Forms.CheckBox();
            this.vidDislikes = new System.Windows.Forms.CheckBox();
            this.vidPublishedDate = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chaName = new System.Windows.Forms.CheckBox();
            this.chaURL = new System.Windows.Forms.CheckBox();
            this.chaSubscribers = new System.Windows.Forms.CheckBox();
            this.chaVideos = new System.Windows.Forms.CheckBox();
            this.chaViews = new System.Windows.Forms.CheckBox();
            this.chaCreationDate = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.email = new System.Windows.Forms.CheckBox();
            this.socialLinks = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(196, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Import API Keys";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ImportApiKeys);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(370, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(196, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(662, 26);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search Query";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "No of Videos";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "50",
            "100",
            "150",
            "200",
            "250",
            "300",
            "350",
            "400",
            "450",
            "500",
            "550",
            "600",
            "650",
            "700",
            "750",
            "800",
            "850",
            "900",
            "950",
            "1000"});
            this.comboBox1.Location = new System.Drawing.Point(196, 116);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 26);
            this.comboBox1.TabIndex = 6;
            // 
            // vidURL
            // 
            this.vidURL.AutoSize = true;
            this.vidURL.Checked = true;
            this.vidURL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vidURL.Location = new System.Drawing.Point(25, 30);
            this.vidURL.Name = "vidURL";
            this.vidURL.Size = new System.Drawing.Size(61, 22);
            this.vidURL.TabIndex = 8;
            this.vidURL.Text = "URL";
            this.vidURL.UseVisualStyleBackColor = true;
            // 
            // vidTitle
            // 
            this.vidTitle.AutoSize = true;
            this.vidTitle.Checked = true;
            this.vidTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vidTitle.Location = new System.Drawing.Point(25, 58);
            this.vidTitle.Name = "vidTitle";
            this.vidTitle.Size = new System.Drawing.Size(61, 22);
            this.vidTitle.TabIndex = 9;
            this.vidTitle.Text = "Title";
            this.vidTitle.UseVisualStyleBackColor = true;
            // 
            // vidViews
            // 
            this.vidViews.AutoSize = true;
            this.vidViews.Checked = true;
            this.vidViews.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vidViews.Location = new System.Drawing.Point(25, 86);
            this.vidViews.Name = "vidViews";
            this.vidViews.Size = new System.Drawing.Size(74, 22);
            this.vidViews.TabIndex = 10;
            this.vidViews.Text = "Views";
            this.vidViews.UseVisualStyleBackColor = true;
            // 
            // vidLikes
            // 
            this.vidLikes.AutoSize = true;
            this.vidLikes.Checked = true;
            this.vidLikes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vidLikes.Location = new System.Drawing.Point(25, 114);
            this.vidLikes.Name = "vidLikes";
            this.vidLikes.Size = new System.Drawing.Size(69, 22);
            this.vidLikes.TabIndex = 11;
            this.vidLikes.Text = "Likes";
            this.vidLikes.UseVisualStyleBackColor = true;
            // 
            // vidDislikes
            // 
            this.vidDislikes.AutoSize = true;
            this.vidDislikes.Checked = true;
            this.vidDislikes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vidDislikes.Location = new System.Drawing.Point(25, 142);
            this.vidDislikes.Name = "vidDislikes";
            this.vidDislikes.Size = new System.Drawing.Size(88, 22);
            this.vidDislikes.TabIndex = 12;
            this.vidDislikes.Text = "Dislikes";
            this.vidDislikes.UseVisualStyleBackColor = true;
            // 
            // vidPublishedDate
            // 
            this.vidPublishedDate.AutoSize = true;
            this.vidPublishedDate.Checked = true;
            this.vidPublishedDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vidPublishedDate.Location = new System.Drawing.Point(25, 170);
            this.vidPublishedDate.Name = "vidPublishedDate";
            this.vidPublishedDate.Size = new System.Drawing.Size(147, 22);
            this.vidPublishedDate.TabIndex = 13;
            this.vidPublishedDate.Text = "Published Date";
            this.vidPublishedDate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vidPublishedDate);
            this.groupBox1.Controls.Add(this.vidURL);
            this.groupBox1.Controls.Add(this.vidDislikes);
            this.groupBox1.Controls.Add(this.vidTitle);
            this.groupBox1.Controls.Add(this.vidLikes);
            this.groupBox1.Controls.Add(this.vidViews);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(28, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 205);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chaName);
            this.groupBox2.Controls.Add(this.chaURL);
            this.groupBox2.Controls.Add(this.chaSubscribers);
            this.groupBox2.Controls.Add(this.chaVideos);
            this.groupBox2.Controls.Add(this.chaViews);
            this.groupBox2.Controls.Add(this.chaCreationDate);
            this.groupBox2.ForeColor = System.Drawing.Color.Silver;
            this.groupBox2.Location = new System.Drawing.Point(224, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 205);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channel";
            // 
            // chaName
            // 
            this.chaName.AutoSize = true;
            this.chaName.Checked = true;
            this.chaName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chaName.Location = new System.Drawing.Point(29, 30);
            this.chaName.Name = "chaName";
            this.chaName.Size = new System.Drawing.Size(73, 22);
            this.chaName.TabIndex = 13;
            this.chaName.Text = "Name";
            this.chaName.UseVisualStyleBackColor = true;
            // 
            // chaURL
            // 
            this.chaURL.AutoSize = true;
            this.chaURL.Checked = true;
            this.chaURL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chaURL.Location = new System.Drawing.Point(29, 58);
            this.chaURL.Name = "chaURL";
            this.chaURL.Size = new System.Drawing.Size(61, 22);
            this.chaURL.TabIndex = 8;
            this.chaURL.Text = "URL";
            this.chaURL.UseVisualStyleBackColor = true;
            // 
            // chaSubscribers
            // 
            this.chaSubscribers.AutoSize = true;
            this.chaSubscribers.Checked = true;
            this.chaSubscribers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chaSubscribers.Location = new System.Drawing.Point(28, 86);
            this.chaSubscribers.Name = "chaSubscribers";
            this.chaSubscribers.Size = new System.Drawing.Size(124, 22);
            this.chaSubscribers.TabIndex = 12;
            this.chaSubscribers.Text = "Subscribers";
            this.chaSubscribers.UseVisualStyleBackColor = true;
            // 
            // chaVideos
            // 
            this.chaVideos.AutoSize = true;
            this.chaVideos.Checked = true;
            this.chaVideos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chaVideos.Location = new System.Drawing.Point(29, 114);
            this.chaVideos.Name = "chaVideos";
            this.chaVideos.Size = new System.Drawing.Size(81, 22);
            this.chaVideos.TabIndex = 9;
            this.chaVideos.Text = "Videos";
            this.chaVideos.UseVisualStyleBackColor = true;
            // 
            // chaViews
            // 
            this.chaViews.AutoSize = true;
            this.chaViews.Checked = true;
            this.chaViews.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chaViews.Location = new System.Drawing.Point(28, 142);
            this.chaViews.Name = "chaViews";
            this.chaViews.Size = new System.Drawing.Size(74, 22);
            this.chaViews.TabIndex = 11;
            this.chaViews.Text = "Views";
            this.chaViews.UseVisualStyleBackColor = true;
            // 
            // chaCreationDate
            // 
            this.chaCreationDate.AutoSize = true;
            this.chaCreationDate.Checked = true;
            this.chaCreationDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chaCreationDate.Location = new System.Drawing.Point(28, 170);
            this.chaCreationDate.Name = "chaCreationDate";
            this.chaCreationDate.Size = new System.Drawing.Size(138, 22);
            this.chaCreationDate.TabIndex = 10;
            this.chaCreationDate.Text = "Creation Date";
            this.chaCreationDate.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.email);
            this.groupBox3.Controls.Add(this.socialLinks);
            this.groupBox3.ForeColor = System.Drawing.Color.Silver;
            this.groupBox3.Location = new System.Drawing.Point(420, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 205);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Misc";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Checked = true;
            this.email.CheckState = System.Windows.Forms.CheckState.Checked;
            this.email.Location = new System.Drawing.Point(26, 30);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(70, 22);
            this.email.TabIndex = 9;
            this.email.Text = "Email";
            this.email.UseVisualStyleBackColor = true;
            // 
            // socialLinks
            // 
            this.socialLinks.AutoSize = true;
            this.socialLinks.Checked = true;
            this.socialLinks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.socialLinks.Location = new System.Drawing.Point(26, 58);
            this.socialLinks.Name = "socialLinks";
            this.socialLinks.Size = new System.Drawing.Size(122, 22);
            this.socialLinks.TabIndex = 8;
            this.socialLinks.Text = "Social Links";
            this.socialLinks.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Silver;
            this.button2.Location = new System.Drawing.Point(711, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 79);
            this.button2.TabIndex = 17;
            this.button2.Text = "Start Scraping";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.StartSearchQueryScraping);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(727, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 33);
            this.label4.TabIndex = 18;
            this.label4.Text = "label4";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(897, 431);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(889, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search Query Bot";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "Select API Key File";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(889, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "List of Pages";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Silver;
            this.button5.Location = new System.Drawing.Point(371, 161);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(147, 79);
            this.button5.TabIndex = 26;
            this.button5.Text = "Start Scraping";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.StartChannelsListScrapping);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 18);
            this.label8.TabIndex = 25;
            this.label8.Text = "Select List of Pages";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(400, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "label9";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(192, 61);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(202, 26);
            this.button4.TabIndex = 23;
            this.button4.Text = "Import List of Pages";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.ImportApiKeys);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "Select API Key File";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(400, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "label7";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(192, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(202, 26);
            this.button3.TabIndex = 20;
            this.button3.Text = "Import API Keys";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.ImportApiKeys);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "50",
            "100",
            "150",
            "200",
            "250",
            "300",
            "350",
            "400",
            "450",
            "500",
            "550",
            "600",
            "650",
            "700",
            "750",
            "800",
            "850",
            "900",
            "950",
            "1000"});
            this.comboBox2.Location = new System.Drawing.Point(243, 115);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(107, 26);
            this.comboBox2.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(72, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 18);
            this.label10.TabIndex = 27;
            this.label10.Text = "No of Videos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(921, 456);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Silver;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Youtube Bot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox vidURL;
        private System.Windows.Forms.CheckBox vidTitle;
        private System.Windows.Forms.CheckBox vidViews;
        private System.Windows.Forms.CheckBox vidLikes;
        private System.Windows.Forms.CheckBox vidDislikes;
        private System.Windows.Forms.CheckBox vidPublishedDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chaName;
        private System.Windows.Forms.CheckBox chaURL;
        private System.Windows.Forms.CheckBox chaSubscribers;
        private System.Windows.Forms.CheckBox chaVideos;
        private System.Windows.Forms.CheckBox chaViews;
        private System.Windows.Forms.CheckBox chaCreationDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox socialLinks;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label10;
    }
}

