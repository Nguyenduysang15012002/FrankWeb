using AutoMapper;
using Frank.Model.Entities;
using Frank.Repository.CategoryRepository;
using Frank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frank.Repository.Attribute_ProductRepository;
using Frank.Repository.ProductRepository;
using Frank.Service.Attribute_ProductService.Dto;

namespace Frank.Service.Attribute_ProductService
{
    public class Attribute_ProductService : EntityService<Attribute_Product> ,IAttribute_ProductService
    {
        IMapper _mapper;
        IAttribute_ProductRepository _attribute_ProductRepository;
        IUnitOfWork _unitOfWork;
        IProductRepository _productRepository;
        public Attribute_ProductService(IMapper mapper, IAttribute_ProductRepository attribute_ProductRepository, IUnitOfWork unitOfWork,IProductRepository productRepository)
             : base(unitOfWork, attribute_ProductRepository)
        {
            _mapper = mapper;
            _attribute_ProductRepository = attribute_ProductRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        public List<Attribute_ProductDto> GetAttribute_ProductByProductId(long Id)
        {
            var query = (from producttbl in _productRepository.GetAllAsQueryable().Where(x => x.Id == Id)
                         join attribute_Producttbl in _attribute_ProductRepository.GetAllAsQueryable()
                         on producttbl.Id equals attribute_Producttbl.Product_Id
                         select new Attribute_ProductDto
                         {
                             Size = attribute_Producttbl.Size,
                             Price = attribute_Producttbl.Price,
                             Sale_Price = attribute_Producttbl.Sale_Price,
                         }).ToList();
            return query;
        }
    }
}
