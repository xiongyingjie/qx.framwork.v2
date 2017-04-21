using Qx.Permission.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Permission.ViewModels.CRUD
{
    public class MenuExtension_M
    {
        public menu_extension ToModel()
        {
            return new menu_extension() {  SubSystem=SubSystem, Status=Status, ParentId=ParentId, MenuID=MenuID, IsParent=IsParent, ImageClass=ImageClass,
              Controller=Controller, Area=Area, ActiveLi=ActiveLi, Action=Action};
        }
        public static MenuExtension_M ToViewModel(string menuid)
        {
            return new MenuExtension_M() { MenuID=menuid, ImageClass= "fa fa-bar-chart-o fa-fw",};
        }
        public static MenuExtension_M ToViewModel(menu_extension menuExtension)
        {
            return new MenuExtension_M() { Action = menuExtension.Action, ActiveLi = menuExtension.ActiveLi, Area = menuExtension.Area,
                                           Controller = menuExtension.Controller, ImageClass=menuExtension.ImageClass, IsParent=menuExtension.IsParent,
                                           MenuID = menuExtension.MenuID,
                                           ParentId = menuExtension.ParentId,
                                           Status = menuExtension.Status,
                                           SubSystem = menuExtension.SubSystem
            };
        }
        [Required]
        [Display(Name = "菜单ID")]
        [Key]
        [StringLength(100)]
        public string MenuID { get; set; }
        [Required]
        [Display(Name = "控制器")]
        [StringLength(50)]
        public string Controller { get; set; }
        [Required]
        [Display(Name = "方法")]
        [StringLength(50)]
        public string Action { get; set; }
        [Required]
        [Display(Name = "区域")]
        [StringLength(50)]
        public string Area { get; set; }
        [Required]
    
        [Display(Name = "小图标")]
        [StringLength(50)]
        public string ImageClass { get; set; }
        [Required]
    
        [Display(Name = "是否激活")]
        [StringLength(50)]
        public string ActiveLi { get; set; }
        [Required]
        [Display(Name = "状态")]
        [StringLength(50)]
        public string Status { get; set; }
        [Required]
        [Display(Name = "父母ID")]
        [StringLength(50)]
        public string ParentId { get; set; }
        [Required]
        [Display(Name = "是否是父母")]
        [StringLength(50)]
        public string IsParent { get; set; }
        [Required]
      
        [Display(Name = "子系统")]
        [StringLength(50)]
        public string SubSystem { get; set; }
    }
}