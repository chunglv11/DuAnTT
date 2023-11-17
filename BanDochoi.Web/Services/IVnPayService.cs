using BanDochoi.Web.Models;

namespace BanDochoi.Web.Services
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(Order model, HttpContext context);
        Order PaymentExecute(IQueryCollection collections);
    }
}
