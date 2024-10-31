using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using MusicShop.Data.Entities.UserInfo;

public class ChatHub : Hub
{
    public async Task SendMessage(string senderId, string receiverId, string message)
    {
        await Clients.User(receiverId).SendAsync("ReceiveMessage", senderId, receiverId, message);
    }
}

