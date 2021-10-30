using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace Audio.Models
{
    public class Song
    {
        [BsonId]
        public string ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Album { get; set; }
        public string AlbumID { get; set; }
        public bool IsPlaying { get; set; }
        public DateTime LastPlayed { get; set; }
        public string Duration { get; set; }
    }
}
