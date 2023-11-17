using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using BanDochoi.Web.Infrastructures;
using BanDochoi.Web.Models;

namespace BanDochoi.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var products = _unitOfWork.WatchStoreDbContext.Products.Include(p => p.ProductImages).Include(p => p.Category).OrderBy(o => o.CreatedDate).Take(12);
            return View(products);
        }
    }
}