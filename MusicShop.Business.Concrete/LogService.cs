using MongoDB.Driver;
using MusicShop.Data.Entities.Logging;
using MusicShop.Infrastructure.Interface;
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
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task LogAsync(string message, string level)
        {
           
            await _logRepository.LogAsync(message,level);
        }

        public async Task LogErrorAsync(Exception ex)
        {         

            await _logRepository.LogErrorAsync(ex);
        }
    }
}
