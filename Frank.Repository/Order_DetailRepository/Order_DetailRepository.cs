using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.Order_DetailRepository
{
    public class Order_DetailRepository:GenericRepository<Order_Detail>,IOrder_DetailRepository
    {
        public Order_DetailRepository(DbContext context)
         : base(context)
        {

        }
        public Order_Detail GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
