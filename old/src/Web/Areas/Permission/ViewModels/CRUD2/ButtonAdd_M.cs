using System.ComponentModel.DataAnnotations;
using qx.permmision.v2.Entity;

namespace Web.Areas.Permission.ViewModels.CRUD2
{
    public class ButtonAdd_M
    {
        public button ToModel()
        {
            return new button() {  button_id=button_id, menu_id=menu_id, name=name, value=value, note=note};
        }
        public static ButtonAdd_M ToViewModel(string menu_id)
        {
            return new ButtonAdd_M() { menu_id = menu_id };
        }
        [StringLength(60)]
        [Display(Name = "按钮编号")]
        public string button_id { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "按钮名称")]
        public string name { get; set; }
        [Display(Name = "所属菜单编号")]
        [Required]
        [StringLength(100)]
        public string menu_id{ get; set; }
        [Required]
        [StringLength(40)]
        [Display(Name = "按钮值")]
        public string value { get; set; }
        [StringLength(10)]
        [Display(Name = "备注")]
        public string note { get; set; }
    }
}