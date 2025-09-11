using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Entities.Hospital;
using System;
using Microsoft.EntityFrameworkCore;
namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly HBSContext _ctx;
        public LookupsController(HBSContext ctx) => _ctx = ctx;

        [HttpGet("cities")]
        public async Task<IActionResult> GetCities()
        {
            var data = await _ctx.Set<City>()
                .AsNoTracking()
                .OrderBy(x => x.CityName)
                .Select(x => new { id = x.Id, name = x.CityName, code = x.CityCode })
                .ToListAsync();
            return Ok(data);
        }

        [HttpGet("hospitals")]
        public async Task<IActionResult> GetHospitals([FromQuery] List<Guid> cityIds)
        {
            var q = _ctx.Set<Hospital>().AsNoTracking();
            if (cityIds != null && cityIds.Count > 0)
                q = q.Where(h => cityIds.Contains(h.CityId));

            var data = await q.OrderBy(x => x.Name)
                .Select(x => new { id = x.Id, name = x.Name, cityId = x.CityId, code = x.Code })
                .ToListAsync();
            return Ok(data);
        }

        [HttpGet("reports")]
        public async Task<IActionResult> GetReports([FromQuery] List<Guid> hospitalIds)
        {
            var data = await (from r in _ctx.Set<Report>().AsNoTracking()
                              join p in _ctx.Set<Provision>().AsNoTracking()
                                   on r.ProvisionId equals p.Id
                              where hospitalIds == null || hospitalIds.Count == 0
                                    || hospitalIds.Contains(p.HospitalId)
                              select new { id = r.Id, code = r.Code, hospitalId = p.HospitalId })
                             .OrderBy(x => x.code)
                             .ToListAsync();
            return Ok(data);
        }
    }
}
