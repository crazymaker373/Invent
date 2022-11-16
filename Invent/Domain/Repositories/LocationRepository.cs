using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories;

public class LocationRepository : ARepository<Location>, ILocationRepository {
    public LocationRepository(StorageDbContext context) : base(context) {
    }

    public async Task<List<Location>> ReadGraphAsync(int id) {
        return await Set
            .Include(l => l.Inventory)
            .Where(l => l.InventoryId == id)
            .ToListAsync();
    }
}