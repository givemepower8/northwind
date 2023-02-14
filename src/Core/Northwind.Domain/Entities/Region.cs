namespace Northwind.Domain.Entities;

public class Region
{
  public Region()
  {
    Territories = new HashSet<Territory>();
  }

  public int RegionId { get; set; }
  public string RegionDescription { get; set; } = null!;

  public ICollection<Territory> Territories { get; set; }
}