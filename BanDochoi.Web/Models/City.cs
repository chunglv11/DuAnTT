
using System.ComponentModel.DataAnnotations;

namespace BanDochoi.Web.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "TỈnh thành", Prompt = "Tỉnh thành")]
        public string CityName { get; set; }
        public ICollection<District>? Districts { get; set; }
    }
}
