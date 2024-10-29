﻿using MusicShop.Data.Entities.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Interface
{
    public interface IMessageRepository
    {
        public Task SendMessage(string senderId, string receiverId, string content);
        public Task<List<Message>> ReceiveMessages(string UserId);
    }
}