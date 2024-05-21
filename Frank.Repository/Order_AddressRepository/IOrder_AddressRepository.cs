using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.Order_AddressRepository
{
    public interface IOrder_AddressRepository :IGenericRepository<Order_Address>
    {
        Order_Address GetById(long id);
    }
}
