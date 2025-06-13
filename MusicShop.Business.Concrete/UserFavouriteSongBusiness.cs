using MusicShop.Business.Interface;
using MusicShop.Data.Dto.OutComing.Song;
using MusicShop.Data.Entities.UserInfo;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Business.Concrete
{
    public class UserFavouriteSongBusiness : Business<UserFavouriteSong>, IUserFavouriteSongBusiness
    {
        IUserFavouriteSongRepository _userfavouriterepository;
       
        public UserFavouriteSongBusiness(IUserFavouriteSongRepository userfavouriterepository, IUnitOfWork unitOfWork, IGenericRepository<UserFavouriteSong> repository) : base(unitOfWork, repository)
        {
            _userfavouriterepository = userfavouriterepository;
        }

        public Task<List<SingleSongDto>> GetUsersFavouriteSongs(Guid id)
        {
            return _userfavouriterepository.GetUsersFavouriteSongs(id);
        }
    }
}
