using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model.Entities
{
    [Table("Permission")]
    public class Permission : AuditableEntity<long>
    {
        public string PermissionName { get; set; }
    }
}
