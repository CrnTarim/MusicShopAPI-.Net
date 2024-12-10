using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MusicShop.Business.Concrete;
using MusicShop.Business.Interface;
using MusicShop.Data.Dto.InComing.CreationDto.Message;
using MusicShop.Data.Dto.OutComing.Singer;
using MusicShop.Data.Entities.UserInfo;
using MusicShop.Infrastructure.Concrete;
using MusicShop.Infrastructure.Concrete.HubConnection;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        MessageBusiness _messageBusiness;
        ChatsBusiness _chatsBusiness;
        ICacheService _cacheService;

        public MessageController(MessageBusiness messageBusiness, ICacheService cacheService, ChatsBusiness chatsBusiness)
        {
            _messageBusiness = messageBusiness;
            _cacheService = cacheService;
            _chatsBusiness = chatsBusiness;
        }


        [HttpPost("sendmessage")]
        public async Task<ActionResult<object>> SendMessage([FromBody] CreationDtoForMessage creationDto)
        {
            var message = new Message
            {
                SenderId = creationDto.SenderId,
                ReceiverId = creationDto.ReceiverId,
                Content = creationDto.Content,
                Timestamp = DateTime.UtcNow,
                
            };

            var chat = new Chats
            {
                FirstUserId = creationDto.SenderId,
                SecondUserId = creationDto.ReceiverId,
                Messages = new List<Message> { message }
            };

            await _messageBusiness.SaveMessage(message);

            await _chatsBusiness.SaveChat(chat);

            return Ok(new { message = "Message Sent" });

        }


        [HttpGet]
        public async Task<ActionResult<List<String>>> ReceiveMessage(string userId, string receiverId)
        {
           /*
            var cacheKey = "messages";
            var cachedMessages = await _cacheService.GetAsync<List<string>>(cacheKey);

            if (cachedMessages != null)
            {
                return Ok(cachedMessages);
            }
           */
            List<Message> messages = await _messageBusiness.ReceiveMessages(userId,receiverId);
            List<string> contents = messages.Select(m => m.Content).ToList();

            //var expirationTime = TimeSpan.FromMinutes(30);
            //await _cacheService.SetAsync(cacheKey, contents, expirationTime);
            return Ok(contents);
        }

    }

}

