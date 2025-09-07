using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Business.Interface;
using MusicShop.Data.Entities.Hospital;
using Microsoft.EntityFrameworkCore;
using MusicShop.Data.Dto.OutComing.Hospital;
using MusicShop.Data.Dto.InComing.CreationDto.Hospital;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IBusiness<Report> _business;
        private readonly IMapper _mapper;

        public ReportController(IBusiness<Report> business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Report>>> GetReports()
        {
            var list = await _business.GetAllAsync().ToListAsync();
            var dtos = _mapper.Map<List<ReportDto>>(list);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport(CreationDtoForReport reportDto)
        {
            var reportEntity = _mapper.Map<Report>(reportDto);
            await _business.AddAsync(reportEntity);
            return Ok(reportEntity);
        }
    }
}
