using Microsoft.EntityFrameworkCore;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Entities.Song;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Concrete
{
    public class SingleBeatRepository : GenericRepository<SingleBeat>, ISingleBeatRepository
    {
        protected readonly MusicShopContext _context;
        private readonly DbSet<SingleBeat> _dbSet;

        public SingleBeatRepository(MusicShopContext context):base(context) 
        {
            _context = context;
            _dbSet = _context.Set<SingleBeat>();
        }
        public async Task<List<SingleBeat>> GetSingleBeatByBeatId(Guid Id)
        {
            var singlebeat =  await  _dbSet.Where(x=> x.BeatId == Id).ToListAsync();
            return singlebeat;
        }

        public async Task<List<SingleBeat>> GetSingleBeatbyBeatIdEager(Guid Id)
        {        
            var singlebeats = await _dbSet.Include(sb => sb.SingleSong).Include(sb => sb.Beat).Where(sb => sb.BeatId == Id).ToListAsync();
            return singlebeats;

        }
    }
}
