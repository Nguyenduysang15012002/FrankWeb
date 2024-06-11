using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model.Entities
{
    [Table("User")]
    public class User : AuditableEntity<long>
    {
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DisplayName("Tài khoản đăng nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DisplayName("Email đăng ký")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DisplayName("Số điện thoại")]
        [RegularExpression(@"^\d{1,10}$", ErrorMessage = "Số điện thoại chỉ được nhập số và không quá 10 số.")]
        [StringLength(10, ErrorMessage = "Số điện thoại không được quá 10 số.")]
        public string PhoneNumber { get; set; }     
        public bool Status { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsAdmin { get; set; }
        public bool Istaff { get; set; }
    }
}
