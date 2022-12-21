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

    public async Task<List<Item>> ReadByLocationAsync(int locationId) => await Set
        .Include(i => i.Location)
        .Where(i => i.LocationId == locationId)
        .ToListAsync();

    public async Task<Item> ReadByCodeAsync(string code) => await Set
        .Include(i => i.Location)
        .FirstOrDefaultAsync(i => i.Code == code);
}