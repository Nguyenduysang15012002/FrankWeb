using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.ShopCartRepository
{
    public interface IShopCartRepository : IGenericRepository<ShopCart>
    {
        ShopCart GetById(long id);
    }
}
