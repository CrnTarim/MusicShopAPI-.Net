using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Data.Entities.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Common.Configuration
{
    class UserFavouriteSongConfiguration : IEntityTypeConfiguration<UserFavouriteSong>
    {
        public void Configure(EntityTypeBuilder<UserFavouriteSong> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(builder => builder.User).
                WithMany(builder => builder.UserFavouriteSongs).
                HasForeignKey(builder => builder.UserId).
                OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(builder => builder.SingleSong).
                    WithMany(builder => builder.UserFavouriteSongs).
                    HasForeignKey(builder => builder.SingleSongId).
                    OnDelete(DeleteBehavior.Cascade);

        }
    }
}
