using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BanDochoi.Web.Data;

namespace BanDochoi.Web.Views.Shared.Components.NewProductBox
{
    public class NewProductBox : ViewComponent
    {
        private readonly BanDoChoiDbContext _context;
        public NewProductBox(BanDoChoiDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var products = _context.Products.Include(p => p.ProductImages).Include(p => p.Category).AsQueryable();
            products = products.OrderByDescending(p => p.CreatedDate).Take(10);
            return View(products.ToList());
        }
    }
}
