using Microsoft.EntityFrameworkCore;
using Northwind.Application.Contracts.Persistence;

namespace Northwind.Persistence.EFCore.Repositories
{
	public class BaseRepository<T> : IAsyncRepository<T> where T : class
	{

		protected readonly NorthwindDbContext DbContext;

		public BaseRepository(NorthwindDbContext dbContext)
		{
			DbContext = dbContext;
		}

		public virtual async Task<T?> GetByIdAsync(int id)
		{
			T? t = await DbContext.Set<T>().FindAsync(id);
			return t;
		}

		public virtual async Task<IReadOnlyList<T>> ListAllAsync()
		{
			return await DbContext.Set<T>().ToListAsync();
		}

		public virtual async Task<IReadOnlyList<T>> GetPagedListAsync(int page, int size)
		{
			return await DbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
		}

		public virtual async Task<T> AddAsync(T entity)
		{
			await DbContext.Set<T>().AddAsync(entity);
			await DbContext.SaveChangesAsync();

			return entity;
		}

		public virtual async Task UpdateAsync(T entity)
		{
			DbContext.Entry(entity).State = EntityState.Modified;
			await DbContext.SaveChangesAsync();
		}

		public virtual async Task DeleteAsync(T entity)
		{
			DbContext.Set<T>().Remove(entity);
			await DbContext.SaveChangesAsync();
		}
	}
}
