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


        [HttpGet]
        public async Task<ActionResult<List<SingleSongDto>>> GetSingles()
        {
            var singles = _business.GetAllAsync();

            var singlesDto = _mapper.Map<List<SingleSongDto>>(singles);

            return Ok(singlesDto);
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