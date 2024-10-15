using MusicShop.Business.Interface;
using MusicShop.Data.Entities.Song;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Business.Concrete
{
    public class SingleSongBusiness : Business<SingleSong>, ISingleSongBusiness
    {
        private readonly ISingleSongRepository _singleSongRepository;

        public SingleSongBusiness(IGenericRepository<SingleSong> repository, IUnitOfWork unitOfWork, ISingleSongRepository singleSongRepository): base(unitOfWork, repository) // İUnitOfWork ve IGenericRepository<SingleSong> parametrelerini doğru sırada geçin
        {
            _singleSongRepository = singleSongRepository;
        }

        public async Task<List<SingleSong>> GetSingerSongs(Guid Id)
        {
            return await _singleSongRepository.GetSingerSongs(Id);
        }
    }
}
