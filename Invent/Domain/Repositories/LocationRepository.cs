using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories;

public class LocationRepository : ARepository<Item>{
    public LocationRepository(StorageDbContext context) : base(context){
    }
}