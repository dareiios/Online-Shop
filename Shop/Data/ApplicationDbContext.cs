using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CareCosmetic> CareCosmetics { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>().HasData(new Address
            {
                Id = 1,
                Street = "Pushkina 32",
                City = "Kazan",
                Region = "Tatarstan Republic"
            });


            modelBuilder.Entity<CareCosmetic>().HasData(new CareCosmetic
            {
                Id = 1,
                Description = "this is description",
                Image = "https://cdn.tkaner.com/wp/uploads/2020/11/kosmetika-1-scaled.jpg",
                AddressId =1,
                CareCosmeticCategory = Enums.CareCosmeticCategory.Маска,
                Title = "Маска для лица"
            });

            modelBuilder.Entity<CareCosmetic>().HasData(new CareCosmetic
            {
                Id = 2,
                Description = "this is description2",
                Image = "https://cdn.tkaner.com/wp/uploads/2020/11/kosmetika-1-scaled.jpg",
                AddressId = 1,
                CareCosmeticCategory = Enums.CareCosmeticCategory.Крем,
                Title = "Крем для лица"
            });


            modelBuilder.Entity<Basket>().HasData(new Basket
            {
                Id = 1,
            });
        }
    }
}
