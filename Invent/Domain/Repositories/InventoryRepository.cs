using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories;

public class InventoryRepository : ARepository<Inventory>, IInventoryRepository {
    public InventoryRepository(StorageDbContext context) : base(context) {
    }

    public async Task<Inventory?> ReadGraphAsync(int id) => await Set
        .Where(i => i.Id == id)
        .Include(i => i.Locations)
        .ThenInclude(l => l.Items).FirstOrDefaultAsync();

    public async Task UpdateLastEditAsync(Inventory inventory) {
        inventory.LastEdit = DateTime.Now;
        await UpdateAsync(inventory);
    }
}