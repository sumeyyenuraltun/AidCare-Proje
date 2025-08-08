using AidCare.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.DataAccess.Concrete.Configurations
{
    public class BloodGlucoseConfigurations : IEntityTypeConfiguration<BloodGlucose>
    {
        public void Configure(EntityTypeBuilder<BloodGlucose> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                   .IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany() 
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.MeasurementDate)
                   .IsRequired()
                   .HasColumnType("timestamp with time zone");

            builder.Property(x => x.MeasurementType)
                   .IsRequired()
                   .HasConversion<string>();

            builder.Property(x => x.MeasurementValue)
                   .IsRequired()
                   .HasPrecision(5, 2);
        }
    }
}
