using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.Hospital
{
    public class Provision: BaseModel
    {
        public int Code { get; set; }


        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; } = default!;



        public Report? Report { get; set; }

    }
}
