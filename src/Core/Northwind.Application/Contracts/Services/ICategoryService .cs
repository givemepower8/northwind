using Northwind.Domain.Entities;

namespace Northwind.Application.Contracts.Services;

public interface ICategoryService
{
    Task<IReadOnlyList<Category>> GetCategories();
}