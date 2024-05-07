using System.Linq.Expressions;

namespace LyCilph.AwesomeToDo.Core.Interfaces;

public interface IRepository<T> where T : class, IAggregateRoot
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task<T?> FirstOrDefault(Expression<Func<T, bool>> filter);
}