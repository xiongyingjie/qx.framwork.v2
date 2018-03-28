using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Tools.Annotations;
using Qx.Tools.Models;

namespace xyj.tool.Models
{
 
    public class FormColumSetting : ColumSetting
    {
        public FormColumSetting()
        {
            FormTables = new List<string>();
        }

        [CategoryAttribute("表单配置"),
        ReadOnlyAttribute(false),
        DescriptionAttribute("控件类型")]
        public FormControlType ControlType { get; set; }

        [CategoryAttribute("表单配置"),
       ReadOnlyAttribute(false),
       DescriptionAttribute("正则式")]
        public string Regex { get; set; }
        [CategoryAttribute("表单配置"),
      ReadOnlyAttribute(false),
      DescriptionAttribute("详情页控件类型")]
        public FormControlType ShowControlType { get; set; }
        [CategoryAttribute("其他"),
    ReadOnlyAttribute(true),
    DescriptionAttribute("所有表")]
        public List<string> FormTables { get; set; }
        [CategoryAttribute("其他"),
 ReadOnlyAttribute(true),
 DescriptionAttribute("字段加前缀")]
        public bool HasPre { get; set; }
     

        public void AddTable(string tableName)
        {
            if (!FormTables.Contains(tableName))
            {
                FormTables.Add(tableName);
            }
        }
    }
}
