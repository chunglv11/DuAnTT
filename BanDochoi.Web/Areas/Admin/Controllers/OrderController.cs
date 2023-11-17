using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BanDochoi.Web.Areas.Admin.Models.Order;
using BanDochoi.Web.Infrastructures;
using BanDochoi.Web.Models;
using BanDochoi.Web.Models.Enums;

namespace BanDochoi.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Order/[action]")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        public OrderController(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            var list = _unitOfWork.WatchStoreDbContext.Orders.Where(o => o.Status == BanDochoi.Web.Models.Enums.Status.Confirmed).Include(p => p.OrderDetails).Include(p => p.District).ToList();
            ViewData["thanhpho"] = _unitOfWork.WatchStoreDbContext.Cities.ToList();
            ViewData["sanpham"] = _unitOfWork.WatchStoreDbContext.Products.ToList();
            return View(list);
        }

        public IActionResult OrderStatusUnprogressed()
        {
            var list = _unitOfWork.WatchStoreDbContext.Orders.Where(o => o.Status == BanDochoi.Web.Models.Enums.Status.Unprogressed).Include(p => p.OrderDetails).Include(p => p.District).ToList();
            ViewData["thanhpho"] = _unitOfWork.WatchStoreDbContext.Cities.ToList();
            ViewData["sanpham"] = _unitOfWork.WatchStoreDbContext.Products.ToList();
            return View(list);
        }
        public IActionResult OrderStatusCanceledShipping()
        {
            var list = _unitOfWork.WatchStoreDbContext.Orders.Where(o => o.Status == BanDochoi.Web.Models.Enums.Status.Shipping).Include(p => p.OrderDetails).Include(p => p.District).ToList();
            ViewData["thanhpho"] = _unitOfWork.WatchStoreDbContext.Cities.ToList();
            ViewData["sanpham"] = _unitOfWork.WatchStoreDbContext.Products.ToList();
            return View(list);
        }

        public IActionResult OrderStatusCanceled()
        {
            var list = _unitOfWork.WatchStoreDbContext.Orders.Where(o => o.Status == BanDochoi.Web.Models.Enums.Status.Canceled).Include(p => p.OrderDetails).Include(p => p.District).ToList();
            ViewData["thanhpho"] = _unitOfWork.WatchStoreDbContext.Cities.ToList();
            ViewData["sanpham"] = _unitOfWork.WatchStoreDbContext.Products.ToList();
            return View(list);
        }

        public IActionResult OrderStatusSuccess()
        {
            var list = _unitOfWork.WatchStoreDbContext.Orders.Where(o => o.Status == BanDochoi.Web.Models.Enums.Status.Success).Include(p => p.OrderDetails).Include(p => p.District).ToList();
            ViewData["thanhpho"] = _unitOfWork.WatchStoreDbContext.Cities.ToList();
            ViewData["sanpham"] = _unitOfWork.WatchStoreDbContext.Products.ToList();
            return View(list);
        }

        public async Task<IActionResult> HandleOrderStatusUnprogressed(int? id)
        {
            if (id == null || _unitOfWork.WatchStoreDbContext.Orders == null)
            {
                return NotFound();
            }

            var order = _unitOfWork.WatchStoreDbContext.Orders.Where(o => o.Id == id).Include(o => o.District).Include(o => o.OrderDetails).FirstOrDefault();
            if (order == null)
            {
                return NotFound();
            }
            ViewData["thanhpho"] = _unitOfWork.WatchStoreDbContext.Cities.ToList();
            ViewData["sanpham"] = _unitOfWork.WatchStoreDbContext.Products.ToList();
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HandleOrderStatusUnprogressed(int id, [Bind("DeliveryDate")] OrderModel order)
        {
            var data = _unitOfWork.WatchStoreDbContext.Orders.Where(o => o.Id == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                order.Status = BanDochoi.Web.Models.Enums.Status.Confirmed;
                data.Status = order.Status;
                data.DeliveryDate = order.DeliveryDate;
                _unitOfWork.WatchStoreDbContext.Orders.Update(data);
                var cart = _unitOfWork.WatchStoreDbContext.OrderDetails.Where(od => od.OrderId == id).ToList();
                string table = null;
                cart.ForEach(x => table += $"<tr><td>{_unitOfWork.ProductRepository.Get(x.ProductId).ProductName}</td><td>{x.Quantity}</td><td>{_unitOfWork.ProductRepository.Get(x.ProductId).Price}</td></tr>");
                await _emailSender.SendEmailAsync(data.Email,
                                    "Xác nhận địa chỉ mua hàng",
                                    $@"Bạn vừa đặt mua sản phẩm từ Watch Store. Thông tin mua hàng bao gồm:
                    <p>Họ tên: {data.FullName}</p>
                    <p>Email: {data.Email}</p>
                    <p>Địa chỉ: {data.Address}</p>
                    <p>Số điện thoại: {data.PhoneNumber}</p>
                    <p>Các sản phẩm mua:</p>
                    <table border=""1"">
                        <thead>
                            <tr>
                                <th>
                                    Tên sản phẩm
                                </th>
                                <th>
                                    Số lượng
                                </th>
                                <th>
                                    Giá bán
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                    "
                                     + table + "</tbody> </table>" +
                                     $"Thành tiền: {data.Total}" +
                                     "<p>Hãy kiểm tra lại đơn hàng. Nếu có bất kỳ vấn đề gì xin liên hệ số: 0393220048</p>"
                                    );
                await _unitOfWork.SaveChangeAsync();
                StatusMessage = $"Đã xử lý đơn hàng: {data.Id}";
                return RedirectToAction(nameof(OrderStatusUnprogressed));
            }
            StatusMessage = $"Xử lý đơn hàng {data.Id} không thành công !";
            return RedirectToAction(nameof(OrderStatusUnprogressed));
        }



        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.WatchStoreDbContext.Orders == null)
            {
                return NotFound();
            }

            var order = _unitOfWork.WatchStoreDbContext.Orders.Where(o => o.Id == id).Include(o => o.District).Include(o => o.OrderDetails).FirstOrDefault();
            if (order == null)
            {
                return NotFound();
            }
            ViewData["thanhpho"] = _unitOfWork.WatchStoreDbContext.Cities.ToList();
            ViewData["sanpham"] = _unitOfWork.WatchStoreDbContext.Products.ToList();
            return View(order);
        }
        public async Task<IActionResult> HandleOrderStatus(int? id)
        {
            if (id == null || _unitOfWork.WatchStoreDbContext.Orders == null)
            {
                return NotFound();
            }

            var order = _unitOfWork.WatchStoreDbContext.Orders.Where(o => o.Id == id).Include(o => o.District).Include(o => o.OrderDetails).FirstOrDefault();
            if (order == null)
            {
                return NotFound();
            }
            ViewData["thanhpho"] = _unitOfWork.WatchStoreDbContext.Cities.ToList();
            ViewData["sanpham"] = _unitOfWork.WatchStoreDbContext.Products.ToList();
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HandleOrderStatus(int id, [Bind("Status, DeliveryDate")] OrderModel order)
        {
            var data = _unitOfWork.WatchStoreDbContext.Orders.Where(o => o.Id == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                //order.Status = BanDochoi.Web.Models.Enums.Status.Confirmed;
                data.Status = order.Status;
                data.DeliveryDate = order.DeliveryDate;
                _unitOfWork.WatchStoreDbContext.Orders.Update(data);
                await _unitOfWork.SaveChangeAsync();
                StatusMessage = $"Đã xử lý đơn hàng: {data.Id}";
                return RedirectToAction(nameof(Index));
            }
            StatusMessage = $"Xử lý đơn hàng {data.Id} không thành công !";
            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _unitOfWork.WatchStoreDbContext.Orders == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = _unitOfWork.WatchStoreDbContext.Orders.Where(o => o.Id == id).Include(o => o.District).Include(o => o.OrderDetails).FirstOrDefault();
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(order);
        //}


        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var order = _unitOfWork.WatchStoreDbContext.Orders.Where(o => o.Id == id).Include(o => o.District).Include(o => o.OrderDetails).FirstOrDefault();

        //    if (order != null)
        //    {
        //        _unitOfWork.WatchStoreDbContext.Orders.Remove(order);
        //    }
        //    else
        //    {
        //        StatusMessage = $"Không xóa được đơn hàng: {order.Id}";
        //        return View(order);
        //    }
        //    await _unitOfWork.SaveChangeAsync();
        //    StatusMessage = $"Đã xóa được đơn hàng: {order.Id}";
        //    return RedirectToAction(nameof(Index));
        //}
    }
}