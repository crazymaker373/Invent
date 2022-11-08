using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories;

public class InventoryRepository : ARepository<Inventory>, IInventoryRepository{
    public InventoryRepository(StorageDbContext context) : base(context){
    }

    public async Task UpdateLastEditAsync(Inventory inventory) {
        inventory.LastEdit = DateTime.Now;
        await UpdateAsync(inventory);
    }
}