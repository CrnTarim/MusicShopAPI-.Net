using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Dto;
using MusicShop.Data.Dto.InComing.CreationDto.Song;
using MusicShop.Data.Dto.OutComing.Song;
using MusicShop.Data.Entities.Song;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeatController : ControllerBase
    {
        private readonly MusicShopContext _context;

        private readonly IMapper _mapper;

        public BeatController(MusicShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Beat>> CreateBeat(CreationDtoForBeat beatDto)
        {
            var beat =  _mapper.Map<Beat>(beatDto);
            await _context.AddAsync(beat);
            await _context.SaveChangesAsync();
            return Ok(beat);
        }

        [HttpGet]

        public async Task<ActionResult<List<BeatDto>>> GetBeats()
        {
            var beats = await _context.Beats.ToListAsync();
            var beatDto = _mapper.Map<List<BeatDto>>(beats);
            return Ok(beatDto);
        }
    }
}
