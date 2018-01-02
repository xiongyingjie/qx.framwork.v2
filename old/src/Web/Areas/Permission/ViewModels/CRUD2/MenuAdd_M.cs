using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using Qx.Tools.CommonExtendMethods;

namespace Web.Areas.Permission.ViewModels.CRUD2
{
    public class MenuAdd_M
    {
        public menu ToModel()
        {
            return new menu()
            {
                farther_id = _farther_id,
                status = status,
                depth = depth,
                menu_id = menu_id,
                name = name,
                note = note,
                sequence = sequence,
                url = url
            };
        }
        public static MenuAdd_M ToViewModel(string farther_id, List<SelectListItem> menuSelectListItems)
        {
            return new MenuAdd_M()
            {
                _farther_id = farther_id,
                menu_id = farther_id+"."+"".CheckValue(),
                _MenSelectListItems = menuSelectListItems,
            };
        }
       


         [Required]
         [StringLength(100)]
        [Display(Name = "父菜单")]
        public string _farther_id { get; set; }

        [Display(Name = "菜单名称")]
        [StringLength(100)]
        [Required]
        public string name { get; set; }

        [Display(Name = "菜单编号")]
        [StringLength(100)]
        [Required]
        public string menu_id { get; set; }

        [Display(Name = "指向网址")]
        [StringLength(100)]
        [Required]
        public string url { get; set; }

        [Display(Name = "菜单级数")]
        [StringLength(100)]
        [Required]
        public string depth { get; set; }

        [Display(Name = "是否可用")]
        public string status { get; set; }
        [Display(Name = "菜单顺序")]
     
        public int sequence { get; set; }
        [Display(Name = "备注")]
        [StringLength(100)]

        public string note { get; set; }
        public List<SelectListItem> _MenSelectListItems { get; set; }
        public List<SelectListItem> selectItems = new List<SelectListItem>(){
                  new SelectListItem(){Text="是",Value="1",Selected=true},
                  new SelectListItem(){Text="否",Value="0"}};
    }
}