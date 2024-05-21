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

namespace Frank.Service.Attribute_ProductService
{
    public class Attribute_ProductService : EntityService<Attribute_Product> ,IAttribute_ProductService
    {
        IMapper _mapper;
        IAttribute_ProductRepository _attribute_ProductRepository;
        IUnitOfWork _unitOfWork;
        public Attribute_ProductService(IMapper mapper, IAttribute_ProductRepository attribute_ProductRepository, IUnitOfWork unitOfWork)
             : base(unitOfWork, attribute_ProductRepository)
        {
            _mapper = mapper;
            _attribute_ProductRepository = attribute_ProductRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
