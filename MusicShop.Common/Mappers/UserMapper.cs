using MusicShop.Data.Dto.InComing.CreationDto.User;
using MusicShop.Data.Dto.InComing.UpdateDto.User;
using MusicShop.Data.Dto.OutComing.User;
using MusicShop.Data.Entities.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Common.Mappers
{
    public class UserMapper : BaseMapper<User, UserDto, UpdateDtoForUser, CreationDtoForUser>
    {
    }
}
