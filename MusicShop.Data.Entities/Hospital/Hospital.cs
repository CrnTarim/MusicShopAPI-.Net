using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.Hospital
{
    public class Hospital:BaseModel
    {
        public int Code { get; set; }
        public string Name { get; set; }


        public Guid CityId { get; set; }
        public City City { get; set; }


        public ICollection<Provision> Provisions { get; set; }

      
    }
}
