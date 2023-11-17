using Microsoft.AspNetCore.Mvc;
using BanDochoi.Web.Data;

namespace BanDochoi.Web.Views.Shared.Components.NewPostBox
{
    public class NewPostBox : ViewComponent
    {
        private readonly BanDoChoiDbContext _context;
        public NewPostBox(BanDoChoiDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var list = _context.Posts.OrderBy(p => p.CreatedDate).Take(5).ToList();
            return View(list);
        }
    }
}
