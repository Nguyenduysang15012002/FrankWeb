using Frank.Model.Entities;
using Frank.Service.Attribute_ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.ProductService.Dto
{
    public class ProductDto : Product
    {
        public long Price { get; set; }
        public string Url_Image { get; set; }
    }
}
