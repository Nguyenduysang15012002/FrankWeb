using AutoMapper;
using Frank.Repository.ProductRepository;
using Frank.Repository;
using Frank.Service.ProductService;
using Frank.Service.UserService;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Frank.Web.Models.ProductModels;
using Frank.Service.ImageService;
using Frank.Service.Attribute_ProductService;
using Frank.Model.Entities;
using Frank.Service.ShopCartService;
using PagedList;
using Frank.Service.CategoryService;
namespace Frank.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _ProductRepository;
        private readonly ILog _ilog;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private readonly IAttribute_ProductService _attribute_ProductService;
        private readonly IShopCartService _shopCartService;
        private readonly ICategoryService _categoryService;
        public ProductController(
            IProductService ProductService,
            ILog Ilog,
            IMapper mapper,
            IUserService userService,
            IImageService imageService,
            IAttribute_ProductService attribute_ProductService,
            IShopCartService shopCartService,
            ICategoryService categoryService
              )
        {
            _userService = userService;
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            _imageService = imageService;
            _attribute_ProductService = attribute_ProductService;
            _shopCartService = shopCartService;
            _categoryService = categoryService;
        }
        // GET: Product
        public ActionResult Index(int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int pageSizeValue = pageSize ?? 5;
            var listSp = _productService.GetListProduct();
            var productDtoPagedList = listSp.ToPagedList(pageNumber, pageSizeValue);
            ViewBag.PageSize = pageSize;
            ViewBag.dropListCategory = _categoryService.GetDropDownList().OrderBy(x => x.Text).ToList();
            return View(productDtoPagedList);
        }

        public ActionResult Detail(long Id, long? User_Id)
        {
            if (User_Id != null)
            {
                ViewBag.Id = User_Id;
                var user = _userService.FindBy(x => x.Id == User_Id).FirstOrDefault();
                ViewBag.Name = user?.FullName;
            }
            else
            {
                ViewBag.Id = null;
                ViewBag.Name = null;
            }
            var model = new ProductDetailVM();
            model.Id = Id;
            model.Product = _productService.FindBy(x => x.Id == Id).FirstOrDefault();
            model.Images = _imageService.GetImageByProductId(Id);
            model.AttributeProducts = _attribute_ProductService.GetAttribute_ProductByProductId(Id);         
            return View(model);
        }
        [HttpPost]
        public JsonResult Create(long User_Id, long Product_Id, long Soluong)
        {
            try
            {
                if (User_Id != -1 && Product_Id != -1 && Soluong != -1)
                {
                    var checkuser = _shopCartService.FindBy(x => x.User_Id == User_Id && x.Product_Id == Product_Id).FirstOrDefault();
                    if (checkuser != null)
                    {
                        checkuser.User_Id = User_Id;
                        checkuser.Product_Id = Product_Id;
                        checkuser.Quantity = checkuser.Quantity + Soluong;
                        _shopCartService.Update(checkuser);
                        return Json(new { success = true, message = "Thêm vào giỏ hàng thành công." });
                    }

                    else
                    {
                        var shopcart = new ShopCart();
                        shopcart.User_Id = User_Id;
                        shopcart.Product_Id = Product_Id;
                        shopcart.Quantity = Soluong;
                        _shopCartService.Create(shopcart);
                        return Json(new { success = true, message = "Thêm vào giỏ hàng thành công." });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Thêm vào giỏ hàng thất bại." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}