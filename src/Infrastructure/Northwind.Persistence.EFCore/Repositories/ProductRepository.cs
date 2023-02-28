using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;
using Northwind.Application.Contracts.Persistence;

namespace Northwind.Persistence.EFCore.Repositories
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(NorthwindDbContext dbContext) : base(dbContext)
		{
		}

		public Task<IReadOnlyList<Product>> GetProductsByCategory(int categoryId)
		{
			return DbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync()
				.ContinueWith(x => x.Result.AsReadOnly() as IReadOnlyList<Product>);
		}
	}
}
