using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Business.Concrete;
using MusicShop.Business.Interface;
using MusicShop.Data.Dto.InComing.CreationDto.Singer;
using MusicShop.Data.Dto.InComing.CreationDto.User;
using MusicShop.Data.Dto.OutComing.Song;
using MusicShop.Data.Dto.OutComing.User;
using MusicShop.Data.Entities.SingerInfo;
using MusicShop.Data.Entities.UserInfo;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonBusiness _business;

        private readonly IMapper _mapper;

        private readonly ICacheService _cacheService;

        public PersonController(PersonBusiness business, IMapper mapper, ICacheService cacheService)
        {
            _business = business;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreationDtoForPerson personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            await _business.AddAsync(person);

            return Ok(person);
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDto>>> GetSingleBeats()
        {
            var persons = _business.GetAllAsync();
            var personsdto = _mapper.Map<List<PersonDto>>(persons);
            return Ok(personsdto);
        }

        [HttpPut] // api/Person
        public async Task<IActionResult> Update([FromBody] CreationDtoForPerson dto)
        {
            var entity = await _business.GetByIdentityNoAsync(dto.IdentityNo);
            if (entity == null) return NotFound();

            entity.Email = dto.Email;
            entity.Phone = dto.Phone;
            entity.Role = dto.Role;

            await _business.UpdateAsync(entity);
            return Ok(entity); // veya return NoContent();
        }


    }
}
