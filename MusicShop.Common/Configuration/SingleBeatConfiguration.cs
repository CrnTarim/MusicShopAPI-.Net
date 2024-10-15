using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Data.Entities.SingerInfo;
using MusicShop.Data.Entities.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Common.Configuration
{
    class SingleBeatConfiguration : IEntityTypeConfiguration<SingleBeat>
    {
        public void Configure(EntityTypeBuilder<SingleBeat> builder)
        {
            builder.HasOne(builder => builder.Beat)
            .WithMany(builder => builder.SingleBeats)
            .HasForeignKey(builder => builder.BeatId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(builder => builder.SingleSong)
            .WithMany(builder => builder.SingleBeats)
            .HasForeignKey(builder => builder.SingleSongId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
