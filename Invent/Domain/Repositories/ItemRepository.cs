using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories;

public class ItemRepository : ARepository<Item>{
    public ItemRepository(StorageDbContext context) : base(context){
    }
}