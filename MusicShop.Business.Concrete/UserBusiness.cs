using MusicShop.Business.Interface;
using MusicShop.Data.Entities.UserInfo;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Business.Concrete
{
    public class UserBusiness:Business<User>,IUserBusiness
    {
        public UserBusiness(IUnitOfWork unitOfWork, IGenericRepository<User> repository):base(unitOfWork, repository) 
        {

        }
    }
}
