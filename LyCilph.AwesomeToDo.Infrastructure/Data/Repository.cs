using LyCilph.SharedKernel;

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
}
