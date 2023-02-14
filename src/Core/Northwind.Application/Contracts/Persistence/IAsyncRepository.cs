namespace Northwind.Application.Contracts.Persistence
{
  /// <summary>
  /// The general repository for CRUD operations used by application
  /// leave the concrete implementation to whatever EF core / Azure Cosmos / MongoDB
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IAsyncRepository<T> where T : class
  {
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size);
  }
}
