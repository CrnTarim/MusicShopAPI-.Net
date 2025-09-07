using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Business.Interface;
using MusicShop.Data.Dto.OutComing.Hospital;
using MusicShop.Data.Entities.Hospital;
using Microsoft.EntityFrameworkCore;
using MusicShop.Data.Dto.InComing.CreationDto.Hospital;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IBusiness<Diagnosis> _business;
        private readonly IMapper _mapper;

        public DiagnosisController(IBusiness<Diagnosis> business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DiagnosisDto>>> GetDiagnoses()
        {
            var list = await _business.GetAllAsync().ToListAsync();
            var dtos = _mapper.Map<List<Diagnosis>>(list);
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiagnosis(CreationDtoForDiagnosis diagnosisDto)
        {
            var diagnosisEntity = _mapper.Map<Diagnosis>(diagnosisDto);
            await _business.AddAsync(diagnosisEntity);
            return Ok(diagnosisEntity);
        }
    }
}
