using MongoDB.Driver;
using MusicShop.Data.Entities.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicShop.Business.Concrete
{

    public enum LogLevel
    {
        Information,
        Warning,
        Error,
        Critical
    }

    public class LogService
    {
        private readonly IMongoCollection<Log> _logs; //  using MusicShop.Data.Entities.Logging;

        public LogService(string connectionString)
        {
            var client = new MongoClient(connectionString); // appsetting.json 
            var database = client.GetDatabase("musicShoplogsDB"); 
            _logs = database.GetCollection<Log>("Logs"); 
        }

        public async Task LogAsync(string message, string level)
        {
            var log = new Log
            {
                Message = message,
                Level = level, // Artık string alıyor
                Timestamp = DateTime.UtcNow
            };

            await _logs.InsertOneAsync(log);
        }

        public async Task LogErrorAsync(Exception ex)
        {
            var log = new Log
            {
                Message = $"Error: {ex.Message}", 
                Level = LogLevel.Error.ToString(),
                Timestamp = DateTime.UtcNow
            };

            await _logs.InsertOneAsync(log);
        }
    }
}
