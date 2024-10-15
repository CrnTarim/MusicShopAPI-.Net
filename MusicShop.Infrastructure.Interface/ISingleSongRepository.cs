using MusicShop.Data.Entities.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Interface
{
    public interface ISingleSongRepository :IGenericRepository<SingleSong>
    {
        Task<List<SingleSong>> GetSingerSongs(Guid Id);
    }
}
