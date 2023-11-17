using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;

namespace BanDochoi.Web.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [Column(TypeName = "nvarchar")]
    [StringLength(50)]
    public string? FullName { get; set; }
    [Column(TypeName = "nvarchar")]
    [StringLength(400)]
    public string? HomeAdress { get; set; } = null!;
    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? BirthDate { get; internal set; }
}