using Microsoft.AspNetCore.Http;
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
        private readonly MessageRepository _messageRepository;
        private readonly IHubContext<ChatHub> _hubContext;

        public MessageController(MessageRepository messageRepository, IHubContext<ChatHub> hubContext)
        {
            _messageRepository = messageRepository;
            _hubContext = hubContext;
        }

        // Mesaj gönderme
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] CreationDtoForMessage messageDto)
        {
            if (messageDto == null || string.IsNullOrEmpty(messageDto.SenderId) || string.IsNullOrEmpty(messageDto.ReceiverId) || string.IsNullOrEmpty(messageDto.Content))
            {
                return BadRequest("SenderId, ReceiverId, and Content are required.");
            }

            var message = new Message
            {
                SenderId = messageDto.SenderId,
                ReceiverId = messageDto.ReceiverId,
                Content = messageDto.Content,
                Timestamp = DateTime.UtcNow,
                IsRead = false
            };

            await _messageRepository.AddMessageAsync(message);

            // Mesajı anlık olarak gönder
            await _hubContext.Clients.User(messageDto.ReceiverId).SendAsync("ReceiveMessage", message);

            return Ok(new { Message = "Message sent successfully.", MessageId = message.Id });
        }

        // Kullanıcılar arasındaki mesajları alma
        [HttpGet("{senderId}/{receiverId}")]
        public async Task<ActionResult<List<Message>>> GetMessages(string senderId, string receiverId)
        {
            var messages = await _messageRepository.GetMessagesByUserIdsAsync(senderId, receiverId);
            return Ok(messages);
        }

        // Mesajı okundu olarak işaretleme
        [HttpPost("read/{messageId}")]
        public async Task<IActionResult> MarkAsRead(string messageId)
        {
            var message = await _messageRepository.GetMessageByIdAsync(messageId);
            if (message == null)
            {
                return NotFound("Message not found");
            }

            message.IsRead = true;
            await _messageRepository.UpdateMessageAsync(message);
            return NoContent();
        }
    }

}

