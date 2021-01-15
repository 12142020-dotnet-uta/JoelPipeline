using System;
using Microsoft.EntityFrameworkCore;
using ModelLayer;


namespace RepositoryLayer
{
    public class GwDbContext : DbContext
    {

        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orderHistory { get; set; }
        public DbSet<StoreLocation> storeLocations { get; set; }
        public DbSet<Inventory> allInventory { get; set; }
        public DbSet<PurchasedProducts> purchasedProducts { get; set; }


        public GwDbContext()
        {

        }
        public GwDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=P1GwStoreDB;Trusted_Connection=True;");
            }
            /*
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=YourDbName;Trusted_Connection=True;");
            */
        }

        // add the inMemory framework with "dotnet add package Microsoft.EntityFramework.Core.InMemory -- 5.0.1" while in the .tests dir
        //in memory batabase set-up
        //setup empty constructor
        

    }
}
