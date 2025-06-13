﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MusicShop.Business.Concrete;
using MusicShop.Business.Interface;
using MusicShop.Data.Dto.InComing.CreationDto.Message;
using MusicShop.Data.Entities.UserInfo;
using MusicShop.Infrastructure.Concrete;
using MusicShop.Infrastructure.Concrete.HubConnection;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
         private readonly IHubContext<ChatHub> _hubContext;
         MessageRepository _messageRepository;

        public MessageController(MessageRepository messageBusiness, IHubContext<ChatHub> hubContext)
        {
            _messageRepository = messageBusiness;
            _hubContext = hubContext;
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

            await _messageRepository.SaveMessage(message);

            return Ok(new { message = "Message Sent" });

        }


        [HttpGet("{userId}")]
        public async Task<ActionResult<List<String>>> ReceiveMessage([FromRoute] string userId)
        {
            List<Message> messages = await _messageRepository.ReceiveMessages(userId);
            List<string> contents = messages.Select(m => m.Content).ToList();
            return Ok(contents);
        }

    }

}

