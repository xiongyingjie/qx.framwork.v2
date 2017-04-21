using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Qx.Permission.Entity;

namespace Web.Areas.Permission.ViewModels.CRUD
{
    public class MenuEdit_M
    {
        public static MenuEdit_M ToViewModel(menu menu)
        {
            return new MenuEdit_M() {_fartherid=menu.FartherID,
                isavailable=menu.IsAvailable, 
                level=menu.Level,
                menuid=menu.MenuID,
                name=menu.Name, 
                Sequence=menu.Sequence, 
                value=menu.Value};
        }
        [Required]
        [StringLength(100)]
        [Display(Name = "父菜单编号")]
        public string _fartherid { get; set; }

        [Display(Name = "菜单名称")]
        [StringLength(100)]
        [Required]
        public string name { get; set; }

        [Display(Name = "菜单编号")]
        [StringLength(100)]
        [Required]
        public string menuid { get; set; }

        [Display(Name = "指向网址")]
        [StringLength(100)]
        [Required]
        public string value { get; set; }

        [Display(Name = "菜单级数")]
        [StringLength(100)]
        [Required]
        public string level { get; set; }

        [Display(Name = "是否可用")]
        public int isavailable { get; set; }
        [Display(Name = "菜单顺序")]

        public int? Sequence { get; set; }
        [Display(Name = "备注")]
        [StringLength(100)]

        public string Note { get; set; }
        public List<SelectListItem> selectItems = new List<SelectListItem>(){
                  new SelectListItem(){Text="是",Value="1",Selected=true},
                  new SelectListItem(){Text="否",Value="0"}};
    }
}