using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Contents.Entity;

namespace Web.Areas.Contents.ViewModels
{
    public class CCV_M
    {
        public content_column_value ToModel()
        {
            return new content_column_value()
            {
                CCD_ID = CCD_ID,
                CCV_ID = CCV_ID,
                ColumnValue = ColumnValue,
                RelationKeyValue = RelationKeyValue
            };
        }
        public static CCV_M ToViewModel(string tableid)
        {
            return new ViewModels.CCV_M() { CTD_ID = tableid };
        }
        public static CCV_M ToViewModel(List<SelectListItem> ColumnNameselectItems, string id)
        {
            return new CCV_M() { ColumnNameselectItems = ColumnNameselectItems, CTD_ID = id };
        }
        public static CCV_M ToViewModel(List<SelectListItem> ColumnNameselectItems)
        {
            return new CCV_M() { ColumnNameselectItems = ColumnNameselectItems };
        }

        public static CCV_M ToViewModel(content_column_value model,List<SelectListItem> ColumnNameselectItems)
        {
            return new CCV_M() { ColumnNameselectItems = ColumnNameselectItems, CCD_ID=model.CCD_ID, CCV_ID=model.CCV_ID, ColumnValue=model.ColumnValue, RelationKeyValue=model.RelationKeyValue };
        }
        [Display(Name = "内容列值ID")]
        [Key]
        [StringLength(50)]
        public string CCV_ID { get; set; }
        [Display(Name = "内容列ID")]
        [Required]
        [StringLength(50)]
        public string CCD_ID { get; set; }
        [Display(Name = "内容列值")]
        [StringLength(150)]
        public string ColumnValue { get; set; }
        [Display(Name = "联系键的值")]
        [StringLength(50)]
        public string RelationKeyValue { get; set; }

        public string CTD_ID { get; set; }

        public List<SelectListItem> ColumnNameselectItems;
    }
}