using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
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
    [Route("/Admin/Products/[action]")]
    public class ProductsController : Controller
    {
        //private readonly BanDoChoiDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        //public ProductsController(BanDoChoiDbContext context)
        //{
        //    _context = context;
        //}
        public ProductsController(/*BanDoChoiDbContext context,*/ IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        // GET: Admin/Products
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var BanDoChoiDbContext = _context.Products.Include(p => p.Category);
            //return View(await BanDoChoiDbContext.ToListAsync());
            var list = _unitOfWork.BanDoChoiDbContext.Products.Include(p => p.Category);
            return View(list);
        }

        //GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.ProductRepository.GetAll() == null)
            {
                return NotFound();
            }

            var product = _unitOfWork.ProductRepository.Get(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [TempData]
        public string StatusMessage { get; set; }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Summary,Price,Quantity,Image,Description,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedDate = DateTime.Now;
                product.CreatedBy = _userManager.GetUserName(User);
                //_context.Add(product);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                _unitOfWork.ProductRepository.Add(product);
                await _unitOfWork.SaveChangeAsync();
                StatusMessage = $"Đã thêm thành công sản phẩm {product.Id}";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name");
            StatusMessage = $"Thêm sản phẩm {product.Id} thất bại";
            return View(product);
        }

        //GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _unitOfWork.ProductRepository.GetAll() == null)
            {
                return NotFound();
            }

            var product = _unitOfWork.ProductRepository.Get(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Summary,Price,Quantity,Image,Description,CategoryId,CreatedBy,CreatedDate")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //try
                //{
                //    //_context.Update(product);
                //    //await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!ProductExists(product.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                product.ModifiedDate = DateTime.Now;
                product.ModifiedBy = _userManager.GetUserName(User);
                _unitOfWork.ProductRepository.Update(product);
                await _unitOfWork.SaveChangeAsync();
                StatusMessage = $"Đã cập nhập sản phẩm: {product.Id}";
                return RedirectToAction(nameof(Index));
            }
            StatusMessage = $"Cập nhập thất bại sản phẩm: {product.Id}";
            ViewData["CategoryId"] = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _unitOfWork.ProductRepository.GetAll() == null)
            {
                return NotFound();
            }

            //var product = await _context.Products
            //    .Include(p => p.Category)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var product = _unitOfWork.ProductRepository.Get(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.ProductRepository.GetAll() == null)
            {
                return Problem("Entity set 'BanDoChoiDbContext.Products'  is null.");
            }
            var product = _unitOfWork.ProductRepository.Get(id);
            if (product != null)
            {
                _unitOfWork.ProductRepository.Delete(product);
                var listImage = _unitOfWork.BanDoChoiDbContext.ProductImages.Where(pi => pi.ProductId == id).ToList();
                foreach (var image in listImage)
                {
                    _unitOfWork.BanDoChoiDbContext.ProductImages.Remove(image);
                    var filename = "Uploads/Products/" + image.FileName;
                    System.IO.File.Delete(filename);
                }
            }
            else
            {
                StatusMessage = $"Không xóa được danh mục: {product.Id}";
                return View(product);
            }
            await _unitOfWork.SaveChangeAsync();
            StatusMessage = $"Đã xóa sản phẩm: {product.Id}";
            return RedirectToAction(nameof(Index));
        }

        //private bool ProductExists(int id)
        //{
        //  return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        //}


        public class UploadOneFile
        {
            [Required(ErrorMessage = "Phải chọn file upload")]
            [DataType(DataType.Upload)]
            [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
            [Display(Name = "Chọn file upload")]
            public IFormFile FileUpload { get; set; }
        }
        [HttpGet]
        public IActionResult UploadPhoto(int id)
        {
            var product = _unitOfWork.BanDoChoiDbContext.Products.Where(e => e.Id == id)
                            .Include(p => p.ProductImages)
                            .FirstOrDefault();
            if (product == null)
            {
                return NotFound("Không có sản phẩm");
            }
            ViewData["product"] = product;
            return View(new UploadOneFile());
        }

        [HttpPost, ActionName("UploadPhoto")]
        public async Task<IActionResult> UploadPhotoAsync(int id, [Bind("FileUpload")] UploadOneFile f)
        {
            var product = _unitOfWork.BanDoChoiDbContext.Products.Where(e => e.Id == id)
                            .Include(p => p.ProductImages)
                            .FirstOrDefault();

            if (product == null)
            {
                return NotFound("Không có sản phẩm");
            }
            ViewData["product"] = product;

            if (f != null)
            {
                var file1 = Path.GetFileNameWithoutExtension(Path.GetRandomFileName())
                            + Path.GetExtension(f.FileUpload.FileName);

                var file = Path.Combine("Uploads", "Products", file1);

                using (var filestream = new FileStream(file, FileMode.Create))
                {
                    await f.FileUpload.CopyToAsync(filestream);
                }

                _unitOfWork.BanDoChoiDbContext.ProductImages.Add(new ProductImage()
                {
                    ProductId = product.Id,
                    FileName = file1
                });

                await _unitOfWork.BanDoChoiDbContext.SaveChangesAsync();
            }


            return View(f);
        }

        [HttpPost]
        public IActionResult ListPhotos(int id)
        {
            var product = _unitOfWork.BanDoChoiDbContext.Products.Where(e => e.Id == id)
                            .Include(p => p.ProductImages)
                            .FirstOrDefault();

            if (product == null)
            {
                return Json(
                    new
                    {
                        success = 0,
                        message = "Product not found",
                    }
                );
            }

            var listphotos = product.ProductImages.Select(photo => new
            {
                id = photo.Id,
                path = "/contents/Products/" + photo.FileName
            });

            return Json(
                new
                {
                    success = 1,
                    photos = listphotos
                }
            );
        }

        [HttpPost]
        public IActionResult DeletePhoto(int id)
        {
            var photo = _unitOfWork.BanDoChoiDbContext.ProductImages.Where(e => e.Id == id).FirstOrDefault();
            if (photo != null)
            {
                _unitOfWork.BanDoChoiDbContext.ProductImages.Remove(photo);
                _unitOfWork.BanDoChoiDbContext.SaveChanges();

                var filename = "Uploads/Products/" + photo.FileName;
                System.IO.File.Delete(filename);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhotoApi(int id, [Bind("FileUpload")] UploadOneFile f)
        {
            var product = _unitOfWork.BanDoChoiDbContext.Products.Where(e => e.Id == id)
                .Include(p => p.ProductImages)
                .FirstOrDefault();

            if (product == null)
            {
                return NotFound("Không có sản phẩm");
            }


            if (f != null)
            {
                var file1 = Path.GetFileNameWithoutExtension(Path.GetRandomFileName())
                            + Path.GetExtension(f.FileUpload.FileName);

                var file = Path.Combine("Uploads", "Products", file1);

                using (var filestream = new FileStream(file, FileMode.Create))
                {
                    await f.FileUpload.CopyToAsync(filestream);
                }

                _unitOfWork.BanDoChoiDbContext.ProductImages.Add(new ProductImage()
                {
                    ProductId = product.Id,
                    FileName = file1
                });

                await _unitOfWork.BanDoChoiDbContext.SaveChangesAsync();
            }
            return Ok();
        }

    }
}
