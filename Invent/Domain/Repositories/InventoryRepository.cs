using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories;

public class InventoryRepository : ARepository<Inventory>{
    public InventoryRepository(StorageDbContext context) : base(context){
    }
}