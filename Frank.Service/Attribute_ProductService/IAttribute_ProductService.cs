using Frank.Model.Entities;
using Frank.Service.Attribute_ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.Attribute_ProductService
{
    public interface IAttribute_ProductService : IEntityService<Attribute_Product>
    {
        Attribute_ProductDto GetAttribute_ProductByProductId(long Id);
    }
}
