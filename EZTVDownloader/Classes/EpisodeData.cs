using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZTVDownloader.Classes
{
    public class EpisodeData: IEquatable<EpisodeData>
    {
        private int _season { get; set; }
        private int _episode { get; set; }
        private string _url { get; set; }
        private string _hdurl { get; set; }

        public EpisodeData(int season, int episode, string url, bool HD = false)
        {
            _season = season;
            _episode = episode;
            if(HD)
            {
                _hdurl = url;
            }
            else
            {
                _url = url;
            }
        }

        public void SetURL(string url, bool HDURL = false)
        {
            if(HDURL)
            {
                _hdurl = url;
            }
            else
            {
                _url = url;
            }
        }

        public bool HasHD()
        {
            return _hdurl != null;
        }

        public string GetURL(bool preferHD = false)
        {
            if(preferHD)
            {
                if(_hdurl != null)
                {
                    return _hdurl;
                }
            }
            return _url == null ? _hdurl : _url;
        }

        public int GetSeasonNumber()
        {
            return _season;
        }

        public int GetEpisodeNumber()
        {
            return _episode;
        }

        public override int GetHashCode()
        {
            int hashCode = 1758677558;
            hashCode = hashCode * -1521134295 + _season.GetHashCode();
            hashCode = hashCode * -1521134295 + _episode.GetHashCode();
            return hashCode;
        }

        public bool Equals(EpisodeData other)
        {
            return _season == other._season &&
                   _episode == other._episode;
        }

        public override string ToString()
        {
            return "S" + _season + "E" + _episode;
        }
    }
}
