using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;

namespace Northwind.Persistence.EFCore.IntegrationTests
{
  public class NorthwindDbContextTests
  {
    [Fact]
    public void DbContextAddCategory()
    {
      var dbContextOptions = new DbContextOptionsBuilder<NorthwindDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

      NorthwindDbContext db = new NorthwindDbContext(dbContextOptions);

      var countBefore = db.Categories.Count();
      var category = new Category { CategoryName = "Test", Description = "test", CategoryId = 1 };
      db.Categories.Add(category);
      db.SaveChanges();
      var countAfter = db.Categories.Count();
      Assert.Equal(countBefore + 1, countAfter);
    }
  }
}