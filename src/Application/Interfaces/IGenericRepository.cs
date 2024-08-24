using Domain.Common;
using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IGenericRepository<T> where T : class, IEntity
{
    IQueryable<T> Entities { get; }

    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}