using Northwind.Application.Contracts.Persistence;
using Northwind.Application.Contracts.Services;
using Northwind.Domain.Entities;

namespace Northwind.Application.Services;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;

	public CategoryService(ICategoryRepository categoryRepository )
	{
		_categoryRepository = categoryRepository;
	}
	public Task<IReadOnlyList<Category>> GetCategories()
	{
		return _categoryRepository.ListAllAsync();
	}
}