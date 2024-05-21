using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frank.Model.Entities;

namespace Frank.Repository.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context)
          : base(context)
        {

        }
        public Category GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
