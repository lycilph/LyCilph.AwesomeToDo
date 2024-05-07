namespace LyCilph.SharedKernel;

public interface IRepository<T> where T : class, IAggregateRoot
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task<T?> FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> filter);
}