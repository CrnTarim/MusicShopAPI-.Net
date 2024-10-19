using MusicShop.Data.Entities.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.UserInfo
{
    public class UserFavouriteSong:BaseModel
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid SingleSongId { get; set; }
        public SingleSong SingleSong { get; set; }
    }
}
