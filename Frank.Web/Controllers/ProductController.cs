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
using Frank.Service.Common;
using System.IO;
using System.Web.Hosting;
using System.Data.Entity.Infrastructure;
using Frank.Service.ProductService.Dto;
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
            int pageSizeValue = pageSize ?? 20;
            var listSp = _productService.GetListProduct();
            
            var productDtoPagedList = listSp.ToPagedList(pageNumber, pageSizeValue);
            ViewBag.PageSize = pageSize;
            ViewBag.dropListCategory = _categoryService.GetDropDownList().OrderBy(x => x.Text).ToList();
            return View(productDtoPagedList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CreateSP(FormCollection form)
        {
            var result = new JsonResultBO(true, "Thêm sản phẩm thành công");
            try
            {
                var ProductName = form["ProductName"];
                var ProductQuantity = form["ProductQuantity"];
                var ProductPrice = form["ProductPrice"];
                var ProductBrand = form["ProductBrand"];
                var ProductYear = form["ProductYear"];
                var ExpiredYear = form["ExpiredYear"];
                var Description = form["Description"];
                var Danhmuc = form["Danhmuc"];

                var checkProduct = _productService.FindBy(x => x.Name == ProductName).FirstOrDefault();
                if (checkProduct != null)
                {
                    result.Status = false;
                    result.Message = "Đã có sản phẩm " + ProductName;
                }
                else
                {
                    var product = new Product();
                    product.Name = ProductName;
                    product.Brand = ProductBrand;
                    product.ExpiredYear = int.Parse(ExpiredYear);
                    product.Description = Description;
                    product.Quantity = long.Parse(ProductQuantity);
                    product.ProductionYear = int.Parse(ProductYear);
                    product.Category_Id = long.Parse(Danhmuc);
                    // Lưu product vào cơ sở dữ liệu trước khi lấy Id
                    _productService.Create(product);
                    var attribute = new Attribute_Product();
                    attribute.Price = int.Parse(ProductPrice);
                    attribute.Product_Id = product.Id;
                    _attribute_ProductService.Create(attribute);
                    // Lấy tệp đã tải lên từ form
                    var ProductImage = Request.Files["ProductImage"];
                    if (ProductImage != null && ProductImage.ContentLength > 0)
                    {
                        var images = new Image();
                        string fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ProductImage.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                        images.Url_Image = "/Images/" + fileName;
                        ProductImage.SaveAs(path);
                        images.Product_Id = product.Id;
                        _imageService.Create(images);
                    }
                }
            }
            catch (Exception ex)
            {
                result.MessageFail(ex.Message);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(long id)
        {
            var model = _productService.GetById(id);
            ViewBag.dropListCategory = _categoryService.GetDropDownList().OrderBy(x => x.Text).ToList();
            return View(model);
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public JsonResult EditSP(FormCollection form)
        {
            var result = new JsonResultBO(true, "Cập nhật sản phẩm thành công");
            try
            {
                var ProductName = form["ProductName"];
                var ProductQuantity = form["ProductQuantity"];
                var ProductPrice = form["ProductPrice"];
                var ProductBrand = form["ProductBrand"];
                var ProductYear = form["ProductYear"];
                var ExpiredYear = form["ExpiredYear"];
                var Description = form["Description"];
                var Danhmuc = form["Danhmuc"];
                var Id = form["Id"];
                var product = new Product();
                product.Id = long.Parse(Id);
                product.Name = ProductName;
                product.Brand = ProductBrand;
                product.ExpiredYear = int.Parse(ExpiredYear);
                product.Description = Description;
                product.Quantity = long.Parse(ProductQuantity);
                product.ProductionYear = int.Parse(ProductYear);
                product.Category_Id = long.Parse(Danhmuc);
                // Lưu product vào cơ sở dữ liệu trước khi lấy Id
                _productService.Update(product);
                var attribute = _attribute_ProductService.FindBy(x=>x.Product_Id == product.Id).FirstOrDefault();
                if (attribute != null)
                {                   
                    attribute.Price = int.Parse(ProductPrice);
                    attribute.Product_Id = product.Id;
                   _attribute_ProductService.Update(attribute);
                }
                // Lấy tệp đã tải lên từ form
                var ProductImage = Request.Files["ProductImage"];
                if (ProductImage != null && ProductImage.ContentLength > 0)
                {
                    var image = _imageService.FindBy(x=>x.Product_Id == product.Id).FirstOrDefault();
                    string fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ProductImage.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    ProductImage.SaveAs(path);
                    if (image != null)
                    {
                        image.Url_Image = "/Images/" + fileName;
                        image.Product_Id = product.Id;
                        _imageService.Update(image);
                    }               
                   
                }
            }
            catch (Exception ex)
            {
                result.MessageFail(ex.Message);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]       
        public JsonResult Delete(long Id)
        {
            try
            {
                var product = _productService.FindBy(x=>x.Id == Id).FirstOrDefault();
                if(product != null)
                {
                    var image = _imageService.FindBy(x=>x.Product_Id==Id).FirstOrDefault();
                    if (image != null)
                    {
                        _imageService.Delete(image);
                    }
                    var attribute = _attribute_ProductService.FindBy(x => x.Product_Id == Id).FirstOrDefault();
                    if (attribute != null)
                    {
                        _attribute_ProductService.Delete(attribute);
                    }
                    _productService.Delete(product);
                    return Json(new { success = true, message = "Xóa sản phẩm thành công." });
                }
                else
                {
                    return Json(new { success = false, message = "Xóa sản phẩm thất bại." });
                }
               

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }         
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
                    var checksp = _productService.FindBy(x => x.Id == Product_Id).FirstOrDefault();
                    if(checkuser != null && checksp != null)
                    {
                        var tong = checkuser.Quantity + Soluong;
                        if(tong > checksp.Quantity)
                        {
                            return Json(new { success = false, message = "Thêm vào giỏ hàng thất bại do số lượng sản phẩm trong giỏ hàng đã có và số lượng mua đã vượt quá mức số lượng còn của sản phẩm." });
                        }
                    }
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