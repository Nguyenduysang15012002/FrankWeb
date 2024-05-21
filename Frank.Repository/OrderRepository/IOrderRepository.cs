using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.OrderRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Order GetById(long id);
    }
}
