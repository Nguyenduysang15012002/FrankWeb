using AutoMapper;
using Frank.Repository.ProductRepository;
using Frank.Repository;
using Frank.Service.ProductService;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Frank.Service.UserService;
using Frank.Service.Attribute_ProductService;
using System.Threading.Tasks;
using Frank.Model.Entities;
using Frank.Service.ShopCartService;
using Frank.Service.ShopCartService.Dto;
using PagedList;
using PagedList.Mvc;
using System.Drawing.Printing;
using System.Web.UI;
using Frank.Service.OrderService.Dto;
using Frank.Service.Common;
using Frank.Web.Models.UserModels;
using Frank.Service.OrderService;
using Microsoft.Owin.BuilderProperties;
using Frank.Service.Order_AddressService;
namespace Frank.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: ProductArea/Product

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _ProductRepository;
        private readonly ILog _ilog;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IAttribute_ProductService _attribute_ProductService;
        private readonly IShopCartService _shopCartService;
        private readonly IOrderService _orderService;
        private readonly IOrder_AddressService _order_addressService;
        public HomeController(
            IProductService ProductService, ILog Ilog,
            IAttribute_ProductService AttributeService,
              //  //IDM_DulieuDanhmucService dM_DulieuDanhmucService,
              IUserService UserService,
              IMapper mapper,
              IShopCartService shopCartService,
              IOrderService orderService,
              IOrder_AddressService order_AddressService

              )
        {
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            _userService = UserService;
            _attribute_ProductService = AttributeService;
            _shopCartService = shopCartService;
            _orderService = orderService;
            _order_addressService = order_AddressService;
        }

        public ActionResult Trangchu(long? Id, int? page, int? pageSize)
        {
            if (Id != null)
            {
                ViewBag.Id = Id;
                var user = _userService.FindBy(x => x.Id == Id).FirstOrDefault();
                ViewBag.Name = user?.FullName;
                var listShopcart = _shopCartService.GetListByIdUser((long)Id);
                if (listShopcart != null)
                {
                    ViewBag.ThongBao = listShopcart.Count();
                }
                else
                {
                    ViewBag.ThongBao = 0;
                }
                var listOrder = _orderService.GetListByIdUser((long)Id);
                if (listOrder != null)
                {
                    ViewBag.Order = listOrder.Count();
                }
                else
                {
                    ViewBag.Order = 0;
                }
            }
            else
            {
                ViewBag.Id = null;
                ViewBag.Name = null;
            }
            int pageNumber = page ?? 1;
            int pageSizeValue = pageSize ?? 9;
            var listData = _productService.GetDaTaByPage();
            var productDtoPagedList = listData.ToPagedList(pageNumber, pageSizeValue);
            return View(productDtoPagedList);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult SearchData(long? Id)
        {
            if (Id != null)
            {
                ViewBag.Id = Id;
                var user = _userService.FindBy(x => x.Id == Id).FirstOrDefault();
                ViewBag.Name = user?.FullName;
                var listShopcart = _shopCartService.GetListByIdUser((long)Id);
                if (listShopcart != null)
                {
                    ViewBag.ThongBao = listShopcart.Count();
                }
                else
                {
                    ViewBag.ThongBao = 0;
                }
                var listOrder = _orderService.GetListByIdUser((long)Id);
                if (listOrder != null)
                {
                    ViewBag.Order = listOrder.Count();
                }
                else
                {
                    ViewBag.Order = 0;
                }
            }
            else
            {
                ViewBag.Id = null;
                ViewBag.Name = null;
            }

            var listData = _productService.GetDaTaByPage();
            return View(listData);
        }
        public ActionResult GioHang(long Id, int? page, int? pageSize)
        {
            ViewBag.Id = Id;
            var user = _userService.FindBy(x => x.Id == Id).FirstOrDefault();
            ViewBag.Name = user?.FullName;
            int pageNumber = page ?? 1;
            int pageSizeValue = pageSize ?? 5;
            var listShopcart = _shopCartService.GetListByIdUser(Id);
            // Lấy danh sách giỏ hàng dưới dạng List<ShopCartDto>
            var shopCartDtoPagedList = listShopcart.ToPagedList(pageNumber, pageSizeValue);
            ViewBag.PageSize = pageSize;
            return View(shopCartDtoPagedList);
        }
        public ActionResult DonHang(long Id, int? page, int? pageSize)
        {
            ViewBag.Id = Id;
            var user = _userService.FindBy(x => x.Id == Id).FirstOrDefault();
            ViewBag.Name = user?.FullName;
            int pageNumber = page ?? 1;
            int pageSizeValue = pageSize ?? 1;
            var listOrder = _orderService.GetListByIdUser((long)Id);
            // Lấy danh sách giỏ hàng dưới dạng List<ShopCartDto>
            var shopCartDtoPagedList = listOrder.ToPagedList(pageNumber, pageSizeValue);
            ViewBag.PageSize = pageSize;
            return View(shopCartDtoPagedList);
        }
        public ActionResult GioiThieu(long? Id)
        {

            if (Id != null)
            {
                ViewBag.Id = Id;
                var user = _userService.FindBy(x => x.Id == Id).FirstOrDefault();
                ViewBag.Name = user?.FullName;
                var listShopcart = _shopCartService.GetListByIdUser((long)Id);
                if (listShopcart != null)
                {
                    ViewBag.ThongBao = listShopcart.Count();
                }
                else
                {
                    ViewBag.ThongBao = 0;
                }
                var listOrder = _orderService.GetListByIdUser((long)Id);
                if (listOrder != null)
                {
                    ViewBag.Order = listOrder.Count();
                }
                else
                {
                    ViewBag.Order = 0;
                }
            }
            else
            {
                ViewBag.Id = null;
                ViewBag.Name = null;
            }
            return View();
        }
        public ActionResult Lienhe(long? Id)
        {

            if (Id != null)
            {
                ViewBag.Id = Id;
                var user = _userService.FindBy(x => x.Id == Id).FirstOrDefault();
                ViewBag.Name = user?.FullName;
                var listShopcart = _shopCartService.GetListByIdUser((long)Id);
                if (listShopcart != null)
                {
                    ViewBag.ThongBao = listShopcart.Count();
                }
                else
                {
                    ViewBag.ThongBao = 0;
                }
                var listOrder = _orderService.GetListByIdUser((long)Id);
                if (listOrder != null)
                {
                    ViewBag.Order = listOrder.Count();
                }
                else
                {
                    ViewBag.Order = 0;
                }
            }
            else
            {
                ViewBag.Id = null;
                ViewBag.Name = null;
            }
            return View();
        }
        public ActionResult Order(long? User_Id, long? Product_Id)
        {
            ViewBag.Id = User_Id;
            var user = _userService.FindBy(x => x.Id == User_Id).FirstOrDefault();
            ViewBag.Name = user?.FullName;
            ViewBag.ProductId = Product_Id;
            var model = _shopCartService.GetbyUserVsProductId(User_Id, Product_Id);
            var soluongcon = _productService.GetById(Product_Id);
            ViewBag.Soluongcon = (int)soluongcon.Quantity;
            return View(model);
        }
        [HttpPost]    
        public JsonResult Order(string Namecustomer, string Phone, string Address, long Soluong, long Tongtien, long User_Id, long Product_Id)
        {
            try
            {
                
                var product = _productService.FindBy(x => x.Id == Product_Id).FirstOrDefault();
                if (product != null)
                {
                    product.Quantity = product.Quantity - Soluong;
                    _productService.Update(product);
                }
                else
                {
                    return Json(new { success = false, message = "Lỗi sản phẩm!" });
                }
                if (Soluong != -1 && Tongtien != -1)
                {
                    var order = new Order();
                    order.Processing_Status = 1;
                    order.TotalPrice = Tongtien;
                    order.Quantity = Soluong;
                    order.User_Id = User_Id;
                    order.Product_Id = Product_Id;
                    _orderService.Create(order);
                }
                else
                {
                    return Json(new { success = false, message = "Lỗi đặt hàng!" });
                }
                if (Namecustomer != null && Phone != null && Address != null)
                {
                    var ordercheck = _orderService.FindBy(x => x.User_Id == User_Id && x.Product_Id == Product_Id).FirstOrDefault();
                    if (ordercheck != null)
                    {
                        var order_address = new Order_Address();
                        order_address.NameCustomer = Namecustomer;
                        order_address.Phone = Phone;
                        order_address.Address = Address;
                        order_address.Order_Id = ordercheck.Id;
                        _order_addressService.Create(order_address);
                    }
                    else
                    {
                        return Json(new { success = false, message = "Lỗi thêm địa chỉ!" });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Lỗi thêm địa chỉ!" });
                }
                var shopcart = _shopCartService.FindBy(x => x.User_Id == User_Id && x.Product_Id == Product_Id).FirstOrDefault();
                if (shopcart != null)
                {
                    _shopCartService.Delete(shopcart);
                }
                else
                {
                    return Json(new { success = false, message = "Lỗi giỏ hàng!" });
                }
                return Json(new { success = true, message = "Đặt hàng thành công." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}