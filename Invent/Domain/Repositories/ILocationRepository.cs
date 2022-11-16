using Model.Entities;

namespace Domain.Repositories; 

public interface ILocationRepository : IRepository<Location> {
    public Task<List<Location>> ReadGraphAsync(int id);

}