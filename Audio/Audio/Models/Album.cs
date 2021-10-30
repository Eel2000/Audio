using System;
using System.Collections.Generic;
using System.Text;

namespace Audio.Models
{
    public class Album
    {
        [LiteDB.BsonId]
        public string ID { get; set; }
        public string Label { get; set; }
        public string Singer { get; set; }
        public string PublicationDate { get; set; }
    }
}
