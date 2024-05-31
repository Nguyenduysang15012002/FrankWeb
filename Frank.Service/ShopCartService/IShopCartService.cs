using Frank.Model.Entities;
using Frank.Service.Common;
using Frank.Service.OrderService.Dto;
using Frank.Service.ProductService.Dto;
using Frank.Service.ShopCartService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.ShopCartService
{
   
    public interface IShopCartService : IEntityService<ShopCart>
    {
        ShopCart GetById(long Id);
        List<ShopCartDto> GetListByIdUser(long UserId);
        ShopCartDto GetbyUserVsProductId(long? User_Id, long? Product_Id);       
    }
}
