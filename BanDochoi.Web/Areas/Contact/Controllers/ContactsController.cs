using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BanDochoi.Web.Areas.Identity.Data;
using BanDochoi.Web.Data;
using ContactModel = BanDochoi.Web.Models.Contact;

namespace BanDochoi.Web.Areas.Contact.Controllers
{
    [Area("Contact")]
    [Authorize(Roles = "Admin")]
    public class ContactsController : Controller
    {
        private readonly BanDoChoiDbContext _context;

        public ContactsController(BanDoChoiDbContext context)
        {
            _context = context;
        }

        // GET: Contact/Contacts
        [Route("/Admin/Contact/")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return _context.Contacts != null ?
                        View(await _context.Contacts.ToListAsync()) :
                        Problem("Entity set 'BanDoChoiDbContext.Contacts'  is null.");
        }

        // GET: Contact/Contacts/Details/5
        [Route("/Admin/Contact/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contact/Contacts/Create
        [HttpGet("/Contact/")]
        [AllowAnonymous]
        public IActionResult SendContact()
        {
            return View();
        }

        [TempData]
        public string StatusMessage { get; set; }
        // POST: Contact/Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/Contact/")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendContact([Bind("Id,FullName,Email,Message,Phone")] ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                contact.DateSent = DateTime.Now;
                _context.Add(contact);
                await _context.SaveChangesAsync();
                StatusMessage = "Liên hệ đã được gửi";
                return RedirectToAction("Index", "Home");
            }
            return View(contact);
        }

        // GET: Contact/Contacts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Contacts == null)
        //    {
        //        return NotFound();
        //    }

        //    var contact = await _context.Contacts.FindAsync(id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(contact);
        //}

        //// POST: Contact/Contacts/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,DateSent,Message,Phone")] ContactModel contact)
        //{
        //    if (id != contact.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(contact);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ContactExists(contact.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(contact);
        //}

        //// GET: Contact/Contacts/Delete/5
        [Route("/Admin/Contact/Delete/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contact/Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("/Admin/Contact/Delete/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'BanDoChoiDbContext.Contacts'  is null.");
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                StatusMessage = $"Bạn vừa xóa liên hệ cua {contact.FullName}";
                _context.Contacts.Remove(contact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool ContactExists(int id)
        //{
        //  return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
