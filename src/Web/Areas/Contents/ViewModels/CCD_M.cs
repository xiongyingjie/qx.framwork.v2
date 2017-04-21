using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Contents.Entity;
using System.Web.Mvc;

namespace Web.Areas.Contents.ViewModels
{
    public class CCD_M
    {
        public content_column_design ToModel()
        {
            return new content_column_design()
            {
                Seq = Seq,
                PCT_ID = PCT_ID,
                IsPk = IsPk,
                DT_ID = DT_ID,
                DefValue = DefValue,
                CTD_ID = CTD_ID,
                CCD_ID = CCD_ID,
                ColumnName = ColumnName,
            };
        }
        public static CCD_M ToViewModel(List<SelectListItem> CTDelectItems,string id)
        {
            return new CCD_M() { CTDselectItems = CTDelectItems,CTD_ID=id };
        }
        public static CCD_M ToViewModel(string CTD_ID, List<SelectListItem> DTelectItems, List<SelectListItem> PCTselectItems)
        {
            return new CCD_M()
            {
                CTD_ID = CTD_ID,
                DTelectItems = DTelectItems,
                PCTselectItems = PCTselectItems

            };
        }
        public static CCD_M ToViewModel(content_column_design contentColumnDesign,List<SelectListItem> CTDselectItems, List<SelectListItem> DTelectItems, List<SelectListItem> PCTselectItems)
        {
            return new CCD_M()
            {
                CCD_ID = contentColumnDesign.CCD_ID,
                ColumnName = contentColumnDesign.ColumnName,
                CTD_ID = contentColumnDesign.CTD_ID,
                DefValue = contentColumnDesign.DefValue,
                DT_ID = contentColumnDesign.DT_ID,
                IsPk = contentColumnDesign.IsPk,
                PCT_ID = contentColumnDesign.PCT_ID,
                Seq = contentColumnDesign.Seq,
                CTDselectItems=CTDselectItems,
                DTelectItems=DTelectItems,
                PCTselectItems=PCTselectItems
                
            };
        }
        [Display(Name = "内容列ID")]
        [Key]
        [StringLength(50)]
        public string CCD_ID { get; set; }
        [Display(Name = "内容表ID")]
        [StringLength(50)]
        public string CTD_ID { get; set; }
        [Display(Name = "数据类型ID")]
        [StringLength(20)]
        public string DT_ID { get; set; }
        [Display(Name = "控件ID")]
        [StringLength(50)]
        public string PCT_ID { get; set; }
        [Display(Name = "内容列名字")]
        [StringLength(50)]
        public string ColumnName { get; set; }
        [Display(Name = "内容列排序")]
        [StringLength(50)]
        public string Seq { get; set; }
        [Display(Name = "是否主键")]
        [StringLength(50)]
        public string IsPk { get; set; }
        [Display(Name = "默认值")]
        [StringLength(50)]
        public string DefValue { get; set; }
        public List<SelectListItem> CTDselectItems;
        public List<SelectListItem> DTelectItems;
        public List<SelectListItem> PCTselectItems;
    }
}