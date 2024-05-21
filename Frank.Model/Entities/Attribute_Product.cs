using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model.Entities
{
    [Table("Attribute_Product")]
    public class Attribute_Product : AuditableEntity<long>
    {
        public long Size { get; set; }
        public long Price { get; set; }
        public long Sale_Price { get; set; }
        public long Amount { get; set; }
        public long? Product_Id { get; set; }

    }
}
