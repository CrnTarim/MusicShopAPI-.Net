using MusicShop.Data.Entities.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.OutComing.Hospital
{
    public class ReportDiagnosisDto:BaseDto
    {
        public Guid ReportId { get; set; }
        public Guid DiagnosisId { get; set; }
       
    }
}
