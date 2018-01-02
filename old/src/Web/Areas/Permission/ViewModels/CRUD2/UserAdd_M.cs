using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using qx.permmision.v2.Entity;

namespace Web.Areas.Permission.ViewModels.CRUD2
{
    public class UserAdd_M
    {
        public permission_user ToModel()
        {
            return new permission_user() { user_id = user_id, user_pwd = user_pwd, user_type_id = user_type, nick_name = nick_name, note = note };
        }
        [Display(Name = "用户ID")]
        [StringLength(20)]
        public string user_id { get; set; }
        [Display(Name = "用户姓名")]
        [StringLength(100)]
        public string nick_name { get; set; }
        [Display(Name = "用户密码")]
        [Required]
        [StringLength(100)]
        public string user_pwd { get; set; }
        [Display(Name = "用户类型")]
        public string user_type { get; set; }
        [Display(Name = "备注")]
        [Column(TypeName = "text")]
        public string note { get; set; }
    }
}