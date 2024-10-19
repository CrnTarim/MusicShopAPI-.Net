using MusicShop.Data.Dto.OutComing.Song;
using MusicShop.Data.Entities.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Interface
{
    public interface IUserFavouriteSongRepository:IGenericRepository<UserFavouriteSong>
    {
        Task<List<SingleSongDto>> GetUsersFavouriteSongs(Guid id);
    }
}
