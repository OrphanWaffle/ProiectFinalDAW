﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectFinalDAW.Models;

namespace ProiectFinalDAW.Data
{
    public class Context:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Quantity> Quantities { get; set; }
        public DbSet<OrderDetail> Order_Details { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.DateCreated)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<User>()
                .Property(e => e.DateModified)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Product>()
                .Property(e => e.DateCreated)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Product>()
                .Property(e => e.DateModified)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Quantity>()
                .Property(e => e.DateCreated)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Quantity>()
                .Property(e => e.DateModified)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.DateCreated)
                 .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.DateModified)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Order>()
                .Property(e => e.DateCreated)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Order>()
                .Property(e => e.DateModified)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Category>()
                .Property(e => e.DateCreated)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Category>()
                .Property(e => e.DateModified)
                .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
   
}
