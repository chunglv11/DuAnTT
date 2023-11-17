using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Asn1.Mozilla;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDochoi.Web.Models
{
    public class Product : CommonAbstract
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Tóm tắt")]
        public string Summary { get; set; }
        [Column(TypeName = "decimal")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Giá bán")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Chi tiết")]
        public string? Description { get; set; }
        //[Required(ErrorMessage = "Phải nhập {0}")]
        //[Display(Name = "Trạng thái")]
        //public bool Status { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}