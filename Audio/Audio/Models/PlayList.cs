using System;
using System.Collections.Generic;
using System.Text;

namespace Audio.Models
{
    public class PlayList
    {
        public PlayList()
        {
            Songs = new HashSet<Song>();
        }

        [LiteDB.BsonId]
        public string ID { get; set; }
        public ICollection<Song> Songs { get; set; }
        public string CreationDate { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
