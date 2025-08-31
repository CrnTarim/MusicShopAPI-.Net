using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShop.Business.Concrete;
using MusicShop.Business.Interface;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Dto.InComing.CreationDto.Song;
using MusicShop.Data.Dto.InComing.UpdateDto.Singer;
using MusicShop.Data.Dto.InComing.UpdateDto.Song;
using MusicShop.Data.Dto.OutComing.Singer;
using MusicShop.Data.Dto.OutComing.Song;
using MusicShop.Data.Entities.SingerInfo;
using MusicShop.Data.Entities.Song;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingleSongController : ControllerBase
    {
        //main branch changes test
        private readonly ISingleSongBusiness _business;

        private readonly IMapper _mapper;

        public SingleSongController(ISingleSongBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<SingleSong>> CreateSingleSong(CreationDtoForSingleSong singlesongDto)
        {
            var singlesong = _mapper.Map<SingleSong>(singlesongDto);
            await _business.AddAsync(singlesong);
            return Ok(singlesong);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSingleSong(Guid id)
        {
            // V1: İş katmanında "GetByIdAsync" ve "DeleteAsync(entity)" varsa:
            var existing = await _business.GetbyIdAsync(id);
            if (existing is null)
                return NotFound($"SingleSong not found. id={id}");

            await _business.RemoveAsync(existing.Id);
            return NoContent(); // 204
        }


        [HttpGet]
        public async Task<ActionResult<List<SingleSongDto>>> GetSingles()
        {
            var singles = _business.GetAllAsync();

            var singlesDto = _mapper.Map<List<SingleSongDto>>(singles);

            return Ok(singlesDto);
        }


        [HttpGet("singers")]
        public async Task<ActionResult<List<SingerDto>>> GetSingers()
        {
            var singers = await _business.GetSingerListAsync();
            return Ok(singers);
        }

        [HttpGet("singer/{id}/singles")]
        public async Task<IActionResult> GetSingerSongs(Guid id)
        {
            var songs = await _business.GetSingerSongs(id);

            if (songs == null || !songs.Any())
            {
                return NotFound($"No songs found for the singer with ID {id}");
            }

            return Ok(songs);
        }



    }
}