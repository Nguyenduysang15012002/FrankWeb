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
        public long Total { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_Address { get; set;}
        public string Customer_Phone  { get; set;}
        public int Processing_Status { get; set; }
        public long? User_Id { get; set; }

    
    }
}
