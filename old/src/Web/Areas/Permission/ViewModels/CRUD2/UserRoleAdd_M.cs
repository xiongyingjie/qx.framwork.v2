using System.ComponentModel.DataAnnotations;
using qx.permmision.v2.Entity;

namespace Web.Areas.Permission.ViewModels.CRUD2
{
    public class UserRoleAdd_M
    {
        public user_role ToModel()
        {
            return new user_role() { role_id = role_id, user_role_id = user_role_id, user_id = user_id, note = note };
        }
        public static UserRoleAdd_M ToViewModel(string user_id,string  role_id,string role_name)
        {
            return new UserRoleAdd_M() { user_id = user_id ,role_id=role_id,_role_name=role_name};
        }
        public static UserRoleAdd_M ToViewModel(string user_id)
        {
            return new UserRoleAdd_M() { user_id = user_id};
        }
        [StringLength(40)]
        public string user_role_id { get; set; }
        [Display(Name = "用户编号")]
        [Required]
        [StringLength(20)]
        public string user_id { get; set; }
        [Display(Name = "角色名称")]
        public string _role_name { get; set; }
        [Display(Name = "角色编号")]
        [Required]
        [StringLength(20)]
        public string role_id { get; set; }
        [Display(Name = "备注")]
        public string note { get; set; }
    }
}