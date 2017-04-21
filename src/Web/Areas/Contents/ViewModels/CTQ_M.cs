using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Contents.Entity;
using System.Web.Mvc;

namespace Web.Areas.Contents.ViewModels
{
    public class CTQ_M
    {
        public content_table_query ToModel()
        {
            return new content_table_query() { CTD_ID=CTD_ID, CTQ_ID=CTQ_ID, SqlQuery=SqlQuery};
        }
        public static CTQ_M ToViewModel(List<SelectListItem> CTDselectItems)
        {
            return new CTQ_M() {CTDselectItems = CTDselectItems };
        }
        public static CTQ_M ToViewModel(content_table_query contentTableQuery, List<SelectListItem> CTDselectItems)
        {
            return new CTQ_M() { SqlQuery = contentTableQuery.SqlQuery, CTQ_ID = contentTableQuery.CTQ_ID, CTD_ID = contentTableQuery.CTD_ID, CTDselectItems=CTDselectItems };
        }
        [Display(Name = "内容表查询ID")]
        [Key]
        [StringLength(50)]
        public string CTQ_ID { get; set; }
        [Display(Name = "内容表ID")]
        [StringLength(50)]
        public string CTD_ID { get; set; }
        [Display(Name = "内容表查询脚本")]
        [StringLength(50)]
        public string SqlQuery { get; set; }

        public List<SelectListItem> CTDselectItems;

    }
}