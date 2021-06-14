using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private List<EpisodeData> episodeList = new List<EpisodeData>();

        public Form1()
        {
            InitializeComponent();
            try
            {
                Browser.Navigate(Properties.Settings.Default.InitialURL);
            }
            catch
            {
                MessageBox.Show("There was a problem navigating to your configured URL, please make sure it's correct.\nEnsure you include the HTTP/HTTPS protocol.","Navigation error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void addEpisodeData(int season,int episode, string url, bool hd)
        {
            EpisodeData newEpisode = new EpisodeData(season, episode, url, hd);
            if(episodeList.Contains(newEpisode))
            {
                if (hd && !newEpisode.HasHD())
                {
                    newEpisode.SetURL(url, true);
                }
                if (!hd && newEpisode.GetURL() == null)
                {
                    newEpisode.SetURL(url);
                }
            }
            else
            {
                episodeList.Add(newEpisode);
            }
            
        }

        private void download()
        {
            // Here we are getting all links
            int seasonStart = int.Parse(SeasonStartNumeric.Value.ToString());
            int seasonEnd = int.Parse(SeasonEndNumeric.Value.ToString());
            var links = Browser.Document.GetElementsByTagName("a");

            // Select only magnet links
            var episodes =
                from attribute in links
                where attribute.ClassName.Equals("magnet")
                select attribute;


            // Now we begin the real process of finding the magnet links and opening them.
            int tempSeason = 0;
            foreach (var episode in episodes)
            {
                try
                {
                    tempSeason = getSeasonNumber(episode);
                    if(tempSeason >= seasonStart && tempSeason <= seasonEnd)
                    {
                        addEpisodeData(tempSeason, getEpisodeNumber(episode), episode.GetAttribute("href"), episode.GetAttribute("href").Contains("720p") || episode.GetAttribute("href").Contains("1080p"));
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error parsing episode data: " + error.Message);
                }
            }

            // Now navigate to the magnet link
            foreach(var episode in episodeList)
            {
                Browser.Navigate(episode.GetURL(HDCB.Checked));
            }
            setControlState(true);

            var newList = episodeList.OrderBy(o => o.GetSeasonNumber()).ThenBy(o => o.GetEpisodeNumber()).ToList();
            episodeListBox.DataSource = newList;
        }

        private int getSeasonNumber(GeckoHtmlElement element)
        {
            string title = element.GetAttribute("href");
            var reg = Regex.Match(title, "([Ss]([0-9][0-9])[Ee]([0-9][0-9]))");
            if(!reg.Success) reg = Regex.Match(title, @"(\d+)[x]([0-9][0-9])");
            return int.Parse(reg.Groups[2].Value);
        }

        private int getEpisodeNumber(GeckoHtmlElement element)
        {
            string title = element.GetAttribute("href");
            var reg = Regex.Match(title, "([Ss]([0-9][0-9])[Ee]([0-9][0-9]))");
            if (!reg.Success) reg = Regex.Match(title, @"(\d+)[x]([0-9][0-9])");
            return int.Parse(reg.Groups[3].Value);
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
            URLTB.Enabled = state;
            Browser.Enabled = state;
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

            if(!Browser.Url.AbsoluteUri.Contains("eztv")) 
            {
                MessageBox.Show("Please navigate to EZTV in order to download episodes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            setControlState(false);
            episodeListBox.DataSource = null;
            episodeListBox.Items.Clear();
            episodeList.Clear();
            download();
        }

        private void Browser_Navigating(object sender, Gecko.Events.GeckoNavigatingEventArgs e)
        {
            loadingCircle1.Visible = true;
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
            //var color = text.Contains("Found") ? Color.DarkGreen : Color.DarkRed; // WIP
            var color = Color.DarkGreen;
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

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            if(new SettingsForm().ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Reload();
            }
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            Browser.Reload();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Browser.Navigate(Properties.Settings.Default.InitialURL);
            }
            catch
            {
                MessageBox.Show("There was a problem navigating to your configured URL, please make sure it's correct.\nEnsure you include the HTTP/HTTPS protocol.", "Navigation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
