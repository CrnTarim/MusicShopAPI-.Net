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

        public async Task<List<Message>> GetMessagesByUserIdsAsync(string senderId, string receiverId)
        {
            return await _messages.Find(m =>
                (m.SenderId == senderId && m.ReceiverId == receiverId) ||
                (m.SenderId == receiverId && m.ReceiverId == senderId))
                .ToListAsync();
        }

        public async Task AddMessageAsync(Message message)
        {
            await _messages.InsertOneAsync(message);
        }

        public async Task UpdateMessageAsync(Message message)
        {
            var filter = Builders<Message>.Filter.Eq(m => m.Id, message.Id);
            await _messages.ReplaceOneAsync(filter, message);
        }

        public async Task<Message> GetMessageByIdAsync(string messageId)
        {
            var objectId = new ObjectId(messageId); // String'den ObjectId'ye dönüştür
            return await _messages.Find(m => m.Id == objectId).FirstOrDefaultAsync();
        }
    }
}
