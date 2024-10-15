using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Data.Entities.SingerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Common.Configuration
{
    public class SingerConfiguration : IEntityTypeConfiguration<Singer>
    {
        public void Configure(EntityTypeBuilder<Singer> builder)
        {
            builder.HasKey(builder => builder.Id);

        }
    }
}
