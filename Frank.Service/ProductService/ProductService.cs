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

namespace Frank.Service.ProductService
{
    public class ProductService : EntityService<Product>, IProductService
    {
        IUnitOfWork _unitOfWork;
        IProductRepository _productRepository;
        ILog _loger;
        IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork,
         IProductRepository ProductRepository,
         ILog loger,
         IMapper mapper
        )
        : base(unitOfWork, ProductRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = ProductRepository;
            _loger = loger;
            _mapper = mapper;
        }
       public PageListResultBO<ProductDto> GetDaTaByPage(ProductDto searchModel, int pageIndex = 1, int pageSize = 20)
        {           
            var query = from Producttbl in _productRepository.GetAllAsQueryable()

                        select new ProductDto
                        {
                           Id = Producttbl.Id,
                           Brand = Producttbl.Brand,
                           Description = Producttbl.Description,                       
                           ProductionYear = Producttbl.ProductionYear,
                           ExpiredYear = Producttbl.ExpiredYear,
                           Quantity = Producttbl.Quantity,
                        };

            if (searchModel != null)
            {


                if (!string.IsNullOrEmpty(searchModel.Description))
                {
                    query = query.OrderBy(searchModel.Description);
                }
                else
                {
                    query = query.OrderByDescending(x => x.Id);
                }
            }
            else
            {
                query = query.OrderByDescending(x => x.Id);
            }
            var resultmodel = new PageListResultBO<ProductDto>();
            pageSize = query.Count();
            if (pageSize == -1)
            {
                var dataPageList = query.ToList();
                resultmodel.Count = dataPageList.Count;
                resultmodel.TotalPage = 1;
                resultmodel.ListItem = dataPageList;
            }
            else
            {
                var dataPageList = query.ToPagedList(pageIndex, pageSize);
                resultmodel.Count = dataPageList.TotalItemCount;
                resultmodel.TotalPage = dataPageList.PageCount;
                resultmodel.ListItem = dataPageList.ToList();
            }

            return resultmodel;
        }

    }
}
