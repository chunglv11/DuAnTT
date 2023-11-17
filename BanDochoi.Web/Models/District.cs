using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDochoi.Web.Models
{
    public class District
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Quận huyện", Prompt = "Quận huyện")]
        public string Name { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
