using AutoMapper;
using Frank.Model.Entities;
using Frank.Repository;
using Frank.Repository.ImageRepository;
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
        public ImageService(IMapper mapper,IImageRepository imageRepository,IUnitOfWork unitOfWork)
            :base(unitOfWork,imageRepository) 
        { 
            _mapper = mapper;
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
