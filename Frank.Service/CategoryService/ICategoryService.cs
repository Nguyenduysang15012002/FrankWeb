using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Frank.Service.CategoryService
{
    public interface ICategoryService : IEntityService<Category>
    {
        List<SelectListItem> GetDropDownList();
    }
}
