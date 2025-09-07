using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.UpdateDto.Hospital
{
    public class UpdateDtoForCity : BaseDto
    {
        public int CityCode { get; set; }
        public string CityName { get; set; }
    }
}
