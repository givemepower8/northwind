using Northwind.Domain.Entities;

namespace Northwind.Application.Contracts.Persistence
{
  public interface ICategoryRepository : IAsyncRepository<Category>
  {
  }
}
