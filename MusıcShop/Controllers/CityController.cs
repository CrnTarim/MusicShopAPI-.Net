using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShop.Business.Concrete;
using MusicShop.Business.Interface;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Dto.InComing.CreationDto.Hospital;
using MusicShop.Data.Dto.InComing.CreationDto.Song;
using MusicShop.Data.Dto.OutComing.Hospital;
using MusicShop.Data.Dto.OutComing.Song;
using MusicShop.Data.Entities.Hospital;
using MusicShop.Data.Entities.Song;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly HBSContext _context;

        private readonly IMapper _mapper;

        private readonly IBusiness<City> _business;

        public CityController(HBSContext context, IMapper mapper, IBusiness<City> business)
        {
            _context = context;
            _mapper = mapper;
            _business = business;
        }

        [HttpPost]
        public async Task<ActionResult<City>> CreateBeat(CreationDtoForCity beatDto)
        {
            var beat = _mapper.Map<Beat>(beatDto);
            await _context.AddAsync(beat);
            await _context.SaveChangesAsync();
            return Ok(beat);
        }

        [HttpGet]

        public async Task<ActionResult<List<CityDto>>> GetBeats()
        {
            var list = await _business.GetAllAsync().ToListAsync();           
            var dtos = _mapper.Map<List<CityDto>>(list);
            return Ok(dtos);
        }
    }
}
