using Northwind.Domain.Entities;
using Northwind.Application.Contracts.Persistence;

namespace Northwind.Persistence.EFCore.Repositories
{
	public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(NorthwindDbContext dbContext) : base(dbContext)
		{
		}
	}
}
