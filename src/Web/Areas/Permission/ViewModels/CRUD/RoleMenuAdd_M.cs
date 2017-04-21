using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Qx.Permission.Entity;

namespace Web.Areas.Permission.ViewModels.CRUD
{
    public class RoleMenuAdd_M
    {
        public role_menu ToModel()
        {
            return new role_menu() { RoleMenuID = RoleMenuID, MenuID = MenuID, RoleID = RoleID, IncludeChildren = includeChildren, Note = note };
        }
        public static RoleMenuAdd_M ToViewModel(string roleid,string rolename,string menuid,string menuname)
        {
            return new RoleMenuAdd_M() {RoleID=roleid,MenuID=menuid ,MenuName=menuname,_RoleName=rolename};
        }
        public static RoleMenuAdd_M ToViewModel(string roleid,string rolename, string menuid)
        {
            return new RoleMenuAdd_M() { RoleID = roleid, MenuID = menuid, _RoleName = rolename };
        }
        [StringLength(120)]
        public string RoleMenuID { get; set; }
        [Display(Name = "角色名称")]
        public string _RoleName { get; set; }
        [Display(Name = "角色编号")]
        [Required]
        [StringLength(20)]
        public string RoleID { get; set; }

        [Display(Name = "菜单名称")]
        public string MenuName { get; set; }
        [Display(Name = "菜单编号")]
        [Required]
        [StringLength(100)]
        public string MenuID { get; set; }
        [Display(Name = "是否包含子菜单")]
        public int includeChildren{ get; set; }
         [Display(Name = "备注")]
        [StringLength(10)]
        public string note { get; set; }
        public List<SelectListItem> selectItems=new List<SelectListItem>(){
                  new SelectListItem(){Text="是",Value="1",Selected=true},
                  new SelectListItem(){Text="否",Value="0"}};
    }
}