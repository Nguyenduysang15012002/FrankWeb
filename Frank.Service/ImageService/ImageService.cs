using AutoMapper;
using Frank.Model.Entities;
using Frank.Repository;
using Frank.Repository.ImageRepository;
using Frank.Repository.ProductRepository;
using Frank.Service.ImageService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.ImageService
{
    public class ImageService:EntityService<Image>, IImageService
    {
        IMapper _mapper;
        IImageRepository _imageRepository;
        IUnitOfWork _unitOfWork;
        IProductRepository _productRepository;

        public ImageService(IMapper mapper,IImageRepository imageRepository,IUnitOfWork unitOfWork,IProductRepository productRepository)
            :base(unitOfWork,imageRepository) 
        { 
            _mapper = mapper;
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        public List<ImageDto> GetImageByProductId(long Id)
        {
            var query = (from producttbl in _productRepository.GetAllAsQueryable().Where(x => x.Id == Id)
                        join imagetbl in _imageRepository.GetAllAsQueryable()
                        on producttbl.Id equals imagetbl.Product_Id 
                        select new ImageDto
                        {                          
                            Url_Image = imagetbl.Url_Image,
                            Title =   imagetbl.Title,
                        }).ToList();
            return query;
        }
    }
    
}
