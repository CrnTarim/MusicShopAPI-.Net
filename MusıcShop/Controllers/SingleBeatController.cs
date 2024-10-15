using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShop.Business.Interface;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Dto.InComing.CreationDto.Song;
using MusicShop.Data.Dto.InComing.UpdateDto.Song;
using MusicShop.Data.Dto.OutComing.Song;
using MusicShop.Data.Entities.Song;
using System.Formats.Asn1;

namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingleBeatController : ControllerBase
    {
        
        private readonly ISingleBeatBusiness _business;
        private readonly IMapper _mapper;

        public SingleBeatController(ISingleBeatBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;          
        }

        [HttpPost("/craetesinglebeat")]
        public async Task<ActionResult<SingleBeat>> CreateSingleBeat(CreationDtoForSingleBeat singlebeatDto)
        {
            var singlebeat = _mapper.Map<SingleBeat>(singlebeatDto);
            await _business.AddAsync(singlebeat);
            return Ok(singlebeat);
        }

        [HttpGet("/getsinglebeats")]
        public async Task<ActionResult<List<SingleBeatDto>>> GetSingleBeats()
        {
            var singlebeats = _business.GetAllAsync();
            var singlebeatdto = _mapper.Map<List<SingleBeatDto>>(singlebeats);
            return Ok(singlebeatdto);
        }
        
        [HttpGet("/getbybeatid/{Id}")]
        public async Task<ActionResult<List<SingleBeat>>> GetSingleBeatbyBeatId(Guid Id)
        {
            var singlebeat = await _business.GetSingleBeatByBeatId(Id);
            return Ok(singlebeat);
        }

        [HttpGet("/getbybeatideager/{Id}")]
        public async Task<ActionResult<List<SingleBeat>>> GetSingleBeatbyBeatIdEager(Guid Id)
        {
            var singlebeat = await _business.GetSingleBeatbyBeatIdEager(Id);
            return Ok(singlebeat);
        }

        [HttpPut("/updatesinglebeat/{Id}")]
        public async Task<ActionResult<SingleBeatDto>> UpdateSingleBeat(Guid Id, SingleBeatDto singleBeat)
        {
            var singlebeat = await _business.GetbyIdAsync(Id);

            if(singlebeat != null)
            {
                singlebeat.Label = singleBeat.Label;
            }

            await _business.UpdateAsync(singlebeat);

            var singlebeatdto = _mapper.Map<SingleBeatDto>(singlebeat);

            return Ok(singlebeat);

        }

    }
}
