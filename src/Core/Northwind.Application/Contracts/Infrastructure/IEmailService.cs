using Northwind.Application.Models.Email;

namespace Northwind.Application.Contracts.Infrastructure
{
    public interface IEmailService
  {
    Task<bool> SendEmail(Email email);
  }
}
