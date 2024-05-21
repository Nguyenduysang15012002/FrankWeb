using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frank.Model.Entities;

namespace Frank.Repository.ImageRepository
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(DbContext context)
          : base(context)
        {

        }
        public Image GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
