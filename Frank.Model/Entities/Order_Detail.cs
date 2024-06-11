using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model.Entities
{
    public class Order_Detail : Entity<long>
    {
        public long Price { get; set; }
        public int Quantity { get; set; }
        public long Order_Id { get; set; }
        public long Product_Id { get; set; }
    }
}
