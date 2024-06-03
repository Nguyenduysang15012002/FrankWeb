using Frank.Model.Entities;
using Frank.Service.Common;
using Frank.Service.ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.ProductService
{
    public interface IProductService:IEntityService<Product>
    {
        List<ProductDto> GetDaTaByPage();
        ProductDto GetById(long? Id);
        List<ProductDto> GetListProduct();
    }
}
