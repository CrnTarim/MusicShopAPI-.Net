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
using System.Text.Json;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingerController : ControllerBase
    {
        private readonly ISingerBusiness _business;

        private readonly IMapper _mapper;

        private readonly ICacheService _cacheService;

        public SingerController(ISingerBusiness business, IMapper mapper, ICacheService cacheService) 
        {
            _business = business;
            _mapper = mapper;
            _cacheService = cacheService;
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

        /*
        [HttpGet]
        public async Task<ActionResult<List<SingerDto>>> GetSingers()
        {
            var singers = _business.GetAllAsync().ToList();

            var singerDtos = _mapper.Map<List<SingerDto>>(singers);

            return Ok(singerDtos);
        }
        */

        [HttpGet]
        public async Task<ActionResult<List<SingerDto>>> GetSingers()
        {
           
            var cacheKey = "singersList";
            var cachedSingers = await _cacheService.GetAsync<List<SingerDto>>(cacheKey);

            if (cachedSingers != null)
            {
                return Ok(cachedSingers);
            }
          
            var singers = _business.GetAllAsync().ToList();   
            var singerDtos = _mapper.Map<List<SingerDto>>(singers);

            // Veriyi cache'e kaydet
            var expirationTime = TimeSpan.FromMinutes(60); 
            await _cacheService.SetAsync(cacheKey, singerDtos, expirationTime);

            return Ok(singerDtos);
        }




    }
}
