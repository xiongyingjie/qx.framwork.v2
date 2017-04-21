using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Qx.Permission.Entity;

namespace Web.Areas.Permission.ViewModels.CRUD
{
    public class UserAdd_M
    {
        public permission_user ToModel()
        {
            return new permission_user() { UserID = userid, UserPwd = userpwd, UserTypeId = usertype, NickName = nickname, Note = note };
        }
        [Display(Name = "单位管理员工号")]
        [StringLength(20)]
        public string userid { get; set; }
        [Display(Name = "单位管理员姓名")]
        [StringLength(100)]
        public string nickname { get; set; }
        [Display(Name = "单位管理员密码")]
        [Required]
        [StringLength(100)]
        public string userpwd { get; set; }
        [Display(Name = "用户类型")]
        public string usertype { get; set; }
        [Display(Name = "备注")]
        [Column(TypeName = "text")]
        public string note { get; set; }
    }
}