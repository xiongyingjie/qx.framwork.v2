using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Tools.Annotations;
using Qx.Tools.Models;

namespace CodeTool.Models
{
 
    public class FormReportColumSetting  : ColumSetting
    {

        [CategoryAttribute("报表配置"),
     ReadOnlyAttribute(false),
     DescriptionAttribute("查询条件")]
        public QueryTypeEnum QuerType { get; set; }

        [CategoryAttribute("仓储类配置"),
          ReadOnlyAttribute(false),
          DescriptionAttribute("是下拉项")]
        public bool IsSelectItem { get; set; }

        [CategoryAttribute("表单配置"),
       ReadOnlyAttribute(false),
       DescriptionAttribute("控件类型")]
        public FormControlType ControlType { get; set; }

        [CategoryAttribute("表单配置"),
       ReadOnlyAttribute(false),
       DescriptionAttribute("正则式")]
        public string Regex { get; set; }
    }
}
