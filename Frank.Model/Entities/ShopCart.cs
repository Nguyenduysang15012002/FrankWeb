using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model.Entities
{
    [Table("ShopCart")]
    public class ShopCart : AuditableEntity<long>
    {
        public long Product_Id { get; set; }
        public long User_Id { get; set;}
        public long Quantity { get; set; }
        public long Total { get; set; }
    }
}
