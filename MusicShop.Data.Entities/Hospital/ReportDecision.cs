using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.Hospital
{
    public class ReportDecision:BaseModel
    {
        public Guid ReportId { get; set; }
        public Report Report { get; set; } = null!;

        public Guid DecisionId { get; set; }
        public HCDecision Decision { get; set; } = null!;
      
    }
}
