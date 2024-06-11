using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.Order_DetailRepository
{
    public interface IOrder_DetailRepository :IGenericRepository<Order_Detail>
    {
        Order_Detail GetById(long id);
    }
}
