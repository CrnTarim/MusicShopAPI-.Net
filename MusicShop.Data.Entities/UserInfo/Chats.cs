using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.UserInfo
{
    public class Chats
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
