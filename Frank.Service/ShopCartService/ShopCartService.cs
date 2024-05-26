using AutoMapper;
using Frank.Model.Entities;
using Frank.Repository.ProductRepository;
using Frank.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frank.Repository.ShopCartRepository;
using Frank.Service.ShopCartService.Dto;
using Frank.Repository.Attribute_ProductRepository;
using Frank.Repository.ImageRepository;

namespace Frank.Service.ShopCartService
{
    public class ShopCartService : EntityService<ShopCart>, IShopCartService
    {
        IUnitOfWork _unitOfWork;
        IShopCartRepository _shopcartRepository;
        ILog _loger;
        IMapper _mapper;
        IProductRepository _productRepository;
        IAttribute_ProductRepository _attributeProductRepository;
        IImageRepository _imageRepository;
        public ShopCartService(IUnitOfWork unitOfWork,
         IShopCartRepository ShopCartRepository,
         ILog loger,
         IMapper mapper,
         IProductRepository productRepository,
         IAttribute_ProductRepository attribute_ProductRepository,
         IImageRepository imageRepository
        )
        : base(unitOfWork, ShopCartRepository)
        {
            _unitOfWork = unitOfWork;
            _shopcartRepository = ShopCartRepository;
            _loger = loger;
            _mapper = mapper;
            _productRepository = productRepository;
            _attributeProductRepository = attribute_ProductRepository;
            _imageRepository = imageRepository;
        }
        public ShopCart GetById(long Id)
        {
            return _shopcartRepository.GetById(Id);
        }
        public List<ShopCartDto> GetListByIdUser(long UserId)
        {
            var query = from producttbl in _productRepository.GetAllAsQueryable()
                        join shopcarttbl in _shopcartRepository.GetAllAsQueryable()
                        on producttbl.Id equals shopcarttbl.Product_Id
                        join attribute in _attributeProductRepository.GetAllAsQueryable()
                        on producttbl.Id equals attribute.Product_Id
                        join imagetbl in _imageRepository.GetAllAsQueryable()
                        on producttbl.Id equals imagetbl.Product_Id
                        where shopcarttbl.User_Id == UserId
                        select new ShopCartDto
                        {
                            Image_Product = imagetbl.Url_Image,
                            NameProduct = producttbl.Name,
                            Price = attribute.Price,
                            Quantity = shopcarttbl.Quantity,
                            TotalPrice = shopcarttbl.Quantity * attribute.Price,
                        };
            return query.ToList();
        }
    }
}

