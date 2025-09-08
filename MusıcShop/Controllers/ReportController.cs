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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ReportDto>> GetReportById(Guid id)
        {
            var report = await _business.GetbyIdAsync(id);
            var reportdto = _mapper.Map<ReportDto>(report);
            return Ok(reportdto);
        }

        [HttpGet("eager")]
        public async Task<ActionResult<List<ReportEager>>> GetAllInformation()
        {
            var data = await _business.GetAllAsync()
                .Select(r => new ReportEager
                {
                    Id = r.Id,
                    ReportCode = r.Code,
                    ProvisionCode = r.Provision.Code,

                    HospitalId = r.Provision.Hospital.Id,
                    HospitalCode = r.Provision.Hospital.Code,
                    HospitalName = r.Provision.Hospital.Name,

                    CityId = r.Provision.Hospital.City.Id,
                    CityCode = r.Provision.Hospital.City.CityCode,
                    CityName = r.Provision.Hospital.City.CityName,

                    ReportCreated = r.CreatedDate
                })
                .OrderByDescending(x => x.ReportCode)
                .ToListAsync();

            return Ok(data);
        }
    }
}
