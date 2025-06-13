using MusicShop.Data.Dto.OutComing.Song;
using MusicShop.Data.Entities.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Business.Interface
{
    public interface IUserFavouriteSongBusiness:IBusiness<UserFavouriteSong>
    {
        Task<List<SingleSongDto>> GetUsersFavouriteSongs(Guid id);
    }
}
