using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.Hospital
{
    public class City:BaseModel
    {
        public int CityCode { get; set; }
        public string CityName { get; set; }


        public ICollection<Hospital> Hospitals { get; set; }
    }
}
