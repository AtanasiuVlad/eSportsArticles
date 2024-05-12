using eSportsArticles.Models;
using System.Linq.Expressions;

namespace eSportsArticles.Data.Base
{
	public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
		Task<T> GetByIdAsync(Guid Id);
		Task AddAsync(T entity);
		Task UpdateAsync(Guid Id, T entity);
		Task DeleteAsync(Guid Id);
	}
}
