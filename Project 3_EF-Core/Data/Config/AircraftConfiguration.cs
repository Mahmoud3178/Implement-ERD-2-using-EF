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
    public class AircraftConfiguration : IEntityTypeConfiguration<Aircraft>
    {
        public void Configure(EntityTypeBuilder<Aircraft> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Model)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(128);

            builder.Property(x => x.Capacity)
            .IsRequired();

            //relation
            builder.HasOne(x => x.Airline)
                .WithMany(x => x.Aircrafts)
                .HasForeignKey(x => x.AirlineId);
     
  
        }
    }
}
