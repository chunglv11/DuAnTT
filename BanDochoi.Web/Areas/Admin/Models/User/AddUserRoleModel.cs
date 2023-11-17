using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel;
using BanDochoi.Web.Areas.Identity.Data;

namespace BanDochoi.Web.Areas.Admin.Models.User
{
    public class AddUserRoleModel
    {
        public AppUser user { get; set; }

        [DisplayName("Các role gán cho user")]
        public string[] RoleNames { get; set; }

        public List<IdentityRoleClaim<string>> claimsInRole { get; set; }
        public List<IdentityUserClaim<string>> claimsInUserClaim { get; set; }
    }
}
