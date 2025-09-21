using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.Hospital
{
    public class Diagnosis : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }


        public ICollection<ReportDiagnosis> ReportDiagnoses { get; set; } = new List<ReportDiagnosis>();

    }
}
