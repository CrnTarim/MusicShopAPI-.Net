using MusicShop.Data.Entities.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.OutComing.Hospital
{
    public class ReportDiagnosisEager
    {
        public Guid Id { get; set; }

        public Guid ReportId { get; set; }   
        public int ReportCode { get; set; }

        public Guid DiagnosisId { get; set; }
        public string DiagnosisCode { get; set; } 
        public string DiagnosisName { get; set; }

        public Guid ProvisionId { get; set; }
        public int ProvisionCode { get; set; }

        public Guid HospitalId { get; set; }
        public int HospitalCode { get; set; }
        public string HospitalName { get; set; } 

        public Guid CityId { get; set; }
        public int CityCode { get; set; }
        public string CityName { get; set; } 


        public DateTime ReportCreated { get; set; }
    }
}
