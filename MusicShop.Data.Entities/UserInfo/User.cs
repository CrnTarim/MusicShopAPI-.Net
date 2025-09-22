
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.UserInfo
{
    public class User:BaseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        

        public string PasswordHash { get; set; }
      
    }
}
