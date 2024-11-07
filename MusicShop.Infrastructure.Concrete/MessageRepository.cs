using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MusicShop.Data.Entities.Logging;
using MusicShop.Data.Entities.MongoDB;
using MusicShop.Data.Entities.UserInfo;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Concrete
{
    public class MessageRepository
    {
        private readonly IMongoCollection<Message> _messages;

        public MessageRepository(IOptions<MongoDbSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _messages = database.GetCollection<Message>("Messages");
        }

        public async Task SaveMessage(Message message)
        {
            await _messages.InsertOneAsync(message);
        }

        public async Task<List<Message>> ReceiveMessages(string userId)
        {
            var messages = await _messages.Find(m => m.SenderId == userId || m.ReceiverId == userId).ToListAsync();
            return messages;
        }

    }
}
