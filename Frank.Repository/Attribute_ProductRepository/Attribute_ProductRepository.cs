using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.Attribute_ProductRepository
{
    public class Attribute_ProductRepository : GenericRepository<Attribute_Product> , IAttribute_ProductRepository
    {
        public Attribute_ProductRepository(DbContext context)
           : base(context)
        {

        }
        public Attribute_Product GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
