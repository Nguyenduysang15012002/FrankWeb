using AutoMapper;
using Frank.Repository.ProductRepository;
using Frank.Repository;
using Frank.Service.Attribute_ProductService;
using Frank.Service.ImageService;
using Frank.Service.ProductService;
using Frank.Service.UserService;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Frank.Service.ShopCartService;
using Frank.Web.Models.ProductModels;
using Frank.Model.Entities;
using X.PagedList;

namespace Frank.Web.Controllers
{

    public class GioHang : Controller
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
        public GioHang(
            IProductService ProductService,
            ILog Ilog,
            IMapper mapper,
            IUserService userService,
            IImageService imageService,
            IAttribute_ProductService attribute_ProductService,
            IShopCartService shopCartService

              )
        {
            _userService = userService;
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            _imageService = imageService;
            _attribute_ProductService = attribute_ProductService;
            _shopCartService = shopCartService;
        }
        //public ActionResult Index(long Id)
        //{
        //    ViewBag.Id = Id;
        //    var user = _userService.FindBy(x => x.Id == Id).FirstOrDefault();
        //    ViewBag.Name = user?.FullName;
        //    //var ListData = _shopCartService       
        //    int pageSize = 1;
        //    //int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    var listShopcart = _shopCartService.GetListByIdUser(Id);
        //    PagedList<ShopCart> lst = new PagedList<ShopCart>(listShopcart, pageNumber, pageSize);
        //    return View(lst);
        //}
    }
}