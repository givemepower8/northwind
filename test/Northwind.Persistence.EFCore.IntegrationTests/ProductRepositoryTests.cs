using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;
using Northwind.Persistence.EFCore.Repositories;

namespace Northwind.Persistence.EFCore.IntegrationTests
{
	public class ProductRepositoryTests
	{
		[Fact]
		public async Task ProductRepository_GetAllProducts()
		{
			var dbContextOptions = new DbContextOptionsBuilder<NorthwindDbContext>()
			  .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

			NorthwindDbContext db = new NorthwindDbContext(dbContextOptions);

			ProductRepository productRepository = new ProductRepository(db);

			var product = new Product
			{
				ProductName = "test",
				Discontinued = false
			};

			var productAdded = await productRepository.AddAsync(product);

			Assert.True(productAdded.ProductId > 0);

			var products = await productRepository.ListAllAsync();

			Assert.True(products.Any());

		}
	}
}