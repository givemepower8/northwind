using Northwind.Domain.Entities;

namespace Northwind.Application.Contracts.Persistence
{
  public interface IProductRepository : IAsyncRepository<Product>
  {
	  Task<IReadOnlyList<Product>> GetProductsByCategory(int categoryId);
  }
}
