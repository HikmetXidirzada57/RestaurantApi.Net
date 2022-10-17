using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RestaurantDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.\;Database=RestaurantDb;Trusted_Connection=true;MultipleActiveResultSets=true");

        }
        //public RestaurantDbContext(DbContextOptions opt):base(opt)
        //{

        //}
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealCategory> MealCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderInfo> OrderInfos { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
    }

    //protected override void OnModalCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //    var meal1 = new Meal
    //    {
    //        Id = 1,
    //        Name = "Lahmacun",
    //        Price = 15,
    //        Discount = 10,
    //        MealCategoryId = 1,
    //        IsDeleted = false,
    //    };

    //    modelBuilder.Entity<Meal>().HasData(meal1);
    //    modelBuilder.Entity<MealCategory>().HasData(
    //      new MealCategory
    //      {
    //          Id = 1,
    //          Name = "Category",
    //          IsDeleted = false,
    //      });


    //    modelBuilder.Entity<Table>().HasData(
    //        new Table
    //        { 
    //            Id=1,
    //            Name="Masa 1",
    //            IsDeleted = false,
    //        });
    //}

}
