using Frank.Model.Entities;
using Frank.Service.Attribute_ProductService.Dto;
using Frank.Service.ImageService.Dto;
using Frank.Service.ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frank.Web.Models.ProductModels
{
    public class ProductDetailVM 
    {
        public Product Product { get; set; }
        public List<Attribute_ProductDto> AttributeProducts { get; set; }
        public List<ImageDto> Images { get; set; }
        public long Id { get; set; }
    }
}