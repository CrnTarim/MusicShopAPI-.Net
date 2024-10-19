using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.CreationDto.User
{
    public class CreationDtoForUser:BaseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        [Required, MinLength(4)]
        public string Password { get; set; }

        [Required, MinLength(4)]
        public string ConfirmPassword { get; set; }
    }
}
