using System.ComponentModel.DataAnnotations;
using Qx.Permission.Entity;

namespace Web.Areas.Permission.ViewModels.CRUD
{
    public class BanButtonAdd_M
    {
        public role_button_forbid ToModel()
        {
            return new role_button_forbid() { ButtonID = buttonid, RoleID = roleid, RoleButtonForbidID = roleButtonForbidID, Note = note };
        }
        public static BanButtonAdd_M ToViewModel(string roleid,string rolename,string buttonid,string butttonname)
        {
            return new BanButtonAdd_M() { roleid = roleid ,rolename=rolename,buttonid=buttonid,_buttonname=butttonname};
        }
        public static BanButtonAdd_M ToViewModel(string roleid, string rolename)
        {
            
            return new BanButtonAdd_M() { roleid = roleid, rolename = rolename };
        }
        [StringLength(80)]
        public string roleButtonForbidID { get; set; }
        [Display(Name = "按钮编号")]
        [Required]
        [StringLength(60)]
        public string buttonid { get; set; }
        [Display(Name = "按钮名称")]
        public string _buttonname { get; set; }
        [Display(Name = "角色编号")]
        [Required]
        [StringLength(20)]
        public string roleid{ get; set; }
        [Display(Name = "角色名称")]
        public string rolename { get; set; }
        [StringLength(10)]
        [Display(Name = "备注")]
        public string note { get; set; }
    }
}