namespace Northwind.Application.Contracts.Persistence
{
	/// <summary>
	/// The general repository for CRUD async operations used by application
	/// leave the concrete implementation to whatever EF core / Azure Cosmos / MongoDB
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IAsyncRepository<T> where T : class
	{
		/// <summary>
		/// All repository of T manage entities which has Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<T?> GetByIdAsync(int id);

		Task<IReadOnlyList<T>> ListAllAsync();
		
		Task<T> AddAsync(T entity);
		
		Task UpdateAsync(T entity);
		
		Task DeleteAsync(T entity);
		
		Task<IReadOnlyList<T>> GetPagedListAsync(int page, int size);
	}
}
