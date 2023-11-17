using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace BanDochoi.Web.Models
{
    public class Category : CommonAbstract
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string Name { get; set; }
        [Display(Name = "Mô tả")]
        public string? Description { get; set; } = null!;
        public ICollection<Product>? Products { get; set; }
        public ICollection<Category>? CategoryChildren { get; set; }
        [Display(Name = "Danh mục cha")]
        public int? ParentCategoryId { get; set; }
        [Display(Name = "Danh mục cha")]
        public Category? ParentCategory { get; set; }
    }
}
