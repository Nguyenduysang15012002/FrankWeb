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
using Frank.Service.ImageService;
using PagedList;
using Frank.Model.Entities;
using Frank.Service.Common;
using System.IO;

namespace Frank.Web.Controllers
{
    public class UserController : Controller
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

        private readonly IImageService _imageService;
        public UserController(
            IProductService ProductService, ILog Ilog,
            IAttribute_ProductService AttributeService,            
              IUserService UserService,
              IMapper mapper,
              IShopCartService shopCartService,
              IOrderService orderService,
              IImageService imageService
              )
        {
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            _userService = UserService;
            _attribute_ProductService = AttributeService;
            _shopCartService = shopCartService;
            _orderService = orderService;
            _imageService = imageService;
        }
        // GET: User
        public ActionResult Index(int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int pageSizeValue = pageSize ?? 20;
            var listUser = _userService.GetAll().ToList();
            var userPagedList = listUser.ToPagedList(pageNumber, pageSizeValue);
            ViewBag.PageSize = pageSize;
            ViewBag.quyen = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Admin" },
                new SelectListItem { Value = "2", Text = "Khách hàng" }
            };
            ViewBag.Status = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Hoạt động" },
                new SelectListItem { Value = "2", Text = "Khóa" }
            };
            return View(userPagedList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public JsonResult Create(FormCollection form)
        {
            var result = new JsonResultBO(true, "Thêm tài khoản thành công");
            try
            {
                var UserName = form["UserName"];
                var Password = form["Password"];
                var FullName = form["FullName"];
                var Email = form["Email"];
                var Address = form["Address"];
                var PhoneNumber = form["PhoneNumber"];
                var Status = long.Parse(form["Status"]);
                var Quyen = long.Parse(form["Quyen"]);
                var checkname = _userService.FindBy(x=>x.UserName ==  UserName).FirstOrDefault();
                var checkemail = _userService.FindBy(x=>x.Email == Email).FirstOrDefault();
                if (checkname != null)
                {
                    result.Status = false;
                    result.Message = "Đã có tài khoản "+ checkname.UserName;
                }
                else
                { 
                    if (checkemail != null)
                    {
                        result.Status = false;
                        result.Message = "Email đăng ký đã tồn tại :" + checkemail.Email;
                    }
                    else
                    {
                        var user = new User();
                        user.UserName = UserName;
                        user.Password = Password;
                        user.Email = Email;
                        user.PhoneNumber = PhoneNumber;
                        user.Address = Address;
                        user.FullName = FullName;
                        user.CreatedDate = DateTime.Now;
                        if(Quyen == 1)
                        {
                            user.IsAdmin = true;
                            user.IsCustomer = false;
                            user.Istaff = false;
                        }
                        else
                        {
                            user.IsAdmin = false;
                            user.IsCustomer = true;
                            user.Istaff = false;
                        }
                        if(Status == 1)
                        {
                            user.Status = true;
                        }
                        else
                        {
                            user.Status = false;
                        }
                        _userService.Create(user);
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
            ViewBag.quyen = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Admin" },
                new SelectListItem { Value = "2", Text = "Khách hàng" }
            };
            ViewBag.Status = new List<SelectListItem>
            {
               
                new SelectListItem { Value = "1", Text = "Hoạt động" },
                 new SelectListItem { Value = "2", Text = "Khóa" }
            };
            var model = _userService.GetById(id);
            return View(model);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(FormCollection form)
        {
            var result = new JsonResultBO(true, "Cập nhật tài khoản thành công");
            try
            {
                var UserName = form["UserName"];
                var Password = form["Password"];
                var FullName = form["FullName"];
                var Email = form["Email"];
                var Address = form["Address"];
                var PhoneNumber = form["PhoneNumber"];
                var Status = long.Parse(form["Status"]);
                var Quyen = long.Parse(form["Quyen"]);
                var Id = long.Parse(form["Id"]);

                var user = _userService.FindBy(x=>x.Id == Id).FirstOrDefault();
                if(user != null)
                {
                    user.Id = Id;
                    user.UserName = UserName;
                    user.Password = Password;
                    user.Email = Email;
                    user.PhoneNumber = PhoneNumber;
                    user.FullName = FullName;
                    user.Address = Address;
                    if (Quyen == 1)
                    {
                        user.IsAdmin = true;
                        user.IsCustomer = false;
                        user.Istaff = false;
                    }
                    else
                    {
                        user.IsAdmin = false;
                        user.IsCustomer = true;
                        user.Istaff = false;
                    }
                    if (Status == 1)
                    {
                        user.Status = true;
                    }
                    else
                    {
                        user.Status = false;
                    }
                    _userService.Update(user);
                }
                else
                {
                    result.Status = false;
                    result.Message = "Cập nhật tài khoản thất bại";
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
                var user = _userService.FindBy(x => x.Id == Id).FirstOrDefault();
                if (user != null)
                {
                    _userService.Delete(user);
                    return Json(new { success = true, message = "Xóa tài khoản thành công." });
                }
                else
                {
                    return Json(new { success = false, message = "Xóa tài khoản thất bại." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}