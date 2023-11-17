using Microsoft.AspNetCore.Mvc;
using BanDochoi.Web.Infrastructures;
using BanDochoi.Web.Services;
using X.PagedList;

namespace BanDochoi.Web.Controllers
{
    public class ViewPostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CartService _cartService;
        private readonly IEmailSender _emailSender;
        public ViewPostController(IUnitOfWork unitOfWork, CartService cartService, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _cartService = cartService;
            _emailSender = emailSender;
        }
        public IActionResult Index(int? page)
        {
            page = page < 1 ? 1 : page;
            var list = _unitOfWork.WatchStoreDbContext.Posts.AsQueryable().ToList();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult ViewPostDetail(int id)
        {
            var post = _unitOfWork.WatchStoreDbContext.Posts.Where(p => p.Id == id).FirstOrDefault();
            return View(post);
        }
        public IActionResult ViewIntroduce()
        {
            var post = _unitOfWork.WatchStoreDbContext.Posts.Where(p => p.Title == "Chào mừng quý khách hàng đã đến với WatchStore.vn!").FirstOrDefault();
            return View(post);
        }
    }
}
