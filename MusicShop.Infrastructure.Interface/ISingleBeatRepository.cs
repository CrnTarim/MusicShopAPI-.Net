using MusicShop.Data.Entities.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Interface
{
    public interface ISingleBeatRepository :IGenericRepository<SingleBeat>
    {
        public Task<List<SingleBeat>> GetSingleBeatByBeatId(Guid Id);

        public Task<List<SingleBeat>> GetSingleBeatbyBeatIdEager(Guid Id);


    }
}
