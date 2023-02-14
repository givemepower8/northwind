using Northwind.Domain.Entities;

namespace Northwind.Application.Contracts.Persistence
{
  public interface IProductRepository : IAsyncRepository<Product>
  {
  }
}
