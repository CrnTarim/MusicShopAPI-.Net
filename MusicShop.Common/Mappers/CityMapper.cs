using MusicShop.Data.Dto.InComing.CreationDto.Hospital;
using MusicShop.Data.Dto.InComing.CreationDto.Singer;
using MusicShop.Data.Dto.InComing.UpdateDto.Hospital;
using MusicShop.Data.Dto.InComing.UpdateDto.Singer;
using MusicShop.Data.Dto.OutComing.Hospital;
using MusicShop.Data.Dto.OutComing.Singer;
using MusicShop.Data.Entities.Hospital;
using MusicShop.Data.Entities.SingerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Common.Mappers
{
    public class CityMapper : BaseMapper<City, CityDto, UpdateDtoForCity, CreationDtoForCity>
    {
    }
   
}
