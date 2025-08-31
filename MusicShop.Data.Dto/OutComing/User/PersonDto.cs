using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.OutComing.User
{
    public class PersonDto:BaseDto
    {
        public string IdentityNo { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Role { get; set; }
    }
}
