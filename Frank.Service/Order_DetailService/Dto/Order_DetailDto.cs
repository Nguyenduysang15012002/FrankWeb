using Frank.Model.Entities;
using Frank.Service.OrderService.Dto;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.Order_DetailService.Dto
{
    public class Order_DetailDto : Order_Detail
    {
        public string Url_Image {  get; set; }
        public string NameProduct { get; set;}
    }
}
