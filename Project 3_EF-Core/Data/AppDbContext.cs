using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project_3_EF_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_EF_Core.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Aircraft> aircrafts { get; set; }
        public DbSet<Airline> airlines { get; set; }

        public DbSet<AirlinePhone> airlinePhones { get; set; }
        public DbSet<Assigned> assigneds { get; set; }
        public DbSet<Crew> crewces { get; set; }    
        public DbSet<Employee> employees { get; set; }  
        public DbSet<EmployeeQualification> employeeQualifications { get; set; }
        public DbSet<Route> routes { get; set; }
        public DbSet<Transaction> transactions { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var conf = new ConfigurationBuilder()
                .AddJsonFile("appsetings.json")
                .Build();
            var constr = conf.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(constr);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}

