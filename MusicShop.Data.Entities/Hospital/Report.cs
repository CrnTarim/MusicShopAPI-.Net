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
        public ReportState State { get; set; } = ReportState.Pending;

        public ReportDiagnosis? ReportDiagnosis { get; set; }
        public ReportDecision? ReportDecision { get; set; }


    }

    public enum ReportState
    {
        Pending = 1, // Beklemede
        BashekimApproved = 2, // Başhekim onaylı
        MsbApproved = 3, // MSB onaylı
        PertemApproved = 4, // PERTEM onaylı
        ZeyilInProgress = 5, // Zeyil işlemlerinde
        ManualZeyilCompleted = 6  // Manuel zeyil tamamlandı
    }
}
