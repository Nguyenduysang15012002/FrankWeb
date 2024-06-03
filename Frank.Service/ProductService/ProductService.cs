using Frank.Model.Entities;
using Frank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Frank.Repository.ProductRepository;
using System.Linq.Dynamic;
using AutoMapper;
using PagedList;
using log4net;
using Frank.Service.Common;
using Frank.Service.ProductService.Dto;
using Frank.Service.Attribute_ProductService;
using Frank.Repository.Attribute_ProductRepository;
using Frank.Service.Attribute_ProductService.Dto;
using Frank.Repository.ImageRepository;

namespace Frank.Service.ProductService
{
    public class ProductService : EntityService<Product>, IProductService
    {
        IUnitOfWork _unitOfWork;
        IProductRepository _productRepository;
        ILog _loger;
        IMapper _mapper;
        IAttribute_ProductRepository _attribute_ProductRepository;
        IImageRepository _imageRepository;
        public ProductService(IUnitOfWork unitOfWork,
         IProductRepository ProductRepository,
         ILog loger,
         IMapper mapper,
         IAttribute_ProductRepository attribute_ProductRepository,
         IImageRepository imageRepository
        )
        : base(unitOfWork, ProductRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = ProductRepository;
            _loger = loger;
            _mapper = mapper;
            _attribute_ProductRepository = attribute_ProductRepository;
            _imageRepository = imageRepository;
        }
       public  List<ProductDto> GetDaTaByPage()
        {           
            var query = from Producttbl in _productRepository.GetAllAsQueryable()
                        join attribute in _attribute_ProductRepository.GetAllAsQueryable()
                        on Producttbl.Id equals attribute.Product_Id
                        join imagetbl in _imageRepository.GetAllAsQueryable()
                        on Producttbl.Id equals imagetbl.Product_Id

                        select new ProductDto
                        {
                           Id = Producttbl.Id,                          
                           Name = Producttbl.Name,                      
                           ProductionYear = Producttbl.ProductionYear,                         
                           Quantity = Producttbl.Quantity,
                           Price = attribute.Price,
                           Url_Image = imagetbl.Url_Image,
                           Brand = Producttbl.Brand,

                        };          
            return query.ToList();
        }
        public ProductDto GetById(long? Id)
        {
            var query = from producttbl in _productRepository.GetAllAsQueryable()
                        where producttbl.Id == Id
                        select new ProductDto
                        {
                            Quantity = producttbl.Quantity,
                        };
            return query.SingleOrDefault();
        }
        public List<ProductDto> GetListProduct()
        {
            var query = from producttbl in _productRepository.GetAllAsQueryable()
                        join imagetbl in _imageRepository.GetAllAsQueryable()
                        on producttbl.Id equals imagetbl.Product_Id
                        join attributeproducttbl in _attribute_ProductRepository.GetAllAsQueryable()
                        on producttbl.Id equals attributeproducttbl.Product_Id                     
                        select new ProductDto
                        {
                            Id = producttbl.Id,
                            Name = producttbl.Name,
                            Description = producttbl.Description,
                            Brand = producttbl.Brand,
                            ProductionYear = producttbl.ProductionYear,
                            ExpiredYear = producttbl.ExpiredYear,
                            Quantity = producttbl.Quantity,
                            Price = attributeproducttbl.Price,
                            Url_Image = imagetbl.Url_Image,
                        };
            return query.ToList();
        }
    }
}
