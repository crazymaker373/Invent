﻿using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations;

public class StorageDbContext : DbContext {
    public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options) {
    }


    public DbSet<Item> Items { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<Item>().HasIndex(i => i.Code).IsUnique();
        builder.Entity<Item>().HasOne(i => i.Location).WithMany(l => l.Items).HasForeignKey(i => i.LocationId);

        builder.Entity<Location>().HasOne(i => i.Inventory).WithMany(i => i.Locations).HasForeignKey(i => i.InventoryId);
        
        builder.Entity<Item>().Property(i => i.ItemType).HasConversion<string>();
    }
}