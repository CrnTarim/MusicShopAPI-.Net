using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.Hospital
{
    public class ReportDiagnosis:BaseModel
    {
        public Guid ReportId { get; set; }
        public Report Report { get; set; }


        public Guid DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }
    }
}
