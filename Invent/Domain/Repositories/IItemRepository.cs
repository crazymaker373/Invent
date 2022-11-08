using Model.Entities;

namespace Domain.Repositories; 

public interface IItemRepository : IRepository<Item> {
    public Task<List<Item>> ReadAllLocationsAsync();
}