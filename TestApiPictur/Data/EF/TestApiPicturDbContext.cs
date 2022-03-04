using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApiPictur.Data.Configuration;
using TestApiPictur.Extensions;
using TestApiPictur.Models;

namespace TestApiPictur.Data.EF
{
    public class TestApiPicturDbContext : DbContext
    {
        public TestApiPicturDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PicturConfiguration());

            //Data Seeding
            modelBuilder.Seed();
        }
        public DbSet<Pictur> Picturs { get; set; }
    }
}
