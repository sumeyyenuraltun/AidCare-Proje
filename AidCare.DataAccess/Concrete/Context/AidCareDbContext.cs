using AidCare.DataAccess.Concrete.Configurations;
using AidCare.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.DataAccess.Concrete.Context
{
    public class AidCareDbContext : DbContext
    {
        public AidCareDbContext(DbContextOptions<AidCareDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new BloodGlucoseConfigurations());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BloodGlucose> BloodGlucoses { get; set;}
    }
}
