using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product GetById(long id);
    }
}
