using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMT.Models;
using Microsoft.EntityFrameworkCore;

namespace HMT.Models
{
    public class HMTContext : DbContext
    {
        public HMTContext(DbContextOptions<HMTContext> options) : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Sold> Solds { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        //Photo page
        public DbSet<PStore> PStores { get; set; }
        public DbSet<PDiv> PDivs { get; set; }
        public DbSet<PItem> PItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sold>().HasKey(so => new { so.ProductID, so.SaleID });

            // BookAuthor: set foreign keys 
            modelBuilder.Entity<Sold>().HasOne(so => so.Product)
                .WithMany(pr => pr.Solds)
                .HasForeignKey(so => so.ProductID);
            modelBuilder.Entity<Sold>().HasOne(so => so.Sale)
                .WithMany(sa => sa.Solds)
                .HasForeignKey(so => so.SaleID);

            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   CategoryID = 1,
                   Name = "Camping"
               },
               new Category
               {
                   CategoryID = 2,
                   Name = "Footwear"
               }
               );
            modelBuilder.Entity<Vendor>().HasData(
               new Vendor
               {
                   VendorID = 1,
                   Name = "Pacifica Gear"
               },
               new Vendor
               {
                   VendorID = 2,
                   Name = "Mountain King"
               }
               );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1,
                    CategoryID=1,
                    VendorID=1,
                    Name = "Z Bag",
                    Price = 180
                }
                );
            modelBuilder.Entity<Store>().HasData(
               new Store
               {
                   StoreID = 1,
                   Street = "104 South Franklin Dr",
                   City ="Troy",
                   State="AL",
                   Zip=36081
               },
               
               new Store
               {
                   StoreID = 2,
                   Street = "601 Elm Street",
                   City = "Troy",
                   State = "AL",
                   Zip = 36081
               },
               new Store
               {
                   StoreID = 3,
                   Street = "192 Cedarhurst Ln",
                   City = "Milford",
                   State = "CT",
                   Zip = 06461
               }
               );

            modelBuilder.Entity<Customer>().HasData(
               new Customer
               {
                   CustomerID = 1,
                   Name = "Tran",
                   Phone = "7346292088",
                   Email = "tranminhhien14@gmail.com"
               }
               );
            modelBuilder.Entity<Sold>().HasData(
               new Sold
               {
                   SaleID = 1,
                   ProductID = 4,
                   Item = 2
               }
               );
            modelBuilder.Entity<PStore>().HasData(
               new PStore
               {
                   PStoreID = "SO",
                   Name="Store One",
               },
               new PStore
               {
                   PStoreID = "ST",
                   Name = "Store Two",
               }

               );
            modelBuilder.Entity<PDiv>().HasData(
               new PDiv
               {
                   PDivID = "B",
                   Name = "Bag",
               },
               new PDiv
               {
                   PDivID = "S",
                   Name = "Shoes",
               }
               );
            modelBuilder.Entity<PItem>().HasData(
               new
               {
                   PItemID = "1",
                   PStoreID = "SO",
                   PDivID = "B",
                   Image="",
               },
               new
               {
                   PItemID = "2",
                   PStoreID = "SO",
                   PDivID = "S",
                   Image = "",
               },
               new
               {
                   PItemID = "3",
                   PStoreID = "ST",
                   PDivID = "B",
                   Image = "",
               },
               new
               {
                   PItemID = "4",
                   PStoreID = "ST",
                   PDivID = "S",
                   Image = "",
               }
               );              
        }
    }
}
    
