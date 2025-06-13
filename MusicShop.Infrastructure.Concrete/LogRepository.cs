using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MusicShop.Data.Entities.Logging;
using MusicShop.Data.Entities.MongoDB;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Concrete
{
    public enum LogLevel
    {
        Information,
        Warning,
        Error,
        Critical
    }
    public class LogRepository : ILogRepository
    {
        private readonly IMongoCollection<Log> _logs;

        public LogRepository(IOptions<MongoDbSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
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
