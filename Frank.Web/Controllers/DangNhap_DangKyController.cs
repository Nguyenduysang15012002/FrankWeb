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
            return View();
        }
        public ActionResult Signin()
        {
            var model =new UserCreateVM();
            return View(model);
        }
        [HttpPost]
      
        public JsonResult Create(UserCreateVM model, FormCollection form)
        {
            var result = new JsonResultBO(true, "Đăng ký thành công");
            try
            {
                if (ModelState.IsValid)
                {
                    var EntityModel = _mapper.Map<User>(model);
                    var user = new User();
                    user.UserName = model.UserName;
                    _userService.Create(user);

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