using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using BanDochoi.Web.Models.Enums;

namespace BanDochoi.Web.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Vote { get; set; }
        public string Comment { get; set; }
        [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreatedDate { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
