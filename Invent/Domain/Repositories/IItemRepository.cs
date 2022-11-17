using Model.Entities;

namespace Domain.Repositories;

public interface IItemRepository : IRepository<Item> {
    public Task<List<Item>> ReadGraphAsync(int id);
    
    public Task<List<Item>> ReadByLocationAsync(int locationId);
}