using System.ComponentModel.DataAnnotations;
using qx.permmision.v2.Entity;

namespace Web.Areas.Permission.ViewModels.CRUD2
{
    public class BanButtonAdd_M
    {
        public role_button_forbid ToModel()
        {
            return new role_button_forbid() { button_id = button_id, role_id = role_id, role_Button_forbid_id = role_Button_forbid_id, note = note };
        }
        public static BanButtonAdd_M ToViewModel(string role_id,string role_name, string button_id,string buttton_name)
        {
            return new BanButtonAdd_M() { role_id = role_id , role_name = role_name,button_id=button_id,_button_name= buttton_name };
        }
        public static BanButtonAdd_M ToViewModel(string role_id, string role_name)
        {
            
            return new BanButtonAdd_M() { role_id = role_id, role_name = role_name };
        }
        [StringLength(80)]
        public string role_Button_forbid_id { get; set; }
        [Display(Name = "按钮编号")]
        [Required]
        [StringLength(60)]
        public string button_id { get; set; }
        [Display(Name = "按钮名称")]
        public string _button_name { get; set; }
        [Display(Name = "角色编号")]
        [Required]
        [StringLength(20)]
        public string role_id{ get; set; }
        [Display(Name = "角色名称")]
        public string role_name { get; set; }
        [StringLength(10)]
        [Display(Name = "备注")]
        public string note { get; set; }
    }
}