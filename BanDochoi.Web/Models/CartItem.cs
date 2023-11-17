using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace BanDochoi.Web.Models
{
    public class CartItem
    {
        public int Quantity { set; get; }
        public virtual Product Product { set; get; }
        public string Image { set; get; }
    }
}
