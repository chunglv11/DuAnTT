using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BanDochoi.Web.Models
{
    public class Discuss
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Comment { get; set; }
        public int ReviewId { get; set; }
        public virtual Review Review { get; set; }
        public ICollection<Discuss>? DiscussChildren { get; set; }
        public int? ParentDiscussId { get; set; }
        public Discuss? ParentDiscuss { get; set; }
    }
}
