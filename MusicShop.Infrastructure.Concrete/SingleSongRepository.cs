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
    public class SingleSongRepository : GenericRepository<SingleSong>, ISingleSongRepository
    {
        protected readonly MusicShopContext _context; 
        private readonly DbSet<SingleSong> _dbSet;

        public SingleSongRepository(MusicShopContext context):base(context)
        {
            _context = context;
            _dbSet = _context.Set<SingleSong>();
        }

        public async Task<List<SingleSong>> GetSingerSongs(Guid Id)
        {
            var songs = await _context.SingleSongs.Where(x => x.SingerId == Id).ToListAsync();
            return songs;
        }
    }
}
