using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Text.Encodings.Web;
using BanDochoi.Web.Data;
using BanDochoi.Web.Infrastructures;
using BanDochoi.Web.Models;
using BanDochoi.Web.Models.Enums;
using BanDochoi.Web.Services;
using X.PagedList;

namespace BanDochoi.Web.Controllers
{
    public class ViewProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CartService _cartService;
        private readonly IEmailSender _emailSender;
        private readonly IVnPayService _vnPayService;
        public ViewProductController(IUnitOfWork unitOfWork, CartService cartService, IEmailSender emailSender, IVnPayService vnPayService)
        {
            _unitOfWork = unitOfWork;
            _cartService = cartService;
            _emailSender = emailSender;
            _vnPayService = vnPayService;
        }
        public IActionResult Index(int? id)
        {
            var product = _unitOfWork.BanDoChoiDbContext.Products.Where(p => p.Id == id).Include(p => p.ProductImages).Include(p => p.Category).Include(p => p.Reviews).FirstOrDefault();
            ViewBag.relatedProduct = _unitOfWork.BanDoChoiDbContext.Products.Where(p => p.CategoryId == product.CategoryId).Include(p => p.Category).Include(p => p.ProductImages).Take(4).ToList();
            return View(product);
        }


        [Route("addcart/{productid:int}", Name = "addcart")]
        public IActionResult AddToCart([FromRoute] int productid)
        {

            var product = _unitOfWork.BanDoChoiDbContext.Products
                .Where(p => p.Id == productid)
                .FirstOrDefault();
            //int id = 2;
            if (product == null)
                return NotFound("Không có sản phẩm");
            // Xử lý đưa vào Cart ...
            var cart = _cartService.GetCartItems();
            var cartitem = cart.Find(p => p.Product.Id == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.Quantity++;
            }
            else
            {
                var image = _unitOfWork.BanDoChoiDbContext.ProductImages.Where(pi => pi.ProductId == productid).FirstOrDefault();
                if (image == null)
                {
                    cart.Add(new CartItem() { Quantity = 1, Product = product, Image = "/contents/noimg.jpg" });
                }
                else
                {
                    cart.Add(new CartItem() { Quantity = 1, Product = product, Image = image.FileName });

                }
                //  Thêm mới
            }

            // Lưu cart vào Session
            _cartService.SaveCartSession(cart);
            StatusMessage = "Đã thêm sản phẩm vào giỏ hàng";
            // Chuyển đến trang hiện thị Cart
            return RedirectToAction(nameof(Cart));
        }
        [TempData]
        public string StatusMessage { get; set; }
        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View(_cartService.GetCartItems());
        }
        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int productid)
        {
            var cart = _cartService.GetCartItems();
            var cartitem = cart.Find(p => p.Product.Id == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cart.Remove(cartitem);
            }

            _cartService.SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }
        /// Cập nhật
        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        [HttpPost]
        public IActionResult UpdateCart([FromForm] int productid, [FromForm] int quantity)
        {
            var cart = _cartService.GetCartItems();
            var cartitem = cart.Find(p => p.Product.Id == productid);

            if (cartitem != null)
            {
                if (quantity <= 0)
                {
                    // Kiểm tra nếu số lượng là không hợp lệ
                    return Json(new { success = false, message = "Số lượng không hợp lệ." });
                }

                if (quantity > cartitem.Product.Quantity)
                {
                    // Nếu số lượng cập nhật vượt quá số lượng tồn kho của sản phẩm
                    cartitem.Quantity = cartitem.Product.Quantity;

                    // Trả về JSON object với thông báo lỗi
                    return Json(new { success = false, message = "Số lượng cập nhật vượt quá số lượng tồn kho của sản phẩm." });
                }
                else
                {
                    // Nếu mọi điều kiện đều hợp lệ, cập nhật số lượng
                    cartitem.Quantity = quantity;
                }
            }

            _cartService.SaveCartSession(cart);

            // Trả về JSON object với kết quả thành công
            return Json(new { success = true });
        }




        [Route("/checkout")]
        public IActionResult Checkout()
        {
            var huyen = _unitOfWork.BanDoChoiDbContext.Districts.AsQueryable().ToList();
            var thanhpho = _unitOfWork.BanDoChoiDbContext.Cities.AsQueryable().ToList();
            ViewBag.huyen = huyen;
            ViewBag.thanhpho = thanhpho;
            return View();
        }
        [HttpPost]
        [Route("/checkout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout([Bind("Id,FullName,Address,Email,DistrictId,PhoneNumber,PaymentMethod,OderDate,Note")] Order order)
        {
            try
            {
                var cart = _cartService.GetCartItems();
                decimal total = 0;
                cart.ForEach(x => total += x.Product.Price * x.Quantity);
                order.Total = total;
                order.OrderDate = DateTime.Now;
                order.Status = Status.Unprogressed;
                _unitOfWork.BanDoChoiDbContext.Orders.Add(order);
                await _unitOfWork.SaveChangeAsync();
                if (order.PaymentMethod == "COD")
                {
                    List<OrderDetail> orderDetails = new List<OrderDetail>();
                    cart.ForEach(x => orderDetails.Add(new OrderDetail()
                    {
                        OrderId = order.Id,
                        ProductId = x.Product.Id,
                        Quantity = x.Quantity,
                        Price = x.Product.Price
                    }));
                    foreach (var orderDetail in orderDetails)
                    {
                        _unitOfWork.BanDoChoiDbContext.OrderDetails.Add(orderDetail);
                    }
                    await _unitOfWork.SaveChangeAsync();
                    cart.ForEach(x =>
                    {
                        var sp = _unitOfWork.BanDoChoiDbContext.Products.Where(p => p.Id == x.Product.Id).FirstOrDefault();
                        sp.Quantity = sp.Quantity - x.Quantity;
                    });
                    await _unitOfWork.SaveChangeAsync();
                    _cartService.ClearCart();
                    return View("Success");
                }
                else
                {
                    var url = _vnPayService.CreatePaymentUrl(order, HttpContext);
                    await _unitOfWork.SaveChangeAsync();
                    List<OrderDetail> orderDetails = new List<OrderDetail>();
                    cart.ForEach(x => orderDetails.Add(new OrderDetail()
                    {
                        OrderId = order.Id,
                        ProductId = x.Product.Id,
                        Quantity = x.Quantity,
                        Price = x.Product.Price
                    }));
                    foreach (var orderDetail in orderDetails)
                    {
                        _unitOfWork.BanDoChoiDbContext.OrderDetails.Add(orderDetail);
                    }
                    await _unitOfWork.SaveChangeAsync();
                    cart.ForEach(x =>
                    {
                        var sp = _unitOfWork.BanDoChoiDbContext.Products.Where(p => p.Id == x.Product.Id).FirstOrDefault();
                        sp.Quantity = sp.Quantity - x.Quantity;
                    });
                    await _unitOfWork.SaveChangeAsync();
                    return Redirect(url);
                }
            }
            catch
            {
                return View("Checkout");
            }
        }
        public IActionResult PaymentCallback()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);

            if (response.FullName != "falsefalse")
            {
                return RedirectToAction("Checkout");
            }
            _cartService.ClearCart();
            return RedirectToAction("Success");
        }

        public IActionResult loadHuyen(int tinhid)
        {
            return Json(
                _unitOfWork.BanDoChoiDbContext.Districts.Where(h => h.CityId == tinhid).Select(h => new
                {
                    id = h.Id,
                    name = h.Name
                }).ToList()
            );
        }

        public IActionResult GetProductByCategory(int? page, int categoryId, string sort)
        {
            page = page < 1 ? 1 : page;
            ViewBag.category = _unitOfWork.BanDoChoiDbContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            var list = _unitOfWork.BanDoChoiDbContext.Products.Include(p => p.ProductImages).Include(p => p.Category).AsQueryable();
            var cateParent = _unitOfWork.BanDoChoiDbContext.Categories.Where(c => c.Id == categoryId && c.ParentCategoryId == null).FirstOrDefault();
            if (cateParent == null)
            {
                list = list.Where(p => p.CategoryId == categoryId);
                if (sort == "asc")
                {
                    ViewBag.sort = "asc";
                    list = list.OrderBy(p => p.Price);
                }
                else if (sort == "desc")
                {
                    ViewBag.sort = "desc";
                    list = list.OrderByDescending(p => p.Price);
                }
                else
                {
                    ViewBag.sort = "";
                }
                var result = list.ToList();
                int pageSize = 9;
                int pageNumber = (page ?? 1);
                return View(result.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var cateChildren = _unitOfWork.BanDoChoiDbContext.Categories.Where(c => c.ParentCategoryId == categoryId).AsQueryable();
                var result = (from p in list
                              join c in cateChildren on p.CategoryId equals c.Id
                              select p).AsQueryable();

                if (sort == "asc")
                {
                    ViewBag.sort = "asc";
                    result = result.OrderBy(p => p.Price);
                }
                else if (sort == "desc")
                {
                    ViewBag.sort = "desc";
                    result = result.OrderByDescending(p => p.Price);
                }
                else
                {
                    ViewBag.sort = "";
                }
                //result = result.ToList();
                int pageSize = 9;
                int pageNumber = (page ?? 1);
                return View(result.ToPagedList(pageNumber, pageSize));
            }
        }

        public IActionResult Search(int? page, string textSearch, string sort)
        {
            page = page < 1 ? 1 : page;
            //ViewBag.category = _unitOfWork.BanDoChoiDbContext.Categories.Where(c => c.Name.Contains(textSearch)).FirstOrDefault();
            var list = _unitOfWork.BanDoChoiDbContext.Products.Include(p => p.ProductImages).Include(p => p.Category).AsQueryable();
            list = list.Where(p => p.ProductName.Contains(textSearch));
            if (sort == "asc")
            {
                ViewBag.sort = "asc";
                list = list.OrderBy(p => p.Price);
            }
            else if (sort == "desc")
            {
                ViewBag.sort = "desc";
                list = list.OrderByDescending(p => p.Price);
            }
            else
            {
                ViewBag.sort = "";
            }
            ViewBag.textSearch = textSearch;
            var result = list.ToList();
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(result.ToPagedList(pageNumber, pageSize));
        }

        public JsonResult ListName(string q)
        {
            var list = _unitOfWork.BanDoChoiDbContext.Products.Where(p => p.ProductName.Contains(q)).Select(p => p.ProductName).ToList();
            return Json(
                new
                {
                    data = list,
                    status = true
                }
            );
        }
        public IActionResult SortProductsAsc(int categoryId)
        {
            return Json(
                _unitOfWork.BanDoChoiDbContext.Products.Where(p => p.CategoryId == categoryId).Include(p => p.ProductImages).OrderBy(p => p.Price).Select(p => new
                {
                    id = p.Id,
                    name = p.ProductName,
                    price = p.Price,
                    category = p.Category.Name,
                    productimage = p.ProductImages.FirstOrDefault().FileName
                }).Skip(0).Take(3).ToList()
            );
        }


        public IActionResult SortProductsDesc(int categoryId)
        {
            return Json(
                _unitOfWork.BanDoChoiDbContext.Products.Where(p => p.CategoryId == categoryId).Include(p => p.ProductImages).OrderByDescending(p => p.Price).Select(p => new
                {
                    id = p.Id,
                    name = p.ProductName,
                    price = p.Price,
                    category = p.Category.Name,
                    productimage = p.ProductImages.FirstOrDefault().FileName
                }).ToList()
            );
        }

        public IActionResult ViewAllProduct(int? page, string sort)
        {
            page = page < 1 ? 1 : page;
            var list = _unitOfWork.BanDoChoiDbContext.Products.Include(p => p.ProductImages).Include(p => p.Category).AsQueryable();
            list = list.OrderBy(p => p.CreatedDate);
            if (sort == "asc")
            {
                ViewBag.sort = "asc";
                list = list.OrderBy(p => p.Price);
            }
            else if (sort == "desc")
            {
                ViewBag.sort = "desc";
                list = list.OrderByDescending(p => p.Price);
            }
            else
            {
                ViewBag.sort = "";
            }
            var result = list.ToList();
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(result.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Success()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ListComment(int id, int sotrang = 1)
        {
            var product = _unitOfWork.BanDoChoiDbContext.Products.Where(e => e.Id == id)
                            .Include(p => p.Reviews)
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

            var listphotos = product.Reviews.OrderByDescending(photo => photo.CreatedDate).Select(photo => new
            {
                id = photo.Id,
                comment = photo.Comment,
                fullname = photo.FullName,
                vote = photo.Vote,
                createddate = String.Format("{0:dd/MM/yyyy}", photo.CreatedDate),
            }).Take(3 * sotrang);


            return Json(
                new
                {
                    success = 1,
                    photos = listphotos
                }
            );
        }

        [HttpPost]
        public ActionResult SendComment([Bind("Id, Vote, Comment, FullName, PhoneNumber, ProductId")] Review emp)
        {
            emp.CreatedDate = DateTime.Now;
            _unitOfWork.BanDoChoiDbContext.Reviews.Add(emp);
            _unitOfWork.BanDoChoiDbContext.SaveChanges();
            return Json(new
            {
                result = true
            });
        }
    }
}

//_unitOfWork.BanDoChoiDbContext.Products.Where(p => p.CategoryId == categoryId).Join(_unitOfWork.BanDoChoiDbContext.ProductImages, product => product.Id, image => image.ProductId, (product, image) => new
//{
//    id = product.Id,
//    name = product.ProductName,
//    price = product.Price,
//    image = image.FileName.FirstOrDefault(),
//    category = product.Category.Name,
//}).OrderBy(p => p.price).Select(p => new
//{
//    id = p.id,
//    name = p.name,
//    price = p.price,
//    category = p.category,
//    productimage = p.image
//}).ToList()
