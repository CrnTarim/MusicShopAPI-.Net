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
    public class ReportConfig : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(builder => builder.Id);

            builder.HasOne(builder => builder.Provision)
                .WithOne(builder => builder.Report)
                .HasForeignKey<Report>(builder => builder.ProvisionId);
                

        }
    }
}
