using Microsoft.AspNetCore.Mvc;
using BanDochoi.Web.Data;
using BanDochoi.Web.Services;

namespace BanDochoi.Web.Views.Shared.Components.CartBox
{
    [ViewComponent]
    public class CartBox : ViewComponent
    {
        private readonly CartService _cartService;
        public CartBox(CartService cartService)
        {
            _cartService = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_cartService.GetCartItems());
        }
    }
}
