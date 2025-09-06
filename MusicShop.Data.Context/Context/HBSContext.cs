using Microsoft.EntityFrameworkCore;
using MusicShop.Data.Entities.Hospital;
using MusicShop.Data.Entities.SingerInfo;
using MusicShop.Data.Entities.Song;
using MusicShop.Data.Entities.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Context.Context
{
    public class HBSContext : DbContext
    {
        public HBSContext(DbContextOptions<HBSContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//PROTECTED 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SingleSong> SingleSongs { get; set; }

        public DbSet<Singer> Singers { get; set; }

        public DbSet<SingleBeat> SingleBeats { get; set; }

        public DbSet<Beat> Beats { get; set; }

        public DbSet<UserFavouriteSong> UserFavouriteSongs { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Person> Persons { get; set; }




        public DbSet<City> Cities { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Provision> Provisions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<ReportDiagnosis> ReportDiagnoses { get; set; }


    }
}
