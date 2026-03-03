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
    public class AssignedConfiguration : IEntityTypeConfiguration<Assigned>
    {
        public void Configure(EntityTypeBuilder<Assigned> builder)
        {
            // 1️⃣ Composite Primary Key
            builder.HasKey(a => new { a.AircraftId, a.RouteId });

            // 2️⃣ Relationship: Aircraft → Assigned (1 : M)
            builder.HasOne(a => a.Aircraft)
                   .WithMany(ac => ac.AssignedRoutes)
                   .HasForeignKey(a => a.AircraftId);

            // 3️⃣ Relationship: Route → Assigned (1 : M)
            builder.HasOne(a => a.Route)
                   .WithMany(r => r.AssignedAircrafts)
                   .HasForeignKey(a => a.RouteId);

            // 4️⃣ Properties Configuration
            builder.Property(a => a.Price)
                   .HasColumnType("decimal(18,2)");

            builder.Property(a => a.NumOfPassengers)
                   .IsRequired();

            builder.Property(a => a.Departure)
                   .IsRequired();

            builder.Property(a => a.Arrival)
                   .IsRequired();

            // Duration → NotMapped (مش محتاجة Config)
        }
    }
}
