using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.CreationDto.User
{
    public class CreationDtoForPerson:BaseDto
    {
        public string IdentityNo { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Role { get; set; }
    }
}
