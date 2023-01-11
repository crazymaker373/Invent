using Model.Entities;

namespace Domain.Repositories;

public interface IInventoryRepository : IRepository<Inventory> {

    public Task<Inventory?> ReadGraphAsync(int id);
    
    public Task UpdateLastEditAsync(Inventory inventory);
}