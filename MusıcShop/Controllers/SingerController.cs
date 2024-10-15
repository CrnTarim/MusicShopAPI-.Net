using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShop.Business.Interface;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Dto.InComing.CreationDto.Singer;
using MusicShop.Data.Dto.InComing.UpdateDto.Singer;
using MusicShop.Data.Dto.OutComing.Singer;
using MusicShop.Data.Entities.SingerInfo;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingerController : ControllerBase
    {
        private readonly ISingerBusiness _business;

        private readonly IMapper _mapper;

        public SingerController(ISingerBusiness business, IMapper mapper) 
        {
            _business = business;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreationDtoForSinger singerDto) 
        {
            var singer = _mapper.Map<Singer>(singerDto);
            await _business.AddAsync(singer);

            return Ok(singer);
        }

        [HttpPut("updatesinger/{singerId}")]
        public async Task<ActionResult<Singer>> UpdateSinger(Guid singerId, UpdateDtoForSinger updateDto)
        {
            try
            {
                var existingSinger = await _business.GetbyIdAsync(singerId);

                if (existingSinger == null)
                {
                    return NotFound(); 
                }
                existingSinger.Name = updateDto.Name;
                _business.UpdateAsync(existingSinger);

                return Ok(existingSinger);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getbyId/{singerId}")]
        public async Task<ActionResult<SingerDto>> GetSingerbyId(Guid singerId)
        {
            var existingSinger = await _business.GetbyIdAsync(singerId);

            var singerDto = _mapper.Map<SingerDto>(existingSinger);

            if (existingSinger == null)
            {
                return NotFound();
            }

            return Ok(singerDto);

        }

        [HttpGet]
        public async Task<ActionResult<List<SingerDto>>> GetSingers()
        {
            var singers = _business.GetAllAsync().ToList();

            var singerDtos = _mapper.Map<List<SingerDto>>(singers);

            return Ok(singerDtos);
        }
    }
}
