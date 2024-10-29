using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Business.Concrete;
using MusicShop.Business.Interface;
using MusicShop.Data.Entities.UserInfo;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
       MessageBusiness _messageBusiness;
       
        public MessageController(MessageBusiness messageBusiness)
        {
            _messageBusiness = messageBusiness;
        }



        [HttpPost("{senderId}/{receiverId}/{content}")]
        public async Task<ActionResult> SendMessage([FromRoute] string senderId, [FromRoute] string receiverId, [FromRoute] string content)
        {
            await _messageBusiness.SendMessage(senderId, receiverId, content);
            return Ok("Message Sent");
        }


        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Message>>> ReceiveMessage([FromRoute] string userId)
        {
            List<Message> messages = await _messageBusiness.ReceiveMessages(userId);
            return Ok(messages);
        }

    }
}
