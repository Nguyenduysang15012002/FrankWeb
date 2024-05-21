using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context)
            : base(context)
        {

        }
        public Product GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
