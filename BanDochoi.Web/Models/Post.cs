
using System.ComponentModel.DataAnnotations;

namespace BanDochoi.Web.Models
{
    public class Post : CommonAbstract
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string Title { get; set; }
        [Display(Name = "Mô tả ngắn")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string ShortDescription { get; set; }
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string Content { get; set; }
    }
}