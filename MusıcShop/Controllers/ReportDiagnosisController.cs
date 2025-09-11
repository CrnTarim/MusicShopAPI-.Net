using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Business.Interface;
using MusicShop.Data.Entities.Hospital;
using Microsoft.EntityFrameworkCore;
using MusicShop.Data.Dto.OutComing.Hospital;
using MusicShop.Data.Dto.InComing.CreationDto.Hospital;
using MusicShop.Data.Dto.OutComing.Singer;
using MusicShop.Data.Dto.OutComing.Song;
using SharpCompress.Common;
using StackExchange.Redis;
using System.Drawing;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportDiagnosisController : ControllerBase
    {
        private readonly IBusiness<ReportDiagnosis> _business;
        private readonly IMapper _mapper;

        public ReportDiagnosisController(IBusiness<ReportDiagnosis> business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReportDiagnosisDto>>> GetAll()
        {
            var list = await _business.GetAllAsync().ToListAsync();
            var dto = _mapper.Map<List<ReportDiagnosisDto>>(list);
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<ReportDiagnosis>> Create(CreationDtoForReportDiagnosis dto)
        {
            var entity = _mapper.Map<ReportDiagnosis>(dto);
            await _business.AddAsync(entity);
            return Ok(entity);
        }

        //Entity materialize etmeden, LINQ projection ile DTO’yu flatten edip denormalize
        //bir read model çıkarıyoruz; Include yerine server-side projection var
        [HttpGet("eager")]
        public async Task<ActionResult<List<ReportDiagnosisEager>>> GetAllInformation()
        {
            
            var query = _business.GetAllAsync(); 
            var data = await query
              
                .Select(rd => new ReportDiagnosisEager
                {
                    Id = rd.Id,

                    ReportId = rd.Report.Id,
                    ReportCode = rd.Report.Code,

                    ProvisionId = rd.Report.Provision.Id,
                    ProvisionCode = rd.Report.Provision.Code,

                    HospitalId = rd.Report.Provision.Hospital.Id,
                    HospitalCode = rd.Report.Provision.Hospital.Code,
                    HospitalName = rd.Report.Provision.Hospital.Name,

                    CityId = rd.Report.Provision.Hospital.City.Id,
                    CityCode = rd.Report.Provision.Hospital.City.CityCode,
                    CityName = rd.Report.Provision.Hospital.City.CityName,

                    DiagnosisId = rd.Diagnosis.Id,
                    DiagnosisCode = rd.Diagnosis.Code,
                    DiagnosisName = rd.Diagnosis.Name,

                    ReportCreated = rd.Report.CreatedDate
                })
                .OrderByDescending(x => x.ReportCode) 
                .ToListAsync();

            return Ok(data);
        }


        [HttpGet("eager/{id:guid}")]
        public async Task<ActionResult<ReportDiagnosisEager>> GetEagerById(Guid id)
        {
            var data =  _business.GetAllAsync();
            var dto = await data.Where(rd => rd.Id == id).Select(rd => new ReportDiagnosisEager
            {
                Id = rd.Id,

                ReportId = rd.Report.Id,
                ReportCode = rd.Report.Code,

                ProvisionId = rd.Report.Provision.Id,
                ProvisionCode = rd.Report.Provision.Code,

                HospitalId = rd.Report.Provision.Hospital.Id,
                HospitalCode = rd.Report.Provision.Hospital.Code,
                HospitalName = rd.Report.Provision.Hospital.Name,

                CityId = rd.Report.Provision.Hospital.City.Id,
                CityCode = rd.Report.Provision.Hospital.City.CityCode,
                CityName = rd.Report.Provision.Hospital.City.CityName,

                DiagnosisId = rd.Diagnosis.Id,
                DiagnosisCode = rd.Diagnosis.Code,
                DiagnosisName = rd.Diagnosis.Name,

                ReportCreated = rd.Report.CreatedDate
            }).FirstOrDefaultAsync();

            return Ok(dto);
        }

      

    }
}
