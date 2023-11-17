using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDochoi.Web.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
