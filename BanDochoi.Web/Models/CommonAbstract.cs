using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BanDochoi.Web.Models
{
    public abstract class CommonAbstract
    {
        [Display(Name = "Tạo bởi")]
        public string? CreatedBy { get; set; }
        [Display(Name = "Ngày tạo")]
        [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Cập nhật bởi")]
        public string? ModifiedBy { get; set; }
        [Display(Name = "Ngày cập nhật")]
        [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedDate { get; set; }
    }
}
