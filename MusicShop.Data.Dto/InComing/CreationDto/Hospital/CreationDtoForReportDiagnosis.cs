using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.CreationDto.Hospital
{
    public class CreationDtoForReportDiagnosis:BaseDto
    {
        public Guid ReportId { get; set; }
        public Guid DiagnosisId { get; set; }
    }
}
