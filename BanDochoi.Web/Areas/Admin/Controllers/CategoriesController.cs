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
using BanDochoi.Web.Repositories.Repository;

namespace BanDochoi.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Categories/[action]")]
    public class CategoriesController : Controller
    {
        //private readonly WatchStoreDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public CategoriesController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        //public CategoriesController(WatchStoreDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Admin/Categories
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //return _context.Categories != null ? 
            //            View(await _context.Categories.ToListAsync()) :
            //            Problem("Entity set 'WatchStoreDbContext.Categories'  is null.");
            var list = _unitOfWork.CategoryRepository.GetAll();
            return View(list);
        }

        // GET: Admin/Categories/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Categories == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _context.Categories
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name");
            return View();
        }

        [TempData]
        public string StatusMessage { get; set; }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,ParentCategoryId")] Category category)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(category);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                category.CreatedBy = _userManager.GetUserName(User);
                category.CreatedDate = DateTime.Now;
                _unitOfWork.CategoryRepository.Add(category);
                await _unitOfWork.SaveChangeAsync();
                StatusMessage = $"Đã thêm thành công danh mục: {category.Id}";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name");
            StatusMessage = $"Không thể thêm danh mục: {category.Id}";
            return View(category);
        }

        //GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _unitOfWork.CategoryRepository.Get(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name", category.ParentCategoryId);
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreatedDate,CreatedBy,ParentCategoryId")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                category.ModifiedDate = DateTime.Now;
                category.ModifiedBy = _userManager.GetUserName(User);
                _unitOfWork.CategoryRepository.Update(category);
                await _unitOfWork.SaveChangeAsync();
                StatusMessage = $"Đã cập nhập danh mục: {category.Id}";
                return RedirectToAction(nameof(Index));
            }
            StatusMessage = $"Cập nhập không thành công danh mục: {category.Id}";
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _unitOfWork.CategoryRepository.Get(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context.Categories == null)
            //{
            //    return Problem("Entity set 'WatchStoreDbContext.Categories'  is null.");
            //}
            var category = _unitOfWork.CategoryRepository.Get(id);
            if (category != null)
            {
                var list1 = _unitOfWork.WatchStoreDbContext.Products.Where(c => c.CategoryId == id).ToList();
                foreach (var p in list1)
                {
                    p.CategoryId = null;
                }
                var list = _unitOfWork.WatchStoreDbContext.Categories.Where(c => c.ParentCategoryId == id).ToList();
                foreach (var c in list)
                {
                    c.ParentCategoryId = null;
                }
                _unitOfWork.CategoryRepository.Delete(category);
            }
            else
            {
                StatusMessage = $"Không xóa được danh mục: {category.Id}";
                return View(category);
            }
            await _unitOfWork.SaveChangeAsync();
            StatusMessage = $"Đã xóa danh mục: {category.Id}";
            return RedirectToAction(nameof(Index));
        }

        //private bool CategoryExists(int id)
        //{
        //  return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
