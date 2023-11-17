using Microsoft.AspNetCore.Identity;

namespace BanDochoi.Web.Areas.Admin.Models.Models
{
    public class RoleModel : IdentityRole
    {
        public string[] Claims { get; set; }

    }
}
