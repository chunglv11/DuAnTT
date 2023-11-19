

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using BanDochoi.Web.Models.Enums;
using BanDochoi.Web.Areas.Identity.Data;

namespace BanDochoi.Web.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Họ tên")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Ghi chú")]
        public string? Note { get; set; }
        [Display(Name = "Tổng thanh toán")]
        public decimal Total { get; set; }
        [Display(Name = "Trạng thái")]
        public Status Status { get; set; }
        [Display(Name = "Ngày đặt")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Ngày giao hàng")]
        [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeliveryDate { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        public string PaymentMethod { get; set; }
        public int DistrictId { get; set; }
        public string AppUserId { get; set; }
        public virtual District? District { get; set; }
        public virtual AppUser AppUser { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
