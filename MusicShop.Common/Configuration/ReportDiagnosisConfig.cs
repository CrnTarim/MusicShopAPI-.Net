using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Data.Entities.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Common.Configuration
{
    public class ReportDiagnosisConfig : IEntityTypeConfiguration<ReportDiagnosis>
    {
        public void Configure(EntityTypeBuilder<ReportDiagnosis> builder)
        {
            builder.HasKey(builder => builder.Id);

            builder.HasOne(builder => builder.Report)
               .WithOne(builder => builder.ReportDiagnosis)
               .HasForeignKey<ReportDiagnosis>(builder => builder.ReportId);

            builder.HasOne(builder => builder.Diagnosis)
                .WithMany(builder => builder.ReportDiagnoses)
                .HasForeignKey(builder => builder.DiagnosisId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
