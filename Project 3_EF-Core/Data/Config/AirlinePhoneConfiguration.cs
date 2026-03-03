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
    public class AirlinePhoneConfiguration : IEntityTypeConfiguration<AirlinePhone>
    {
        public void Configure(EntityTypeBuilder<AirlinePhone> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.PhoneNumber)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(11);


            //relation
            builder.HasOne(x => x.Airline)
                .WithMany(x => x.Phones)
                .HasForeignKey(x => x.AirlineId);

        }
    }
}
