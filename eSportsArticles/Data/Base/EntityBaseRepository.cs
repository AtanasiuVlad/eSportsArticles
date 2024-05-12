
using eSportsArticles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eSportsArticles.Data.Base
{
	public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
	{
		private readonly AppDBContext _context;
		public EntityBaseRepository(AppDBContext context) 
		{
			_context = context;
		}
		public  async Task AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid Id)
		{
			var entity = await _context.Set<T>().FirstOrDefaultAsync(n => Guid.Equals(n.Id, Id));
			EntityEntry entityEntry = _context.Entry<T>(entity);
			entityEntry.State = EntityState.Deleted;

			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			var result = await _context.Set<T>().ToListAsync();
			return result;
		}

		public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = _context.Set<T>();
			query = includeProperties.Aggregate(query, (current, includeProperties) => current.Include(includeProperties));
			return await query.ToListAsync();
		}

		public async Task<T> GetByIdAsync(Guid Id)
		{
			var result = await _context.Set<T>().FirstOrDefaultAsync(n => Guid.Equals(n.Id, Id));
			return result;
		}

		public async Task UpdateAsync(Guid Id, T entity)
		{
			EntityEntry entityEntry = _context.Entry<T>(entity);
			entityEntry.State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
