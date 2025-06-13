using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MusicShop.Data.Entities.Logging
{
    public class Log
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Message { get; set; }

        public string Level { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
