using Model.Entities;

namespace Domain.Repositories;

public interface IInventoryRepository : IRepository<Inventory> {
    Task UpdateLastEditAsync(Inventory inventory);
}