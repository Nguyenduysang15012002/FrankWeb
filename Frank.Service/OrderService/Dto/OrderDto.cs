using Frank.Model.Entities;
using Frank.Service.Order_DetailService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.OrderService.Dto
{
    public class OrderDto : Order
    {
        public List<Order_DetailDto> Order_Details { get; set; }
    }
}
