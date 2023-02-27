using Northwind.Domain.Entities;
using Northwind.Application.Contracts.Persistence;

namespace Northwind.Persistence.EFCore.Repositories
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(NorthwindDbContext dbContext) : base(dbContext)
		{
		}
	}
}
