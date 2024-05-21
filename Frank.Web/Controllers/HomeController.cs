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
        public HomeController(
            IProductService ProductService, ILog Ilog,

              //  //IDM_DulieuDanhmucService dM_DulieuDanhmucService,
              IMapper mapper
              )
        {
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            //_dM_DulieuDanhmucService = dM_DulieuDanhmucService;
        }

        public ActionResult Index()
        {
            var listData = _productService.GetDaTaByPage(null);
            return View(listData);
        }
    }
}