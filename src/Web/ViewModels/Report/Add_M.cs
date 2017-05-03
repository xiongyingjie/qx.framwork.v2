using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Tools.Models.Report;
namespace Web.ViewModels.Report
{
    public class Add_M
    {
        public ReportModel ToModel()
        {
            return new ReportModel() { ReportID= ReportID,ReportName=ReportName, SqlStr=SqlStr, ColunmToShow=ColunmToShow,
             HeadFields=HeadFields, OperateColum=OperateColum, ParaNames=ParaNames, RecordsPerPage=RecordsPerPage};
        }
        [Display(Name = "编号ID")]
        [Required]
        public string ReportID { get; set; }
        [Display(Name = "名称")]
        [Required]
        public string ReportName { get; set; }
        [Display(Name = "Sql脚本")]
        [Required]
        public string SqlStr { get; set; }
        [Display(Name = "标题集")]
        [Required]
        public string HeadFields { get; set; }
        [Display(Name = "每页显示条数")]
        [Required]
        public int RecordsPerPage { get; set; }
        [Display(Name = "Sql参数说明")]
        [Required]
        public string ParaNames { get; set; }
        [Display(Name = "要显示的列索引集")]
        [Required]
        public string ColunmToShow { get; set; }
        [Display(Name = "操作列规则")]
        [Required]
        public string OperateColum { get; set; }

    }
}