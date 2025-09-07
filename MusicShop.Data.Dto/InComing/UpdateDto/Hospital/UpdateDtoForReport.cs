using MusicShop.Data.Entities.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.UpdateDto.Hospital
{
    public class UpdateDtoForReport:BaseDto
    {
        public int Code { get; set; }

        public Guid ProvisionId { get; set; }

    }
}
