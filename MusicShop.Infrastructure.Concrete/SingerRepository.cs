using Microsoft.EntityFrameworkCore;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Entities.SingerInfo;
using MusicShop.Data.Entities.Song;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Concrete
{
    public class SingerRepository : GenericRepository<Singer>,ISingerRepository
    {
        protected readonly MusicShopContext _context;
        private readonly DbSet<SingleSong> _dbSet;

        public SingerRepository(MusicShopContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<SingleSong>();
        }
    }
}
