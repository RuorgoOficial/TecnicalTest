using CodereTecnicalTest.Domain.Entities;
using CodereTecnicalTest.Infrastructure.Context.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Infrastructure.Context
{
    public class CodereTecnicalTestDBContext : DbContext
    {
        public DbSet<Show> Shows {  get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Externals> Externals { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Self> Selves { get; set; }
        public DbSet<Previousepisode> Previousepisodes { get; set; }


        public CodereTecnicalTestDBContext(DbContextOptions<CodereTecnicalTestDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapShows();
            modelBuilder.MapNetworks();
            modelBuilder.MapCountries();
        }
    }
}
