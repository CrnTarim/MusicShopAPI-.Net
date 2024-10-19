using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Business.Interface;
using MusicShop.Data.Dto.InComing.CreationDto.User;
using MusicShop.Data.Dto.OutComing.Song;
using MusicShop.Data.Dto.OutComing.User;
using MusicShop.Data.Entities.UserInfo;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavouriteSongController : ControllerBase
    {
        IUserFavouriteSongBusiness _business;

        IMapper _mapper;

        public UserFavouriteSongController(IUserFavouriteSongBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        [HttpPost] 
        public async Task<ActionResult<UserFavouriteSong>> CreateFavSong(CreationDtoForUserFavouriteSongs userFavouriteSongDto)
        {
            UserFavouriteSong favsong = _mapper.Map<UserFavouriteSong>(userFavouriteSongDto);
            await _business.AddAsync(favsong);
            return Ok(favsong);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserFavouriteSong>>> GetAllFavourite()
        {
            List<UserFavouriteSong> userFavouriteSongs = _business.GetAllAsync().ToList();
            return Ok(userFavouriteSongs);
        }
        
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var song = _business.FirstOrDefault(x => x.Id == id);
            if (song == null)
            {
                return BadRequest();
            }

            await _business.RemoveAsync(id);
            return NoContent();
        }

        [HttpGet("FavouriteSongs/{id}")]
        public async Task<ActionResult<List<SingleSongDto>>> GetUsersFavouriteSong(Guid id)
        {
            List< SingleSongDto> songs = await _business.GetUsersFavouriteSongs(id);
            return Ok(songs);
        }

    }
}
