using Microsoft.AspNetCore.SignalR;
using MusicShop.Data.Entities.UserInfo;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Concrete.HubConnection

{
    public class ChatHub : Hub
    {
            
        public async Task SendMessageToUser(string targetConnectionId, string message)
        {
            await Clients.Client(targetConnectionId).SendAsync("ReceiveMessage", message);
        }
    }

}

// await Clients.All.SendAsync("ReceiveMessage", user, message);
//await Clients.Others.SendAsync("ReceiveMessage", user, message);
