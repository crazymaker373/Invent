using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations;

public class StorageDbContext : DbContext{
    public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options){
    }


    public DbSet<Item> Items{ get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder){
        
    }
}