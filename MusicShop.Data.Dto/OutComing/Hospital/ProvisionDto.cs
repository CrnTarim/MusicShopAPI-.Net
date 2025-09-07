using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.OutComing.Hospital
{
    public class ProvisionDto:BaseDto
    {

        public int Code { get; set; }


        public Guid HospitalId { get; set; }
    }
}
