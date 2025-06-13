using MusicShop.Data.Entities.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.CreationDto.User
{
    public class CreationDtoForUserFavouriteSongs: BaseDto
    {
        public Guid UserId { get; set; }
  
        public Guid SingleSongId { get; set; }
       

    }
}
