using BanDochoi.Web.Models.Enums;

namespace BanDochoi.Web.Areas.Admin.Models.Order
{
    public class OrderModel
    {
        public Status Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
