using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTool.Models
{
 
    public class FormColumSetting : ColumSetting
    {
        [CategoryAttribute("表单配置"),
        ReadOnlyAttribute(false),
        DescriptionAttribute("控件类型")]
        public ControlTypeEnum ControlType { get; set; }

        [CategoryAttribute("表单配置"),
       ReadOnlyAttribute(false),
       DescriptionAttribute("正则式")]
        public string Regex { get; set; }


    }
}
