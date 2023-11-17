using Microsoft.AspNetCore.Mvc;
using BanDochoi.Web.Data;

namespace BanDochoi.Web.Views.Shared.Components.ContactBox
{
    [ViewComponent]
    public class ContactBox : ViewComponent
    {
        private readonly BanDoChoiDbContext _context;
        public ContactBox(BanDoChoiDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var list = (from c in _context.Contacts
                        orderby c.DateSent descending
                        select c).Take(4).ToList();
            return View(list);
        }
    }
}
