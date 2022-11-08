using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories;

public abstract class ARepository<TEntity>: IRepository<TEntity> where TEntity: class{
    private readonly StorageDbContext _context;
    protected readonly DbSet<TEntity> Set;

    public ARepository(StorageDbContext context) {
        _context = context;
        Set = _context.Set<TEntity>();
    }

    public async Task<TEntity?> ReadAsync(int id) => await Set.FindAsync(id);

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter) => await Set.Where(filter).ToListAsync();

    public async Task<List<TEntity>> ReadAllAsync() => await Set.ToListAsync();

    public async Task<List<TEntity>> ReadAsync(int start, int count) => await Set.Skip(start).Take(count).ToListAsync();

    public async Task<TEntity> CreateAsync(TEntity entity) {
        Set.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(TEntity entity){
        _context.ChangeTracker.Clear();
        Set.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity) {
        Set.Remove(entity);
        await _context.SaveChangesAsync();
    }
}