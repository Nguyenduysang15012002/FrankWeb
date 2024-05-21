using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.Order_AddressRepository
{
    public class Order_AddressRepository:GenericRepository<Order_Address>,IOrder_AddressRepository
    {
        public Order_AddressRepository(DbContext context)
         : base(context)
        {

        }
        public Order_Address GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
