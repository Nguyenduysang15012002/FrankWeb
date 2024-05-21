using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.ImageRepository
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        Image GetById(long id);
    }
}
