using LyCilph.AwesomeToDo.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LyCilph.AwesomeToDo.Infrastructure.Data;

public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
{
    private readonly AppDbContext _dbContext;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Update(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> filter)
    {
        return await _dbContext.Set<T>().AsQueryable().FirstOrDefaultAsync(filter);
    }
}
