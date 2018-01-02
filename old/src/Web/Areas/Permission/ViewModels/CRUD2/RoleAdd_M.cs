using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using qx.permmision.v2.Entity;

namespace Web.Areas.Permission.ViewModels.CRUD2
{
    public class RoleAdd_M
    {
        public role ToModel()
        {
            return new role() { role_id = role_id, name = name, is_default = is_default, role_type = role_type, sub_system = sub_system };
        }
        [Display(Name = "角色编号")]
        public string role_id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "角色名称")]
        public string name { get; set; }

   
        [StringLength(10)]
        [Display(Name = "角色类型")]
        public string role_type { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "子系统")]
        public string sub_system { get; set; }
        [Display(Name = "是否默认")]
        public int? is_default { get; set; }
        public List<SelectListItem> selectItems = new List<SelectListItem>(){
                  new SelectListItem(){Text="是",Value="1",Selected=true},
                  new SelectListItem(){Text="否",Value="0"}};

    }
}