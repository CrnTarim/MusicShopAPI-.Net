using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Interface
{
    public interface ILogRepository
    {
        public Task LogAsync(string message, string level);

        public Task LogErrorAsync(Exception ex);
    }
}
