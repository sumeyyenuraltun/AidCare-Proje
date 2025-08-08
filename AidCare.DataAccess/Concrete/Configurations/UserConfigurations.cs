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
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TcNo)
           .IsRequired()
           .HasColumnType("char(11)");


            builder.HasIndex(x => x.TcNo)
                .HasDatabaseName("UIX_User_TcNo")
                .IsUnique();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasMaxLength(100);

            builder.HasIndex(x => x.Email)
                .HasDatabaseName("UIX_User_Email")
                .IsUnique();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(20);

            builder.HasIndex(x => x.PhoneNumber)
                .HasDatabaseName("UIX_User_PhoneNumber")
                .IsUnique();

            builder.Property(x => x.Weight)
                .HasPrecision(5, 2);

            builder.Property(x => x.Height);

            builder.Property(x => x.gender)
                .HasConversion<string>();

            builder.Property(x => x.BirthDate)
                .HasColumnType("timestamptz")
                .HasConversion(
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v,
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v
             );


            builder.Ignore(x => x.FullName);
            builder.Ignore(x => x.Age);

        }
    }
}
