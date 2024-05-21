using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model.Entities
{
    [Table("Order_Detail")]
    public class Order_Detail : AuditableEntity<long>
    {
        public long Quantity { get; set; }
        public long Price { get; set; }
        public long? Attribute_Product_Id { get; set; }
        public long? Order_Id { get; set; }
    }
}
