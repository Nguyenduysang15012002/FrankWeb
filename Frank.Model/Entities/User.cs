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
        [Required]
        [DisplayName("Tài khoản đăng nhập")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }
        [Required]
        [DisplayName("Email đăng ký")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }
        
        public string Status { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsAdmin { get; set; }
        public bool Istaff { get; set; }
    }
}
