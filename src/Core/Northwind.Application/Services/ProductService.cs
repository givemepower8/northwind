using Northwind.Application.Contracts.Persistence;
using Northwind.Application.Contracts.Services;
using Northwind.Domain.Entities;

namespace Northwind.Application.Services;

public class ProductService : IProductService
{
	private readonly IProductRepository _productRepository;

	public ProductService(IProductRepository productRepository )
	{
		_productRepository = productRepository;
	}
	public Task<IReadOnlyList<Product>> GetProducts()
	{
		return _productRepository.ListAllAsync();
	}
}