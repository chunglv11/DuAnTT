﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BanDochoi.Web.Areas.Identity.Data;
using BanDochoi.Web.Infrastructures;

namespace BanDochoi.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Home/[action]")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            int order = _unitOfWork.BanDoChoiDbContext.Orders.Count();
            int user = _unitOfWork.BanDoChoiDbContext.Users.Count();
            ViewBag.OrderCount = order;
            ViewBag.UserCount = user;
            int quantity = _unitOfWork.BanDoChoiDbContext.Products.Sum(x => x.Quantity);

            var temp = _unitOfWork.BanDoChoiDbContext.Orders.Where(p => p.OrderDate.Month == DateTime.Now.Month && p.Status == BanDochoi.Web.Models.Enums.Status.Success).Sum(s => s.Total);
            ViewBag.DoanhThu = temp.ToString("#,##0") + " VND";
            return View();
        }
        public IActionResult ThongKe()
        {
            string[] dateX = new string[12];
            string[] data = new string[12];
            for (int i = 0; i < 12; i++)
            {

                dateX[i] = $"Tháng {i + 1}";
                //var temp = db.Orders.Where(a => a.Orderdate.Value.Month == dateTimeNow.Month).Sum(s => s.Totalprice);
                var temp = _unitOfWork.BanDoChoiDbContext.Orders.Where(p => p.OrderDate.Month == i + 1 && p.Status == BanDochoi.Web.Models.Enums.Status.Success).Sum(s => s.Total);
                if (temp == null)
                {
                    temp = 0;
                }
                data[i] = temp.ToString();
            }
            ViewBag.dateX = dateX;
            ViewBag.data = data;
            return View();
        }
    }
}