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
using Frank.Service.Order_DetailService;
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
        private readonly IOrder_DetailService _order_DetailService;
        public HomeController(
            IProductService ProductService, ILog Ilog,
            IAttribute_ProductService AttributeService,
              //  //IDM_DulieuDanhmucService dM_DulieuDanhmucService,
              IUserService UserService,
              IMapper mapper,
              IShopCartService shopCartService,
              IOrderService orderService,
              IOrder_DetailService order_DetailService

              )
        {
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            _userService = UserService;
            _attribute_ProductService = AttributeService;
            _shopCartService = shopCartService;
            _orderService = orderService;
            _order_DetailService = order_DetailService;

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
                    if(listOrder.Count() < 10)
                    {
                        ViewBag.Order = listOrder.Count();
                    }
                    else
                    {
                        ViewBag.Order1 = listOrder.Count();
                    }
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
            int pageSizeValue = pageSize ?? 16;
            var listData = _productService.GetDaTaByPage();
            var productDtoPagedList = listData.ToPagedList(pageNumber, pageSizeValue);
            return View(productDtoPagedList);
        }


        public ActionResult GioHang(long Id, int? page, int? pageSize)
        {
            ViewBag.Id = Id;
            var user = _userService.FindBy(x => x.Id == Id).FirstOrDefault();
            ViewBag.Name = user?.FullName;
            int pageNumber = page ?? 1;
            int pageSizeValue = pageSize ?? 100;
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
            int pageSizeValue = pageSize ?? 10;          
            ViewBag.PageSize = pageSize;
            var listOrder = _orderService.GetListByIdUser(Id);
            var orderDtoPagedList = listOrder.ToPagedList(pageNumber, pageSizeValue);
            return View(orderDtoPagedList);
        }
        public ActionResult Detail_DonHang(long User_Id,long Order_Id)
        {
            ViewBag.Id = User_Id;
            var user = _userService.FindBy(x => x.Id == User_Id).FirstOrDefault();
            ViewBag.Name = user?.FullName;
            var model = _orderService.GetByUserAndOrder_Id(User_Id, Order_Id);
            return View(model);
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
                //var listOrder = _orderService.GetListByIdUser((long)Id);
                //if (listOrder != null)
                //{
                //    ViewBag.Order = listOrder.Count();
                //}
                //else
                //{
                //    ViewBag.Order = 0;
                //}
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
                //var listOrder = _orderService.GetListByIdUser((long)Id);
                //if (listOrder != null)
                //{
                //    ViewBag.Order = listOrder.Count();
                //}
                //else
                //{
                //    ViewBag.Order = 0;
                //}
            }
            else
            {
                ViewBag.Id = null;
                ViewBag.Name = null;
            }
            return View();
        }
        public ActionResult Order(long User_Id)
        {
            ViewBag.Id = User_Id;
            var user = _userService.FindBy(x => x.Id == User_Id).FirstOrDefault();
            ViewBag.Name = user?.FullName;
            var model = _shopCartService.GetListByIdUser(User_Id);
            return View(model);
        }
        [HttpPost]
        public JsonResult Order(string Namecustomer, string Phone, string Address, long Tongtien, long User_Id)
        {
            try
            {
                var order = new Order();
                order.Processing_Status = 1;
                order.RecievePhone = Phone;
                order.RecieveAddress = Address;
                order.RecieveName = Namecustomer;
                order.TotalPrice = Tongtien;
                order.User_Id = User_Id;
                _orderService.Create(order);
                var shopcart = _shopCartService.GetListByIdUser(User_Id);
                if(shopcart != null)
                {
                    foreach(var shop in shopcart)
                    {
                        var order_detail = new Order_Detail();
                        order_detail.Price = shop.Price;
                        order_detail.Quantity = (int)shop.Quantity;
                        order_detail.Order_Id = order.Id;
                        order_detail.Product_Id = shop.Product_Id;
                        _order_DetailService.Create(order_detail);
                        var product = _productService.FindBy(x => x.Id == shop.Product_Id).FirstOrDefault();
                        if(product != null)
                        {
                            product.Quantity = product.Quantity - shop.Quantity;
                        }
                    }
                }
                var shopcartdelete = _shopCartService.GetAll().Where(x=>x.User_Id == User_Id);
                _shopCartService.DeleteRange(shopcartdelete);
                return Json(new { success = true, message = "Đặt hàng thành công." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult DeleteShopcart(long User_Id, long Product_Id)
        {
            var shopcart = _shopCartService.FindBy(x => x.User_Id == User_Id && x.Product_Id == Product_Id).FirstOrDefault();
            if (shopcart != null)
            {
                _shopCartService.Delete(shopcart);
                return Json(new { success = true, message = "Xóa sản phẩm khỏi giỏ hàng thành công." });
            }
            else
            {
                return Json(new { success = true, message = "Xóa sản phẩm khỏi giỏ hàng thất bại!" });
            }
        }
    }
}