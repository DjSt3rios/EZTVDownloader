using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZTVDownloader.Classes
{
    public class EpisodeData : IEquatable<EpisodeData>
    {
        private int _season { get; set; }
        private int _episode { get; set; }
        private string _url { get; set; }
        private bool _HD { get; set; }

        public EpisodeData(int season, int episode, string url, bool HD = false)
        {
            _season = season;
            _episode = episode;
            _url = url;
            _HD = HD;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as EpisodeData);
        }

        public bool Equals(EpisodeData other)
        {
            return other != null &&
                   _season == other._season &&
                   _episode == other._episode &&
                   _url == other._url &&
                   _HD == other._HD;
        }

        public override int GetHashCode()
        {
            int hashCode = -554730225;
            hashCode = hashCode * -1521134295 + _season.GetHashCode();
            hashCode = hashCode * -1521134295 + _episode.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_url);
            hashCode = hashCode * -1521134295 + _HD.GetHashCode();
            return hashCode;
        }
    }
}
