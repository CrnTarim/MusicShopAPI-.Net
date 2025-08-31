using MusicShop.Data.Dto.InComing.CreationDto.Singer;
using MusicShop.Data.Dto.InComing.CreationDto.User;
using MusicShop.Data.Dto.InComing.UpdateDto.Singer;
using MusicShop.Data.Dto.InComing.UpdateDto.User;
using MusicShop.Data.Dto.OutComing.Singer;
using MusicShop.Data.Dto.OutComing.User;
using MusicShop.Data.Entities.SingerInfo;
using MusicShop.Data.Entities.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Common.Mappers
{
    public class PersonMapper : BaseMapper<Person, PersonDto, UpdateDtoForPerson, CreationDtoForPerson>
    {
    }
}
