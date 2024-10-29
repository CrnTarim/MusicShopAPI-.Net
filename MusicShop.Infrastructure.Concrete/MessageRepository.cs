using Microsoft.Extensions.Options;
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
    public class MessageRepository : IMessageRepository
    {
        private readonly IMongoCollection<Message> _messages;

        public MessageRepository(IOptions<MongoDbSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _messages = database.GetCollection<Message>("Messages");
        }

        public async Task<List<Message>> ReceiveMessages(string userId)
        {
            var messages = await _messages.Find(m => m.SenderId == userId || m.ReceiverId == userId).ToListAsync();
            return messages;
        }

        public async Task SendMessage(string senderId, string receiverId, string content)
        {
            var messageInfo = new Message
            {
                SenderId = senderId, // Artık string olarak gönderiyoruz
                ReceiverId = receiverId, // Artık string olarak gönderiyoruz
                Content = content,
                Timestamp = DateTime.UtcNow,
                IsRead = false
            };

            await _messages.InsertOneAsync(messageInfo);
        }

    }
}
