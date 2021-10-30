using System;
using System.Collections.Generic;
using System.Text;

namespace Audio.Models
{
    public class RecentPlayed
    {
        public RecentPlayed()
        {
            Songs = new HashSet<Song>();
        }
        public ICollection<Song> Songs { get; set; }
    }
}
