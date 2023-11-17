using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BanDochoi.Web.Areas.Identity.Data;
using BanDochoi.Web.Data;
using BanDochoi.Web.Infrastructures;
using BanDochoi.Web.Models;

namespace BanDochoi.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Posts/[action]")]
    public class PostsController : Controller
    {
        //private readonly WatchStoreDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        public PostsController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        // GET: Admin/Posts
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Posts != null ? 
        //                  View(await _context.Posts.ToListAsync()) :
        //                  Problem("Entity set 'WatchStoreDbContext.Posts'  is null.");
        //}
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = _unitOfWork.PostRepository.GetAll();
            return View(list);
        }

        // GET: Admin/Posts/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Posts == null)
        //    {
        //        return NotFound();
        //    }

        //    var post = await _context.Posts
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(post);
        //}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.PostRepository.GetAll() == null)
            {
                return NotFound();
            }

            var product = _unitOfWork.PostRepository.Get(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,Content,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Post post)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(post);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(post);
        //}
        [TempData]
        public string StatusMessage { get; set; }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ShortDescription,Content")] Post post)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(post);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                post.CreatedBy = _userManager.GetUserName(User);
                post.CreatedDate = DateTime.Now;
                _unitOfWork.PostRepository.Add(post);
                await _unitOfWork.SaveChangeAsync();
                StatusMessage = $"Đã thêm thành công bài viết: {post.Id}";
                return RedirectToAction(nameof(Index));
            }
            StatusMessage = $"Không thể thêm bài viết: {post.Id}";
            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _unitOfWork.PostRepository.Get(id.Value);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Post post)
        //{
        //    if (id != post.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(post);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PostExists(post.Id))
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
        //    return View(post);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ShortDescription,Content,CreatedDate,CreatedBy")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                post.ModifiedDate = DateTime.Now;
                post.ModifiedBy = _userManager.GetUserName(User);
                _unitOfWork.PostRepository.Update(post);
                await _unitOfWork.SaveChangeAsync();
                StatusMessage = $"Đã cập nhập bài viết: {post.Id}";
                return RedirectToAction(nameof(Index));
            }
            StatusMessage = $"Cập nhập không thành công bài viết: {post.Id}";
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Posts == null)
        //    {
        //        return NotFound();
        //    }

        //    var post = await _context.Posts
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(post);
        //}

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _unitOfWork.PostRepository.Get(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Posts == null)
        //    {
        //        return Problem("Entity set 'WatchStoreDbContext.Posts'  is null.");
        //    }
        //    var post = await _context.Posts.FindAsync(id);
        //    if (post != null)
        //    {
        //        _context.Posts.Remove(post);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context.Categories == null)
            //{
            //    return Problem("Entity set 'WatchStoreDbContext.Categories'  is null.");
            //}
            var post = _unitOfWork.PostRepository.Get(id);
            if (post != null)
            {
                _unitOfWork.PostRepository.Delete(post);
            }
            else
            {
                StatusMessage = $"Không xóa được bài viết: {post.Id}";
                return View(post);
            }
            await _unitOfWork.SaveChangeAsync();
            StatusMessage = $"Đã xóa danh mục: {post.Id}";
            return RedirectToAction(nameof(Index));
        }
    }
}
