using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model.Entities
{
    [Table("Product")]
    public class Product : AuditableEntity<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int ProductionYear { get; set; }
        public int ExpiredYear { get; set; }
        public string Quantity { get; set; }
        public long? Category_Id { get; set; }
    }
}
