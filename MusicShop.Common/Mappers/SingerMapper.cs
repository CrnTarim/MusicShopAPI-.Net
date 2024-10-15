using MusicShop.Data.Dto.InComing.CreationDto.Singer;
using MusicShop.Data.Dto.InComing.UpdateDto.Singer;
using MusicShop.Data.Dto.OutComing.Singer;
using MusicShop.Data.Entities.SingerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Common.Mappers
{
    public class SingerMapper:BaseMapper<Singer,SingerDto,UpdateDtoForSinger,CreationDtoForSinger>
    {
    }
}
