using Northwind.Domain.Entities;

namespace Northwind.Application.Contracts.Services;

public interface IProductService
{
    Task<IReadOnlyList<Product>> GetProducts();
}