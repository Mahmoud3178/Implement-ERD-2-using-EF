using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_3_EF_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_EF_Core.Data.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            // Properties
            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Gender)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(e => e.Position)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.Address)
                   .HasMaxLength(200);

            builder.Property(e => e.Birthday)
                   .IsRequired();

            // Relationship: Airline (1) -> Employees (Many)
            builder.HasOne(e => e.Airline)
                   .WithMany(a => a.Employees)
                   .HasForeignKey(e => e.AirlineId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relationship: Employee -> EmployeeQualifications (1 : Many)
            builder.HasMany(e => e.Qualifications)
                   .WithOne(eq => eq.Employee)
                   .HasForeignKey(eq => eq.EmployeeId);


        }
    }
}
