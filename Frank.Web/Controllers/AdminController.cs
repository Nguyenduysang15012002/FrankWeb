using AutoMapper;
using Frank.Repository.ProductRepository;
using Frank.Repository;
using Frank.Service.Attribute_ProductService;
using Frank.Service.Order_AddressService;
using Frank.Service.OrderService;
using Frank.Service.ProductService;
using Frank.Service.ShopCartService;
using Frank.Service.UserService;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frank.Web.Controllers
{
    public class AdminController : Controller
    {
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
        public AdminController(
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
        // GET: Admin
        public ActionResult Index(long? Id)
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
            return View();
        }
    }
}