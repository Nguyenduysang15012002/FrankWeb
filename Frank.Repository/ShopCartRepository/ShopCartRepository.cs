using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.ShopCartRepository
{
    public class ShopCartRepository : GenericRepository<ShopCart> , IShopCartRepository
    {
        public ShopCartRepository(DbContext context)
           : base(context)
        {

        }
        public ShopCart GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
