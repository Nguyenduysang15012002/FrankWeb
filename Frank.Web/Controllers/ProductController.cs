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
        public ProductController(
            IProductService ProductService,
            ILog Ilog,
            IMapper mapper,
            IUserService userService,
            IImageService imageService,
            IAttribute_ProductService attribute_ProductService
           
        
              )
        {
            _userService = userService;
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            _imageService = imageService;
            _attribute_ProductService = attribute_ProductService;      
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(long Id,long? User_Id)
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
            var Product =  _productService.FindBy(x=>x.Id == Id).FirstOrDefault();
            model.Product = _productService.FindBy(x => x.Id == Id).FirstOrDefault();
            model.Images = _imageService.GetImageByProductId(Id);
            model.AttributeProducts = _attribute_ProductService.GetAttribute_ProductByProductId(Id);
            return View(model);
        }
    }
}