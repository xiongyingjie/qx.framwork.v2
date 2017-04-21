using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTool.Models
{
    [DefaultProperty("Sequence")]
    public class ColumSetting
    {
        

        [CategoryAttribute("字段信息"),
         //DefaultValueAttribute("Error"),
         ReadOnlyAttribute(true),
         DescriptionAttribute("编号")]
        public string GUID { get; set; }


        //[CategoryAttribute("字段信息"),
        // ReadOnlyAttribute(true),
        // DescriptionAttribute("字段所属的数据库")]
        //public string DataBase { get; set; }

        [CategoryAttribute("字段信息"),
        ReadOnlyAttribute(true),
         DescriptionAttribute("字段所属数据表")]
        public string TableName{ get; set; }

        [CategoryAttribute("字段信息"),
        ReadOnlyAttribute(true),
        DescriptionAttribute("字段所属数据库")]
        public string ColumName { get; set; }

        [CategoryAttribute("报表配置"),
       ReadOnlyAttribute(false),
       DescriptionAttribute("字段说明")]
        public string ColumNote { get; set; }


        [CategoryAttribute("报表配置"),
        ReadOnlyAttribute(false),
         DescriptionAttribute("是否显示")]
        public bool IsHidden { get; set; }

       [CategoryAttribute("报表配置"),
       ReadOnlyAttribute(false),
       DescriptionAttribute("显示顺序")]
        public string Sequence { get; set; }
    }
}
