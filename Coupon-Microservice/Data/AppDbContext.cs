using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupon_Microservice.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coupon_Microservice.Data
{
    public class AppDbContext : DbContext
       
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<Coupon>().HasData(new Coupon
             {
                CouponID = 1,
                CouponCode = "1OFF",
                DiscountAmount = 10,
                MinAmount = 100
             });

             modelBuilder.Entity<Coupon>().HasData(new Coupon
             {
                CouponID = 2,
                CouponCode = "100OFF",
                DiscountAmount = 10,
                MinAmount = 1000
             });
        }

       

    }

} 