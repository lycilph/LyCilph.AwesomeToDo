using System.Linq.Expressions;

namespace LyCilph.AwesomeToDo.Core.Interfaces;

public interface IRepository<T> where T : class, IAggregateRoot
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task<List<T>> ListAsync(CancellationToken cancellationToken = default);
    Task<List<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    Task<T?> FirstOrDefaultAsync<TProperty>(Expression<Func<T, bool>> filter, Expression<Func<T, TProperty>> include, CancellationToken cancellationToken = default);
}