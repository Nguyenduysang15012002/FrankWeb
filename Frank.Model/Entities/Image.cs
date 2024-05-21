using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model.Entities
{
    [Table("Image")]
    public class Image : AuditableEntity<long>
    {
        public string Url_Image { get; set; }
        public string Title { get; set; }
        public long? Product_Id { get; set; }
        public long? User_Id { get; set; }
    }
}
