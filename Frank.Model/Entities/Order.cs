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
        public int Processing_Status { get; set; }
        public long TotalPrice { get; set; }
        public string RecieveName { get; set; }
        public string RecieveAddress { get; set; }
        public string RecievePhone { get; set; }
        public long? User_Id { get; set; }     
    }
}
