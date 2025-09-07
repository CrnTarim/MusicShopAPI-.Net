using MusicShop.Data.Entities.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.CreationDto.Hospital
{
    public class CreationDtoForReport: BaseDto
    {
        public int Code { get; set; }

        public Guid ProvisionId { get; set; }
    }
}
