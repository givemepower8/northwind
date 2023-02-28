using Microsoft.EntityFrameworkCore;
using Northwind.Application.Contracts.Persistence;
using Northwind.Persistence.EFCore;
using Northwind.Persistence.EFCore.Repositories;

namespace Northwind.API
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{



			return services;    
		}
	}
}
