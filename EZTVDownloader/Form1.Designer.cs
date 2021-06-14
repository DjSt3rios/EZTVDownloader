namespace EZTVDownloader
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
            this.URLTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SeasonStartNumeric = new System.Windows.Forms.NumericUpDown();
            this.SeasonEndNumeric = new System.Windows.Forms.NumericUpDown();
            this.Browser = new Gecko.GeckoWebBrowser();
            this.HDCB = new System.Windows.Forms.CheckBox();
            this.episodeListLabel = new System.Windows.Forms.Label();
            this.downloadButton = new MetroFramework.Controls.MetroButton();
            this.BackButton = new MetroFramework.Controls.MetroButton();
            this.ForwardButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.loadingCircle1 = new MRG.Controls.UI.LoadingCircle();
            this.episodeListBox = new System.Windows.Forms.ListBox();
            this.magnetBtns = new MetroFramework.Controls.MetroButton();
            this.settingsBtn = new MetroFramework.Controls.MetroButton();
            this.reloadBtn = new MetroFramework.Controls.MetroButton();
            this.homeBtn = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.SeasonStartNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeasonEndNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // URLTB
            // 
            this.URLTB.Location = new System.Drawing.Point(154, 81);
            this.URLTB.Name = "URLTB";
            this.URLTB.Size = new System.Drawing.Size(401, 20);
            this.URLTB.TabIndex = 0;
            this.URLTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.URLTB_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(758, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "-";
            // 
            // SeasonStartNumeric
            // 
            this.SeasonStartNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SeasonStartNumeric.Location = new System.Drawing.Point(706, 82);
            this.SeasonStartNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SeasonStartNumeric.Name = "SeasonStartNumeric";
            this.SeasonStartNumeric.Size = new System.Drawing.Size(46, 20);
            this.SeasonStartNumeric.TabIndex = 5;
            this.SeasonStartNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SeasonStartNumeric.ValueChanged += new System.EventHandler(this.SeasonStartNumeric_ValueChanged);
            // 
            // SeasonEndNumeric
            // 
            this.SeasonEndNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SeasonEndNumeric.Location = new System.Drawing.Point(780, 82);
            this.SeasonEndNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SeasonEndNumeric.Name = "SeasonEndNumeric";
            this.SeasonEndNumeric.Size = new System.Drawing.Size(46, 20);
            this.SeasonEndNumeric.TabIndex = 6;
            this.SeasonEndNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SeasonEndNumeric.ValueChanged += new System.EventHandler(this.SeasonEndNumeric_ValueChanged);
            // 
            // Browser
            // 
            this.Browser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Browser.ConsoleMessageEventReceivesConsoleLogCalls = true;
            this.Browser.FrameEventsPropagateToMainWindow = false;
            this.Browser.Location = new System.Drawing.Point(16, 110);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(929, 468);
            this.Browser.TabIndex = 8;
            this.Browser.UseHttpActivityObserver = false;
            this.Browser.Navigating += new System.EventHandler<Gecko.Events.GeckoNavigatingEventArgs>(this.Browser_Navigating);
            this.Browser.Navigated += new System.EventHandler<Gecko.GeckoNavigatedEventArgs>(this.Browser_Navigated);
            this.Browser.DocumentCompleted += new System.EventHandler<Gecko.Events.GeckoDocumentCompletedEventArgs>(this.Browser_DocumentCompleted);
            this.Browser.CreateWindow += new System.EventHandler<Gecko.GeckoCreateWindowEventArgs>(this.Browser_CreateWindow);
            // 
            // HDCB
            // 
            this.HDCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HDCB.AutoSize = true;
            this.HDCB.Location = new System.Drawing.Point(279, 587);
            this.HDCB.Name = "HDCB";
            this.HDCB.Size = new System.Drawing.Size(93, 17);
            this.HDCB.TabIndex = 9;
            this.HDCB.Text = "Download HD";
            this.HDCB.UseVisualStyleBackColor = true;
            // 
            // episodeListLabel
            // 
            this.episodeListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.episodeListLabel.AutoSize = true;
            this.episodeListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.episodeListLabel.Location = new System.Drawing.Point(1029, 83);
            this.episodeListLabel.Name = "episodeListLabel";
            this.episodeListLabel.Size = new System.Drawing.Size(66, 15);
            this.episodeListLabel.TabIndex = 11;
            this.episodeListLabel.Text = "Episodes";
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.downloadButton.Location = new System.Drawing.Point(378, 584);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(216, 23);
            this.downloadButton.TabIndex = 12;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseSelectable = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click_1);
            // 
            // BackButton
            // 
            this.BackButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.BackButton.Location = new System.Drawing.Point(16, 79);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(33, 23);
            this.BackButton.Style = MetroFramework.MetroColorStyle.Black;
            this.BackButton.TabIndex = 13;
            this.BackButton.Text = "<";
            this.BackButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.BackButton.UseSelectable = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ForwardButton
            // 
            this.ForwardButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.ForwardButton.Location = new System.Drawing.Point(55, 79);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(33, 23);
            this.ForwardButton.Style = MetroFramework.MetroColorStyle.Black;
            this.ForwardButton.TabIndex = 14;
            this.ForwardButton.Text = ">";
            this.ForwardButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ForwardButton.UseSelectable = true;
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(634, 81);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 15;
            this.metroLabel1.Text = "Seasons:";
            // 
            // loadingCircle1
            // 
            this.loadingCircle1.Active = true;
            this.loadingCircle1.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle1.InnerCircleRadius = 6;
            this.loadingCircle1.Location = new System.Drawing.Point(569, 75);
            this.loadingCircle1.Name = "loadingCircle1";
            this.loadingCircle1.NumberSpoke = 9;
            this.loadingCircle1.OuterCircleRadius = 7;
            this.loadingCircle1.RotationSpeed = 100;
            this.loadingCircle1.Size = new System.Drawing.Size(33, 25);
            this.loadingCircle1.SpokeThickness = 4;
            this.loadingCircle1.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.Firefox;
            this.loadingCircle1.TabIndex = 16;
            this.loadingCircle1.Text = "loadingCircle1";
            this.loadingCircle1.Visible = false;
            // 
            // episodeListBox
            // 
            this.episodeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.episodeListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.episodeListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.episodeListBox.FormattingEnabled = true;
            this.episodeListBox.Location = new System.Drawing.Point(951, 110);
            this.episodeListBox.Name = "episodeListBox";
            this.episodeListBox.Size = new System.Drawing.Size(217, 459);
            this.episodeListBox.TabIndex = 17;
            this.episodeListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.episodeListBox_DrawItem);
            // 
            // magnetBtns
            // 
            this.magnetBtns.Location = new System.Drawing.Point(409, 29);
            this.magnetBtns.Name = "magnetBtns";
            this.magnetBtns.Size = new System.Drawing.Size(121, 21);
            this.magnetBtns.TabIndex = 18;
            this.magnetBtns.Text = "Setup Magnet Links";
            this.magnetBtns.UseSelectable = true;
            this.magnetBtns.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(553, 29);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(81, 21);
            this.settingsBtn.TabIndex = 19;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseSelectable = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // reloadBtn
            // 
            this.reloadBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reloadBtn.BackgroundImage")));
            this.reloadBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reloadBtn.Location = new System.Drawing.Point(94, 78);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(24, 24);
            this.reloadBtn.TabIndex = 20;
            this.reloadBtn.Text = " ";
            this.reloadBtn.UseSelectable = true;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.BackgroundImage = global::EZTVDownloader.Properties.Resources.home;
            this.homeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homeBtn.Location = new System.Drawing.Point(124, 79);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(24, 24);
            this.homeBtn.TabIndex = 21;
            this.homeBtn.Text = " ";
            this.homeBtn.UseSelectable = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 617);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.reloadBtn);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.magnetBtns);
            this.Controls.Add(this.episodeListBox);
            this.Controls.Add(this.loadingCircle1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.ForwardButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.episodeListLabel);
            this.Controls.Add(this.HDCB);
            this.Controls.Add(this.Browser);
            this.Controls.Add(this.SeasonEndNumeric);
            this.Controls.Add(this.SeasonStartNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.URLTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "EZTV Downloader";
            ((System.ComponentModel.ISupportInitialize)(this.SeasonStartNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeasonEndNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox URLTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown SeasonStartNumeric;
        private System.Windows.Forms.NumericUpDown SeasonEndNumeric;
        private Gecko.GeckoWebBrowser Browser;
        private System.Windows.Forms.CheckBox HDCB;
        private System.Windows.Forms.Label episodeListLabel;
        private MetroFramework.Controls.MetroButton downloadButton;
        private MetroFramework.Controls.MetroButton BackButton;
        private MetroFramework.Controls.MetroButton ForwardButton;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MRG.Controls.UI.LoadingCircle loadingCircle1;
        private System.Windows.Forms.ListBox episodeListBox;
        private MetroFramework.Controls.MetroButton magnetBtns;
        private MetroFramework.Controls.MetroButton settingsBtn;
        private MetroFramework.Controls.MetroButton reloadBtn;
        private MetroFramework.Controls.MetroButton homeBtn;
    }
}

