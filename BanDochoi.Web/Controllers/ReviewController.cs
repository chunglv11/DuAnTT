using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BanDochoi.Web.Infrastructures;
using BanDochoi.Web.Models;

namespace BanDochoi.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReviewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index([Bind("Id, Vote, Comment, CreateDate, FullName, ProductId")] Review review)
        {
            //if (ModelState.IsValid)
            //{
            review.CreatedDate = DateTime.Now;
            _unitOfWork.WatchStoreDbContext.Reviews.Add(review);
            await _unitOfWork.SaveChangeAsync();
            return Ok();
        }
    }
}
