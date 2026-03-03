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
    public class CrewConfiguration : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder.HasKey(c => c.AircraftId);
            // One-to-One relationship (Shared Primary Key)
            builder.HasOne(c => c.Aircraft)
                   .WithOne(a => a.Crew)
                   .HasForeignKey<Crew>(c => c.AircraftId);

            builder.Property(c => c.MajPilot)
            .HasMaxLength(100);

            builder.Property(c => c.AssisPilot)
                   .HasMaxLength(100);

            builder.Property(c => c.Host1)
                   .HasMaxLength(100);

            builder.Property(c => c.Host2)
                   .HasMaxLength(100);
        }
    }
}
