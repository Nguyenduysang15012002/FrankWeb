using AutoMapper;
using Frank.Model.Entities;
using Frank.Repository;
using Frank.Repository.CategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.CategoryService
{
    public class CategoryService : EntityService<Category>, ICategoryService
    {
        IMapper _mapper;
        ICategoryRepository _categoryRepository;
        IUnitOfWork _unitOfWork;
        public CategoryService(IMapper mapper,ICategoryRepository categoryRepository,IUnitOfWork unitOfWork)
            :base(unitOfWork,categoryRepository) 
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
