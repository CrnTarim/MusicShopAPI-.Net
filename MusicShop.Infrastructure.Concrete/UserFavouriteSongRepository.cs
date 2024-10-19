using Microsoft.EntityFrameworkCore;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Dto.OutComing.Song;
using MusicShop.Data.Entities.Song;
using MusicShop.Data.Entities.UserInfo;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Concrete
{
    public class UserFavouriteSongRepository : GenericRepository<UserFavouriteSong>, IUserFavouriteSongRepository
    {
        MusicShopContext _context;
        private readonly DbSet<UserFavouriteSong> _dbSet;

        public UserFavouriteSongRepository(MusicShopContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<UserFavouriteSong>();
        }

        public async Task<List<SingleSongDto>> GetUsersFavouriteSongs(Guid userId)
        {
            return await _dbSet
                .Where(x => x.UserId == userId)
                .Select(x => new SingleSongDto
                {
                    Id = x.SingleSongId,
                    Name = x.SingleSong.Name,
                    Category = x.SingleSong.Category,
                    Price = x.SingleSong.Price
                })
                .ToListAsync();
        }
    }
}
