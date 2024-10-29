using MusicShop.Data.Entities.UserInfo;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Business.Concrete
{
    public class MessageBusiness
    {
        IMessageRepository _messageRepository;

        public MessageBusiness(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<List<Message>> ReceiveMessages(string userId)
        {
            return await _messageRepository.ReceiveMessages(userId);
        }

        public async Task SendMessage(string senderId, string receiverId, string content)
        {       
            await _messageRepository.SendMessage(senderId,receiverId,content);
        }
    }
}
