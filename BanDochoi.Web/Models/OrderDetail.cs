using MessagePack;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace BanDochoi.Web.Models
{
    public class OrderDetail
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
