using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.Attribute_ProductRepository
{
    public interface IAttribute_ProductRepository : IGenericRepository<Attribute_Product>
    {
        Attribute_Product GetById(long id);
    }
}
