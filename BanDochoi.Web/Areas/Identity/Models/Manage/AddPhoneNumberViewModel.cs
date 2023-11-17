using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BanDochoi.Web.Areas.Identity.Models.Manage
{
    public class AddPhoneNumberViewModel
    {
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Phone]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}
