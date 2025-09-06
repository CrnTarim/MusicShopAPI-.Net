using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.Hospital
{
    public class Report: BaseModel
    {
        public int Code { get; set; }


        public Guid ProvisionId { get; set; }
        public Provision Provision { get; set; }


        public ReportDiagnosis? ReportDiagnosis { get; set; }
    }
}
