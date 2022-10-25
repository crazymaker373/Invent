using Model.Entities;

namespace Domain.Repositories;

public interface IItemRepository{
    Task<List<Item>> ReadByInventoryIdAsync(int inventoryId);

}