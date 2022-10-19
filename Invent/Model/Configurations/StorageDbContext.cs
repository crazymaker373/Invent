using Microsoft.EntityFrameworkCore;

namespace Model.Configurations;

public class StorageDbContext : DbContext{
    public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options){
    }


    //public DbSet<> Items{ get; set; }

    protected override void OnModelCreating(ModelBuilder builder){
        
    }
}