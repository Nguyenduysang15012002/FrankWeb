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
        public HomeController(
            IProductService ProductService, ILog Ilog,
            IAttribute_ProductService AttributeService,
              //  //IDM_DulieuDanhmucService dM_DulieuDanhmucService,
              IUserService UserService,
              IMapper mapper,
              IShopCartService shopCartService
              )
        {
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            _userService = UserService;
            _attribute_ProductService = AttributeService;
            _shopCartService = shopCartService;
        }

        public ActionResult Trangchu(long? Id)
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
            }
            else
            {
                ViewBag.Id = null;
                ViewBag.Name = null;
            }

            var listData = _productService.GetDaTaByPage(null);
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
    }
}