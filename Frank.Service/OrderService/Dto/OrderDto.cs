using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.OrderService.Dto
{
    public class OrderDto : Order
    {
        public string NameCustomer { get; set; }
        public string Phone {  get; set; }
        public string Address { get; set; }
        public string Url_Image { get; set; }
        public string Name_Product { get; set; }
        public long Gia { get; set; }
    }
}
