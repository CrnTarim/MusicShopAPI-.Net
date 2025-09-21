using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.Hospital
{
    public class HCDecision :BaseModel
    {
        public int Code { get; set; }
        public string Name { get; set; } = null!;
        public int PertemOnay { get; set; }
        public int MsbOnay { get; set; }
        public int Bashekim { get; set; }
        public ICollection<ReportDecision> ReportDecisions { get; set; } = new List<ReportDecision>();
    }
}
