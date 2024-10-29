using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.UserInfo
{
    public class Message
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string SenderId { get; set; } // Burayı string yaptık
        public string ReceiverId { get; set; } // Burayı string yaptık
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
    }
}
