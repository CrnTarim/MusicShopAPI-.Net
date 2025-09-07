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
    public class ProvisionController : ControllerBase
    {
        private readonly IBusiness<Provision> _business;

        private readonly IMapper _mapper;

        public ProvisionController(IBusiness<Provision> business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProvision(CreationDtoForProvision provisionDto)
        {
            var provisionEntity = _mapper.Map<Provision>(provisionDto);
            await _business.AddAsync(provisionEntity);
            return Ok(provisionEntity);
        }

        [HttpGet]

        public async Task<ActionResult<List<Provision>>> GetProvisions()
        {
            var list = await _business.GetAllAsync().ToListAsync();
            var dtos = _mapper.Map<List<ProvisionDto>>(list);
            return Ok(dtos);
           
        }
    }
}
