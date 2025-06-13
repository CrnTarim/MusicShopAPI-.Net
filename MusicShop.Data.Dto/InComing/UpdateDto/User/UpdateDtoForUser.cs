using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.UpdateDto.User
{
    public class UpdateDtoForUser:BaseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
