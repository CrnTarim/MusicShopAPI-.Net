using MusicShop.Data.Entities.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Business.Interface
{
    public interface ISingleSongBusiness :IBusiness<SingleSong>
    {
        Task<List<SingleSong>> GetSingerSongs(Guid Id);
    }
}
