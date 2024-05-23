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
        public HomeController(
            IProductService ProductService, ILog Ilog,

              //  //IDM_DulieuDanhmucService dM_DulieuDanhmucService,
              IUserService UserService,
              IMapper mapper
              )
        {
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            _userService = UserService;
            //_dM_DulieuDanhmucService = dM_DulieuDanhmucService;
        }

        public ActionResult Trangchu(long? Id)
        {

            if (Id != null)
            {
                ViewBag.Id = Id;
                var user = _userService.FindBy(x => x.Id == Id).FirstOrDefault();
                ViewBag.Name = user?.FullName;
            }
            else
            {
                ViewBag.Name = null;
            }
            var listData = _productService.GetDaTaByPage(null);
            return View(listData);
        }
        [HttpGet]
        public ActionResult Index(long? Id)
        {
            if (Id != null)
            {
                ViewBag.Id = Id;
                var user = _userService.FindBy(x => x.Id == Id).FirstOrDefault();
                ViewBag.Name = user?.FullName;
            }
            else
            {
                ViewBag.Name = null;
            }
            var listData = _productService.GetDaTaByPage(null);
            return View(listData);
        }
    }
}