using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.CategoryRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetById(long id);
    }
}
