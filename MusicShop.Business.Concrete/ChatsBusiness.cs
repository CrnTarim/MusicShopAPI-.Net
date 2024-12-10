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
    public class ChatsBusiness
    {
        private readonly IMongoCollection<Chats> _chats;

        public ChatsBusiness(IOptions<MongoDbSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _chats = database.GetCollection<Chats>("Chats");
        }

        public async Task SaveChat(Chats chats)
        {
            await _chats.InsertOneAsync(chats);
        }

        public async Task<List<Chats>> ReceiveMessages(string userId, string receiverId)
        {
            var chats = await _chats.Find(m => m.FirstUserId == userId && m.SecondUserId == receiverId).ToListAsync();

            return chats;
        }
    }
}
