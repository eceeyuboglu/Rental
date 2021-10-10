using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Rent;Trusted_Connection=true");
        }

        public DbSet<Home> Home { get; set; }
        public DbSet<Amenity> Amenity { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<HomeImage> HomeImage { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<FindexScore> FindexScore { get; set; }
        public DbSet<HostImage> HostImage { get; set; }
        public DbSet<Host> Host { get; set; }
       
        public DbSet<Location> Location { get; set; }

    }
}
