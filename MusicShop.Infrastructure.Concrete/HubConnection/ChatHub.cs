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
   
        private static ConcurrentDictionary<string, string> userConnectionMap = new ConcurrentDictionary<string, string>();

        public async Task RegisterUser(string userId)
        {
      
            userConnectionMap[userId] = Context.ConnectionId;
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
       
            var userId = userConnectionMap.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
            if (userId != null)
            {
                userConnectionMap.TryRemove(userId, out _);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageToUser(string targetUserId, string message)
        {
            if (userConnectionMap.TryGetValue(targetUserId, out var targetConnectionId))
            {
                await Clients.Client(targetConnectionId).SendAsync("ReceiveMessage", message);
            }
        }
   }

}

// await Clients.All.SendAsync("ReceiveMessage", user, message);
//await Clients.Others.SendAsync("ReceiveMessage", user, message);
