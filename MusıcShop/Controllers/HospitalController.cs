using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Business.Interface;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Dto.InComing.CreationDto.Hospital;
using MusicShop.Data.Dto.OutComing.Hospital;
using MusicShop.Data.Entities.Hospital;
using Microsoft.EntityFrameworkCore;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly HBSContext _context;

        private readonly IMapper _mapper;

        private readonly IBusiness<Hospital> _business;

        public HospitalController(HBSContext context, IMapper mapper, IBusiness<Hospital> business)
        {
            _context = context;
            _mapper = mapper;
            _business = business;
        }

        [HttpPost]
        public async Task<ActionResult<Hospital>> CreateHospital(CreationDtoForHospital hospitalDto)
        {
            var hospital = _mapper.Map<Hospital>(hospitalDto);
            await _context.AddAsync(hospital);
            await _context.SaveChangesAsync();
            return Ok(hospital);
        }

        [HttpGet]

        public async Task<ActionResult<List<HospitalDto>>> GetHospital()
        {
            var list = await _business.GetAllAsync().ToListAsync();
            var dtos = _mapper.Map<List<HospitalDto>>(list);
            return Ok(dtos);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<HospitalDto>> GetHospitalById(Guid id)
        {
            var report = await _business.GetbyIdAsync(id);
            var reportdto = _mapper.Map<HospitalDto>(report);
            return Ok(reportdto);
        }
    }
}
