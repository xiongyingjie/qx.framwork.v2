using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Contents.Entity;
using System.Web.Mvc;

namespace Web.Areas.Contents.ViewModels
{
    public class CTD_M
    {
        public content_table_design ToModel()
        {
            return new content_table_design() { CT_ID= CT_ID, CTD_ID=CTD_ID, TableName=TableName };
        }
        public static CTD_M ToViewModel(List<SelectListItem> CTDselectItems)
        {
            return new CTD_M() { CTDselectItems = CTDselectItems };
        }
        public static CTD_M ToViewModel(List<SelectListItem> CTselectItems,string CT_ID)
        {
            return new CTD_M() {  CTselectItems=CTselectItems, CT_ID = CT_ID };
        }
        public static CTD_M ToViewModel(List<SelectListItem> CTselectItems, string CT_ID,string name)
        {
            return new CTD_M() { CTDselectItems=CTselectItems,CT_ID=CT_ID,typename=name};
        }
        public static CTD_M ToViewModel(content_table_design contentTableDesign, List<SelectListItem> CTselectItems)
        {
            return new CTD_M()
            {
                CT_ID = contentTableDesign.CT_ID,
                CTD_ID = contentTableDesign.CTD_ID,
                TableName = contentTableDesign.TableName,
                CTselectItems = CTselectItems,
                typename=contentTableDesign.content_type.TypeName
            };
        }
        public string typename { get; set; }
        [Display(Name = "内容表ID")]
        [Key]
        [StringLength(50)]
        public string CTD_ID { get; set; }
        [Display(Name = "内容分类ID")]
        [StringLength(50)]
        public string CT_ID { get; set; }
        [Display(Name = "内容表名字")]
        [StringLength(50)]
        public string TableName { get; set; }

        public List<SelectListItem> CTselectItems;
        public List<SelectListItem> CTDselectItems;
    }
}