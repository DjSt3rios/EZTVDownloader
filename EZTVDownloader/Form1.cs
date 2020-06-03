using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZTVDownloader.Classes;
using Gecko;
using Gecko.Collections;
using MetroFramework.Forms;

namespace EZTVDownloader
{
    public partial class Form1 : MetroForm
    {
        private Task downloadTask;
        private GeckoWebBrowser dummyBrowser = new GeckoWebBrowser();
        // private IDomHtmlCollection<GeckoElement> links; WIP
        // private List<EpisodeData> episodes; WIP

        public Form1()
        {
            InitializeComponent();
            //Browser.Navigate("https://eztv.io/showlist/");
            Browser.Navigate("https://eztv.io/shows/449/10-oclock-live/");
            dummyBrowser.DocumentCompleted += _dummyBrowser_DocumentCompleted;
        }


        private void download()
        {
            // Here we begin opening magnet links
            int episode = 1;
            int season = int.Parse(SeasonStartNumeric.Value.ToString());
            var episoderows = dummyBrowser.Document.GetElementsByTagName("a");

            // Delete non-magnet links
            for (uint i = episoderows.Length - 1; i > 0; i--)
            {
                if ((episoderows[i].ClassName == null) || !episoderows[i].ClassName.Equals("magnet"))
                {
                    episoderows[i].ParentNode.RemoveChild(episoderows[i]);
                }
            }

            // Now we begin the real process of finding the magnet links and opening them.

            bool complete = false;
            bool skip_check = false;
            while (complete == false)
            {
                bool epfound = false;
                foreach (var row in episoderows)
                {
                    try
                    {
                        if (!row.HasAttribute("href")) continue; // This should never happen, but just in case...
                        if (row.ClassName.Equals("magnet"))
                        {
                            if (HDCB.Checked) // Try to find HD Version
                            {
                                if (row.GetAttribute("title").Contains(season + "x" + episode.ToString("00")) && row.GetAttribute("title").Contains("720p") || row.GetAttribute("title").Contains("S" + season.ToString("00") + "E" + episode.ToString("00")) && row.GetAttribute("title").Contains("720p"))
                                {
                                    if (skip_check)
                                    {
                                        AddEpisodeToList("Season: " + season.ToString("00") + " Episode: " + (episode - 1).ToString("00"), false);
                                    }
                                    Browser.Navigate(row.GetAttribute("href"));
                                    AddEpisodeToList("Season: " + season.ToString("00") + " Episode: " + episode.ToString("00"));
                                    episode++;
                                    epfound = true;
                                    skip_check = false;
                                    break;
                                }
                                // HD version not found. Check for normal version
                                if (row.GetAttribute("title").Contains(season + "x" + episode.ToString("00")) || row.GetAttribute("title").Contains("S" + season.ToString("00") + "E" + episode.ToString("00")))
                                {
                                    if (skip_check)
                                    {
                                        AddEpisodeToList("Season: " + season.ToString("00") + " Episode: " + (episode - 1).ToString("00"), false);
                                    }
                                    Browser.Navigate(row.GetAttribute("href"));
                                    AddEpisodeToList("Season: " + season.ToString("00") + " Episode: " + episode.ToString("00"));
                                    episode++;
                                    epfound = true;
                                    skip_check = false;
                                    break;
                                }
                            }
                            else
                            {
                                // Looking for Non HD version.
                                if (row.GetAttribute("title").Contains(season + "x" + episode.ToString("00")) && !row.GetAttribute("title").Contains("720p") || row.GetAttribute("title").Contains("S" + season.ToString("00") + "E" + episode.ToString("00")) && !row.GetAttribute("title").Contains("720p"))
                                {
                                    if (skip_check)
                                    {
                                        AddEpisodeToList("Season: " + season.ToString("00") + " Episode: " + (episode - 1).ToString("00"), false);
                                    }
                                    Browser.Navigate(row.GetAttribute("href"));
                                    AddEpisodeToList("Season: " + season.ToString("00") + " Episode: " + episode.ToString("00"));
                                    episode++;
                                    epfound = true;
                                    skip_check = false;
                                    break;
                                }
                                // Non HD version not found. We'll get the HD version if available.
                                if (row.GetAttribute("title").Contains(season + "x" + episode.ToString("00")) || row.GetAttribute("title").Contains("S" + season.ToString("00") + "E" + episode.ToString("00")))
                                {
                                    if (skip_check)
                                    {
                                        AddEpisodeToList("Season: " + season.ToString("00") + " Episode: " + (episode - 1).ToString("00"), false);
                                    }
                                    Browser.Navigate(row.GetAttribute("href"));
                                    AddEpisodeToList("Season: " + season.ToString("00") + " Episode: " + episode.ToString("00"));
                                    episode++;
                                    epfound = true;
                                    skip_check = false;
                                    break;
                                }
                            }

                        }
                    }
                    catch { }
                }
                if (!epfound)
                {
                    // Episode not found! Search once more, in case 1 ep is missing.
                    if (skip_check == false)
                    {
                        skip_check = true;
                        episode++;
                        continue;
                    }
                    // Episode not found again. Change season.
                    season++;
                    episode = 1;
                    skip_check = false;
                    if (season > int.Parse(SeasonEndNumeric.Value.ToString()))
                    {
                        complete = true;
                    }
                }

            }
            setControlState(true);
        }

        private void _dummyBrowser_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            download();
            Console.WriteLine("Starting download.");
        }

        private void URLTB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Browser.Navigate(URLTB.Text);
            }
        }

        private void Browser_Navigated(object sender, Gecko.GeckoNavigatedEventArgs e)
        {
            URLTB.Text = Browser.Url.AbsoluteUri;
        }

        private void Browser_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            loadingCircle1.Visible = false;
        }

        private void setControlState(bool state)
        {
            HDCB.Enabled = state;
            downloadButton.Enabled = state;
            SeasonStartNumeric.Enabled = state;
            SeasonEndNumeric.Enabled = state;
        }

        private void downloadButton_Click_1(object sender, EventArgs e)
        {
            if(SeasonStartNumeric.Value > SeasonEndNumeric.Value)
            {
                MessageBox.Show("The selected seasons seem to be wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Check if browser is still loading
            if (Browser.IsBusy)
            {
                MessageBox.Show("The browser is still loading, please wait.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var eptable = Browser.Document.GetElementsByClassName("forum_header_noborder");
            if(eptable.Length == 0) 
            {
                MessageBox.Show("No episodes found. Please select a TV show first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            setControlState(false);
            episodeListBox.Items.Clear();
            var eps = eptable[0] as GeckoHtmlElement;
            dummyBrowser.LoadHtml(eps.InnerHtml);
        }

        private void Browser_Navigating(object sender, Gecko.Events.GeckoNavigatingEventArgs e)
        {
            loadingCircle1.Visible = true;
        }

        private void AddEpisodeToList(string text, bool successful = true)
        {
            episodeListBox.Items.Add(text + (successful ? " - Found" : " - Missing"));
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Browser.GoBack();
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            Browser.GoForward();
        }

        private void episodeListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;

            var text = episodeListBox.Items[e.Index].ToString();
            var color = text.Contains("Found") ? Color.DarkGreen : Color.DarkRed;
            g.DrawString(text, e.Font, new SolidBrush(color), new PointF(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        private void SeasonStartNumeric_ValueChanged(object sender, EventArgs e)
        {
            if(SeasonStartNumeric.Value > SeasonEndNumeric.Value)
            {
                SeasonEndNumeric.Value = SeasonStartNumeric.Value;
            }
        }

        private void SeasonEndNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (SeasonEndNumeric.Value < SeasonStartNumeric.Value)
            {
                SeasonStartNumeric.Value = SeasonEndNumeric.Value;
            }
        }

        private void Browser_CreateWindow(object sender, GeckoCreateWindowEventArgs e)
        {
            e.Cancel = true;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select your client and check the 'Remember my choice' checkbox. You only have to do this once!");
            Browser.Navigate("magnet:");
        }
    }
}
