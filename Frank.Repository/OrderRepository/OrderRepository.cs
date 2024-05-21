using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.OrderRepository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context)
                : base(context)
        {

        }
        public Order GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
