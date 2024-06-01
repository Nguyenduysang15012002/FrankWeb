using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model.Entities
{
    public class Order_Address :AuditableEntity<long>
    {
        public string NameCustomer { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public long? Order_Id { get; set; }
    }
}
