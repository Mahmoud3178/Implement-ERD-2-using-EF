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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            // Primary Key
            builder.HasKey(e => e.Id);

            // Properties
            builder.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Date)
                   .IsRequired();

            builder.Property(e => e.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            // Relationship: Airline (1) -> Expenses (Many)
            builder.HasOne(e => e.Airline)
                   .WithMany(a => a.Transactions)
                   .HasForeignKey(e => e.AirlineId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
