using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Contents.Entity;

namespace Web.Areas.Contents.ViewModels
{
    public class ContentType_M
    {
        public content_type ToModel()
        {
            return new content_type() { CT_ID = CT_ID,TypeName = TypeName,FatherID = FatherID};
        }
        public static ContentType_M ToViewModel(string fatherid)
        {
            return new ContentType_M() { FatherID=fatherid};
        }
        public static ContentType_M ToViewModel(content_type model)
        {
            return new ContentType_M() { CT_ID = model.CT_ID, TypeName = model.TypeName,FatherID = model.FatherID};
        }
        [Display(Name = "内容类型ID")]
        [Key]
        [StringLength(50)]
        public string CT_ID { get; set; }
        [Display(Name = "内容类型名称")]
        [StringLength(50)]
        public string TypeName { get; set; }
        [Display(Name = "父ID")]
        [StringLength(50)]
        public string FatherID { get; set; }
    }
}