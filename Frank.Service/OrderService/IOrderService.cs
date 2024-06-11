using Frank.Model.Entities;
using Frank.Service.ShopCartService.Dto;
using Frank.Service.OrderService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.OrderService
{
    public interface IOrderService : IEntityService<Order>
    {
        //List<OrderDto> GetListByIdUser(long UserId);
    }
}
