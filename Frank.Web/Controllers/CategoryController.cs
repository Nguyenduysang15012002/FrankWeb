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
using Frank.Service.CategoryService;
using PagedList;
using Frank.Model.Entities;
using Frank.Service.Common;
using System.IO;

namespace Frank.Web.Controllers
{
    public class CategoryController : Controller
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
        private readonly ICategoryService _categoryService;
        public CategoryController(
            IProductService ProductService, ILog Ilog,
            IAttribute_ProductService AttributeService,
              //  //IDM_DulieuDanhmucService dM_DulieuDanhmucService,
              IUserService UserService,
              IMapper mapper,
              IShopCartService shopCartService,
              IOrderService orderService,
              ICategoryService categoryService
              )
        {
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            _userService = UserService;
            _attribute_ProductService = AttributeService;
            _shopCartService = shopCartService;
            _orderService = orderService;
            _categoryService = categoryService;
        }
        // GET: Category
        public ActionResult Index(int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int pageSizeValue = pageSize ?? 20;
            var listDM = _categoryService.GetAll().ToList();
            var categoryPagedList = listDM.ToPagedList(pageNumber, pageSizeValue);
            ViewBag.PageSize = pageSize;
            return View(categoryPagedList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(FormCollection form)
        {
            var result = new JsonResultBO(true, "Thêm danh mục thành công");
            try
            {
                var CategoryName = form["CategoryName"];
                var CategoryDesciption = form["CategoryDesciption"];

                var check = _categoryService.FindBy(x => x.CategoryName == CategoryName).FirstOrDefault();
                if (check != null)
                {
                    result.Status = false;
                    result.Message = "Đã có danh mục " + check.CategoryName;
                }
                else
                {
                    var category = new Category();
                    category.CategoryName = CategoryName;
                    category.Description = CategoryDesciption;
                    _categoryService.Create(category);
                    
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
            var model = _categoryService.GetById(id);           
            return View(model);
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(FormCollection form)
        {
            var result = new JsonResultBO(true, "Cập nhật danh mục thành công");
            try
            {
                var CategoryName = form["CategoryName"];
                var Description = form["Description"];              
                var Id = long.Parse(form["Id"]);
                var category = _categoryService.FindBy(x=>x.Id == Id).FirstOrDefault();
                if(category != null)
                {
                    category.CategoryName = CategoryName;
                    category.Description = Description;
                    _categoryService.Update(category);
                }
                else
                {
                    result.Status = false;
                    result.Message = "Cập nhật danh mục thất bại";
                }
            }
            catch (Exception ex)
            {
                result.MessageFail(ex.Message);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Detele(long Id)
        {
            try
            {
                var category = _categoryService.FindBy(x=>x.Id == Id).FirstOrDefault();
                if (category!=null)
                {
                    _categoryService.Delete(category);
                    return Json(new { success = true, message = "Xóa danh mục thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Xóa danh mục thất bại!" });
                }            
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}