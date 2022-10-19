using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories;

public class LocationRepository : ARepository<Location>{
    public LocationRepository(StorageDbContext context) : base(context){
    }
}