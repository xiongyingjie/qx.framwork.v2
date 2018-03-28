using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyj.tool.Models
{
    [DefaultProperty("Sequence")]
    public class ColumSetting
    {
        

        [CategoryAttribute("字段信息"),
         ReadOnlyAttribute(true),
         DescriptionAttribute("编号")]
        public string GUID { get; set; }

        
        [CategoryAttribute("字段信息"),
        ReadOnlyAttribute(true),
         DescriptionAttribute("字段所属数据表")]
        public string TableName{ get; set; }

        [CategoryAttribute("字段信息"),
       ReadOnlyAttribute(true),
        DescriptionAttribute("数据类型")]
        public string Type { get; set; }


        [CategoryAttribute("字段信息"),
       ReadOnlyAttribute(true),
        DescriptionAttribute("长度")]
        public string Length { get; set; }


        [CategoryAttribute("字段信息"),
     ReadOnlyAttribute(true),
      DescriptionAttribute("可为空")]
        public bool CanNull { get; set; }

        [CategoryAttribute("字段信息"),
       ReadOnlyAttribute(true),
     DescriptionAttribute("默认值")]
        public string DefaultValue { get; set; }

        [CategoryAttribute("字段信息"),
           ReadOnlyAttribute(true),
         DescriptionAttribute("外键列")]
        public string ForeignKey { get; set; }

        [CategoryAttribute("字段信息"),
        ReadOnlyAttribute(true),
        DescriptionAttribute("外键表")]
        public string ForeignTable { get; set; }

        [CategoryAttribute("字段信息"),
        ReadOnlyAttribute(true),
        DescriptionAttribute("字段所属数据库")]
        public string ColumName { get; set; }


       [CategoryAttribute("字段信息"),
       ReadOnlyAttribute(true),
       DescriptionAttribute("是主键")]
        public bool IsPrimaryKey { get; set; }

        [CategoryAttribute("字段信息"),
       ReadOnlyAttribute(false),
       DescriptionAttribute("字段说明")]
        public string ColumNote { get; set; }


        [CategoryAttribute("基本配置"),
        ReadOnlyAttribute(false),
         DescriptionAttribute("是否显示")]
        public bool IsHidden { get; set; }

       [CategoryAttribute("基本配置"),
       ReadOnlyAttribute(false),
       DescriptionAttribute("显示顺序")]
        public int Sequence { get; set; }

        
    }
}
