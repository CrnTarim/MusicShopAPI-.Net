using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShop.Business.Concrete;
using MusicShop.Business.Interface;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Dto.InComing.CreationDto.Hospital;

using MusicShop.Data.Dto.OutComing.Hospital;

using MusicShop.Data.Entities.Hospital;


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
        public async Task<ActionResult<CityDto>> CreateCityt(CreationDtoForCity citydto)
        {
            var city = _mapper.Map<City>(citydto);
            await _context.AddAsync(city);
            await _context.SaveChangesAsync();
            return Ok(citydto);
        }

        [HttpGet]

        public async Task<ActionResult<List<CityDto>>> GetCity()
        {
            var list = await _business.GetAllAsync().ToListAsync();           
            var dtos = _mapper.Map<List<CityDto>>(list);
            return Ok(dtos);
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CityDto>> GetCitytById(Guid id)
        {
            var report = await _business.GetbyIdAsync(id);
            var reportdto = _mapper.Map<CityDto>(report);
            return Ok(reportdto);
        }
    }
}
