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
using Frank.Web.Models.UserModels;
using Frank.Service.Common;
using Frank.Model.Entities;
using System.Web.UI;
using Frank.Service.UserService;
using System.Web.UI.WebControls;

namespace Frank.Web.Controllers
{
    public class DangNhap_DangKyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _ProductRepository;
        private readonly ILog _ilog;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        public DangNhap_DangKyController(
            IProductService ProductService,
            ILog Ilog,
            IMapper mapper,
            IUserService userService

              )
        {
            _userService = userService;
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            //_dM_DulieuDanhmucService = dM_DulieuDanhmucService;
        }
        // GET: DangNhap_DangKy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            var model = new UserCreateVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Login(UserCreateVM model)
        {
            var result = new JsonResultBO(true, "Đăng nhập thành công");
            try
            {
                var user = new User();
                user.UserName = model.UserName;
                user.Password = model.Password;
                var checklogin = _userService.FindBy(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
                if (checklogin == null)
                {
                    result.Status = false;
                    result.Message = "Thông tin tài khoản hoặc mật khẩu không chính xác!";
                }
                else
                {
                    result.Status = true;
                    result.Message = "Chào mừng " + checklogin.FullName;
                    result.Id = checklogin.Id;
                    
                }
            }
            catch (Exception ex)
            {
                result.MessageFail(ex.Message);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Signin()
        {
            var model = new UserCreateVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(UserCreateVM model)
        {
            var result = new JsonResultBO(true, "Đăng ký thành công");
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Password = model.Password;
                    user.FullName = model.FullName;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.PhoneNumber = model.PhoneNumber;
                    user.CreatedDate = DateTime.Now;
                    var checkusername = _userService.FindBy(x => x.UserName == model.UserName).FirstOrDefault();
                    var checkemail = _userService.FindBy(x => x.Email == model.Email).FirstOrDefault();
                    if (checkusername != null)
                    {
                        result.Status = false;
                        result.Message = "Tên tài khoản đã tồn tại!";
                    }
                    else
                    {
                        if (checkemail != null)
                        {
                            result.Status = false;
                            result.Message = "Email đăng ký đã tồn tại!";
                        }
                        else
                        {
                            _userService.Create(user);
                        }
                    }
                }
                else
                {
                    throw new Exception("Có lỗi xảy ra");
                }
            }
            catch (Exception ex)
            {
                result.MessageFail(ex.Message);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
    }
}