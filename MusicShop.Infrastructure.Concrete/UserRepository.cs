using MusicShop.Data.Context.Context;
using MusicShop.Data.Entities.UserInfo;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MusicShopContext context) : base(context)
        {
        }
    }
}
