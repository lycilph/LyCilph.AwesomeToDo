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
        throw new NotImplementedException();

        //_dbContext.Set<T>().Update(entity);

        //await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();

        //return await _dbContext.Set<T>().AsQueryable().FirstOrDefaultAsync(filter, cancellationToken);
    }

    public async Task<T?> FirstOrDefaultAsync<TProperty>(Expression<Func<T, bool>> filter, Expression<Func<T, TProperty>> include, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().Include(include).AsQueryable().FirstOrDefaultAsync(filter, cancellationToken);
    }

    public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<List<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
        //return await _dbContext.Set<T>().Where(filter).ToListAsync(cancellationToken);
    }
}
