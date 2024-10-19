using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShop.Data.Entities.Song;

namespace MusicShop.Common.Configuration
{
    public class SingleSongConfiguration : IEntityTypeConfiguration<SingleSong>
    {
        public void Configure(EntityTypeBuilder<SingleSong> builder)
        {
            builder.HasKey(builder => builder.Id);

            builder.HasOne(builder => builder.Singer)
                .WithMany(builder => builder.SingleSongs)
                .HasForeignKey(builder => builder.SingerId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
