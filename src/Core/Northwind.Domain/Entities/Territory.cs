namespace Northwind.Domain.Entities;

public class Territory
{
  public Territory()
  {
    Employees = new HashSet<Employee>();
  }

  public string TerritoryId { get; set; } = null!;
  public string TerritoryDescription { get; set; } = null!;
  public int RegionId { get; set; }

  public Region Region { get; set; } = null!;

  public ICollection<Employee> Employees { get; set; }
}