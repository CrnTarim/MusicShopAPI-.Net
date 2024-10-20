using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Business.Concrete;
using MusicShop.Data.Entities.Logging;

namespace MusicShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly LogService _logService;

        public LogController(LogService logService)
        {
            _logService = logService;
        }

        /*

        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] Log log)
        {
            log.Timestamp = DateTime.UtcNow; // Zaman damgası ekleyin.
            await _logService.LogAsync(log);
            return Ok();
        }

        */
    }
}