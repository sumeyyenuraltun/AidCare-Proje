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

        public DbSet<User> Users { get; set; }
        public DbSet<BloodGlucose> BloodGlucoses { get; set;}
    }
}
