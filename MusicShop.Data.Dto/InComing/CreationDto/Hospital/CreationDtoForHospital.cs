using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.CreationDto.Hospital
{
    public class CreationDtoForHospital
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public Guid CityId { get; set; }
    }
}
