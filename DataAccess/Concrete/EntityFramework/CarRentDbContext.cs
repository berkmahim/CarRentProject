using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarRentDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(@"Server=brkmhm;Database=CarRentDb;Trusted_Connection=True");
            optionsBuilder.UseSqlServer(@"Server=brkmhm;Database=CarRentDb;Trusted_Connection=True;TrustServerCertificate=True");


            //optionsBuilder.UseSqlServer(@"Server=BRKMHM;Database=CarRentDb;TrustServerCertificate=True");

            /* optionsBuilder.UseSqlServer(@"Server=BRKMHM;Database=CarRentDb;TrustServerCertificate=True", builder =>
             {
                 builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
             });
             base.OnConfiguring(optionsBuilder); */
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
