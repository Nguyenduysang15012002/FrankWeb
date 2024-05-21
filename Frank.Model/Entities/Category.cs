using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model.Entities
{
    [Table("Category")]
    public class Category : AuditableEntity<long>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }     
    }
}
