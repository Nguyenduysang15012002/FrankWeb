using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model.Entities
{ 
    [Table("Order")]
    public class Order : AuditableEntity<long>
    {
        public long TotalPrice { get; set; }      
        public int Processing_Status { get; set; }
        public long Quantity { get; set; }
        public long? User_Id { get; set; }
        public long? Product_Id { get; set; }       
    }
}
