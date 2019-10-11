﻿//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace Project0.DataAccess.Entities
//{
//    public partial class Project0DBContext : DbContext
//    {
//        public Project0DBContext()
//        {
//        }

//        public Project0DBContext(DbContextOptions<Project0DBContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<CustOrder> CustOrder { get; set; }
//        public virtual DbSet<Customer> Customer { get; set; }
//        public virtual DbSet<Inventory> Inventory { get; set; }
//        public virtual DbSet<Location> Location { get; set; }
//        public virtual DbSet<Orders> Orders { get; set; }
//        public virtual DbSet<Product> Product { get; set; }

        

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<CustOrder>(entity =>
//            {
//                entity.Property(e => e.CustOrderId).HasColumnName("CustOrderID");

//                entity.Property(e => e.OrderId).HasColumnName("OrderID");

//                entity.Property(e => e.ProductId).HasColumnName("ProductID");

//                entity.HasOne(d => d.Order)
//                    .WithMany(p => p.CustOrder)
//                    .HasForeignKey(d => d.OrderId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__CustOrder__Order__571DF1D5");

//                entity.HasOne(d => d.Product)
//                    .WithMany(p => p.CustOrder)
//                    .HasForeignKey(d => d.ProductId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__CustOrder__Produ__5812160E");
//            });

//            modelBuilder.Entity<Customer>(entity =>
//            {
//                entity.HasKey(e => e.CustId)
//                    .HasName("PK__Customer__049E3A89BADA0DE4");

//                entity.Property(e => e.CustId).HasColumnName("CustID");

//                entity.Property(e => e.City)
//                    .IsRequired()
//                    .HasMaxLength(20);

//                entity.Property(e => e.FirstName)
//                    .IsRequired()
//                    .HasMaxLength(20);

//                entity.Property(e => e.LastName)
//                    .IsRequired()
//                    .HasMaxLength(20);

//                entity.Property(e => e.State)
//                    .IsRequired()
//                    .HasMaxLength(20);

//                entity.Property(e => e.Street)
//                    .IsRequired()
//                    .HasMaxLength(20);

//                entity.Property(e => e.ZipCode)
//                    .IsRequired()
//                    .HasMaxLength(20);
//            });

//            modelBuilder.Entity<Inventory>(entity =>
//            {
//                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

//                entity.Property(e => e.LocationId).HasColumnName("LocationID");

//                entity.Property(e => e.ProductId).HasColumnName("ProductID");

//                entity.HasOne(d => d.Location)
//                    .WithMany(p => p.Inventory)
//                    .HasForeignKey(d => d.LocationId)
//                    .HasConstraintName("FK__Inventory__Locat__5441852A");

//                entity.HasOne(d => d.Product)
//                    .WithMany(p => p.Inventory)
//                    .HasForeignKey(d => d.ProductId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__Inventory__Produ__534D60F1");
//            });

//            modelBuilder.Entity<Location>(entity =>
//            {
//                entity.Property(e => e.LocationId).HasColumnName("LocationID");

//                entity.Property(e => e.BranchName)
//                    .IsRequired()
//                    .HasMaxLength(50);

//                entity.Property(e => e.City)
//                    .IsRequired()
//                    .HasMaxLength(20);

//                entity.Property(e => e.State)
//                    .IsRequired()
//                    .HasMaxLength(20);

//                entity.Property(e => e.Street)
//                    .IsRequired()
//                    .HasMaxLength(20);

//                entity.Property(e => e.ZipCode)
//                    .IsRequired()
//                    .HasMaxLength(20);
//            });

//            modelBuilder.Entity<Orders>(entity =>
//            {
//                entity.HasKey(e => e.OrderId)
//                    .HasName("PK__Orders__C3905BAF69989545");

//                entity.Property(e => e.OrderId).HasColumnName("OrderID");

//                entity.Property(e => e.CustId).HasColumnName("CustID");

//                entity.Property(e => e.LocationId).HasColumnName("LocationID");

//                entity.Property(e => e.OrderDate).HasColumnType("datetime");

//                entity.HasOne(d => d.Cust)
//                    .WithMany(p => p.Orders)
//                    .HasForeignKey(d => d.CustId)
//                    .HasConstraintName("FK__Orders__CustID__4F7CD00D");

//                entity.HasOne(d => d.Location)
//                    .WithMany(p => p.Orders)
//                    .HasForeignKey(d => d.LocationId)
//                    .HasConstraintName("FK__Orders__Location__5070F446");
//            });

//            modelBuilder.Entity<Product>(entity =>
//            {
//                entity.Property(e => e.ProductId).HasColumnName("ProductID");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(50);

//                entity.Property(e => e.Price).HasColumnType("money");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
