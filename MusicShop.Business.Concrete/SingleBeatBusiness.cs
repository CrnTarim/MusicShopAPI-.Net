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
    public class SingleBeatBusiness : Business<SingleBeat>, ISingleBeatBusiness
    {
        private readonly ISingleBeatRepository _singleBeatRepository;

        public SingleBeatBusiness(ISingleBeatRepository singleBeatRepository,IUnitOfWork unitOfWork, IGenericRepository<SingleBeat> repository) : base(unitOfWork, repository)
        {
            _singleBeatRepository = singleBeatRepository;
        }

        public async Task<List<SingleBeat>> GetSingleBeatByBeatId(Guid Id)
        {
            return await _singleBeatRepository.GetSingleBeatByBeatId(Id);
        }

        public async Task<List<SingleBeat>> GetSingleBeatbyBeatIdEager(Guid Id)
        {
            return await _singleBeatRepository.GetSingleBeatbyBeatIdEager(Id);
        }
    }
}
