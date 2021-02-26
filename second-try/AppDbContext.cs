using Microsoft.EntityFrameworkCore;
using second_try.Models;
using second_try.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new UserTagConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
