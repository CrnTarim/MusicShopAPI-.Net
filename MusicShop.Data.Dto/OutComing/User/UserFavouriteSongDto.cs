using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.OutComing.User
{
    public class UserFavouriteSongDto:BaseDto
    {
        public Guid UserId { get; set; }

        public Guid SingleSongId { get; set; }
    }
}
