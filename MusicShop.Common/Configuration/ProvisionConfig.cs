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
    public class ProvisionConfig : IEntityTypeConfiguration<Provision>
    {
        public void Configure(EntityTypeBuilder<Provision> builder)
        {
            builder.HasKey(builder => builder.Id);

            builder.HasOne(builder => builder.Hospital)
                .WithMany(builder => builder.Provisions)
                .HasForeignKey(builder => builder.HospitalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
