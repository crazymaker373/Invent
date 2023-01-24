using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories;

public class ItemRepository : ARepository<Item>, IItemRepository {
    public ItemRepository(StorageDbContext context) : base(context) {
    }

    public async Task<List<Item>> ReadGraphAsync(int id) => await Set
        .Include(i => i.Location)
        .Where(i => i.Location.InventoryId == id)
        .ToListAsync();

    public async Task<List<Item>> ReadGraphAsync(int id, int locationId) => await Set
        .Include(i => i.Location)
        .Where(i => i.Location.InventoryId == id && i.LocationId == locationId)
        .ToListAsync();
}