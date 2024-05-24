using Frank.Model.Entities;
using Frank.Service.ImageService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.ImageService
{
    public interface IImageService:IEntityService<Image>
    {
        List<ImageDto> GetImageByProductId(long Id);
    }
}
