using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MusicShop.Data.Entities.MongoDB;
using MusicShop.Data.Entities.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Business.Concrete
{
    public class MessageBusiness
    {
        private readonly IMongoCollection<Message> _messages;

        public MessageBusiness(IOptions<MongoDbSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _messages = database.GetCollection<Message>("Messages");
        }

        public async Task SaveMessage(Message message)
        {
            await _messages.InsertOneAsync(message);
        }

        public async Task<List<Message>> ReceiveMessages(string userId, string receiverId)
        {
            var messages = await _messages.Find(m => m.SenderId == userId && m.ReceiverId == receiverId).ToListAsync();

            return messages;
        }
    }
}
