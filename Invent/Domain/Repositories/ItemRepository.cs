using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories;

public class ItemRepository : ARepository<Item>, IItemRepository {
    public ItemRepository(StorageDbContext context) : base(context){
    }

    public async Task<List<Item>> ReadAllLocationsAsync() =>
        await Set
            .Include(i => i.Location)
            .ThenInclude(l => l.Inventory)
            .ToListAsync();
    
}