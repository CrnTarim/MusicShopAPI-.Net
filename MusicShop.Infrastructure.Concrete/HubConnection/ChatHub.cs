using Microsoft.AspNetCore.SignalR;
using MusicShop.Data.Entities.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Concrete.HubConnection

{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string senderId, string receiverId, string content)
        {
            var message = new
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Content = content,
                Timestamp = DateTime.UtcNow
            };

            // Mesajı alıcıya gönder
            await Clients.User(receiverId).SendAsync("ReceiveMessage", message);
        }
    }
}
