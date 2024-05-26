using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.ShopCartService.Dto
{
    public class ShopCartDto:ShopCart
    {
        public long Price { get; set; }
        public string NameProduct {  get; set; }
        public string Image_Product { get; set; }    
        public long TotalPrice { get; set; }
    }
}
