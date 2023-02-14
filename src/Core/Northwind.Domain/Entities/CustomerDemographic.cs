namespace Northwind.Domain.Entities;

public class CustomerDemographic
{
  public CustomerDemographic()
  {
    Customers = new HashSet<Customer>();
  }

  public string CustomerTypeId { get; set; } = null!;
  public string? CustomerDesc { get; set; }

  public ICollection<Customer> Customers { get; set; }
}