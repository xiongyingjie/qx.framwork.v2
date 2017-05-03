using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using qx.permmision.v2.Entity;

namespace Web.Areas.Permission.ViewModels.CRUD2
{
    public class RoleMenuAdd_M
    {
        public role_menu ToModel()
        {
            return new role_menu() { role_menu_id = role_menu_id, menu_id = menu_id, role_id = role_id, include_children = include_children, note = note };
        }
        public static RoleMenuAdd_M ToViewModel(string role_id,string role_Name,string menu_id,string menu_Name)
        {
            return new RoleMenuAdd_M() {role_id=role_id,menu_id=menu_id ,menu_name=menu_Name,_role_name=role_Name};
        }
        public static RoleMenuAdd_M ToViewModel(string role_id,string role_Name, string menu_id)
        {
            return new RoleMenuAdd_M() { role_id = role_id, menu_id = menu_id, _role_name = role_Name };
        }
        [StringLength(120)]
        public string role_menu_id { get; set; }
        [Display(Name = "角色名称")]
        public string _role_name { get; set; }
        [Display(Name = "角色编号")]
        [Required]
        [StringLength(20)]
        public string role_id { get; set; }

        [Display(Name = "菜单名称")]
        public string menu_name { get; set; }
        [Display(Name = "菜单编号")]
        [Required]
        [StringLength(100)]
        public string menu_id { get; set; }
        [Display(Name = "是否包含子菜单")]
        public int include_children{ get; set; }
         [Display(Name = "备注")]
        [StringLength(10)]
        public string note { get; set; }
        public List<SelectListItem> selectItems=new List<SelectListItem>(){
                  new SelectListItem(){Text="是",Value="1",Selected=true},
                  new SelectListItem(){Text="否",Value="0"}};
    }
}