using MusicShop.Business.Interface;
using MusicShop.Data.Entities.SingerInfo;
using MusicShop.Data.Entities.Song;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Business.Concrete
{
    public class SingerBusiness : Business <Singer>,ISingerBusiness
    {
        protected readonly ISingerRepository _singerRepository;

        public SingerBusiness(ISingerRepository singerRepository, IUnitOfWork unitOfWork,IGenericRepository<Singer> genericRepository):base(unitOfWork,genericRepository)
        { }
    }
}
