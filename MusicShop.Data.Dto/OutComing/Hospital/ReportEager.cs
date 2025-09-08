using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.OutComing.Hospital
{
    public class ReportEager
    {
        public Guid Id { get; set; }
        public int ReportCode { get; set; }

        public Guid ProvisionId { get; set; }
        public int ProvisionCode { get; set; }

        public Guid HospitalId { get; set; }
        public int HospitalCode { get; set; }
        public string HospitalName { get; set; } = default!;

        public Guid CityId { get; set; }
        public int CityCode { get; set; }
        public string CityName { get; set; } = default!;

        public DateTime ReportCreated { get; set; }
    }
}
