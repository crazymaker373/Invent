using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories;

public class ItemRepository : ARepository<Item>, IItemRepository{
    StorageDbContext _context;

    public ItemRepository(StorageDbContext context) : base(context){
        _context = context;
    }

    public async Task<List<Item>> ReadByInventoryIdAsync(int inventoryId){
        return await _context.Items.Where(e => e.Location.InventoryId == inventoryId).ToListAsync();
    }
}