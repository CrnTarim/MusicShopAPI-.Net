using MusicShop.Data.Dto.OutComing.Singer;
using MusicShop.Data.Dto.OutComing.Song;
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

        Task<List<SingerDto>> GetSingerListAsync();
    }
}
