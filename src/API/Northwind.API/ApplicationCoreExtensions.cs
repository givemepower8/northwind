using Microsoft.EntityFrameworkCore;
using Northwind.Application.Contracts.Persistence;
using Northwind.Application.Contracts.Services;
using Northwind.Application.Services;
using Northwind.Persistence.EFCore;
using Northwind.Persistence.EFCore.Repositories;

namespace Northwind.API
{
	public static class ApplicationCoreExtensions
	{
		/// <summary>
		/// DI for application core
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
		{

			services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<ICategoryService, CategoryService>();

			return services;    
		}
	}
}
