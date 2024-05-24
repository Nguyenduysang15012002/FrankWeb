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
        public HomeController(
            IProductService ProductService, ILog Ilog,
            IAttribute_ProductService AttributeService,
              //  //IDM_DulieuDanhmucService dM_DulieuDanhmucService,
              IUserService UserService,
              IMapper mapper
              )
        {
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            _userService = UserService;
            _attribute_ProductService = AttributeService;
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
                ViewBag.Id = null;
                ViewBag.Name = null;
            }
            var listData = _productService.GetDaTaByPage(null);
            return View(listData);
        }     
    }
}