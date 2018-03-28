using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyj.tool.Models
{
 
    public class ReportColumSetting : ColumSetting
    {
        [CategoryAttribute("报表配置"),
        ReadOnlyAttribute(false),
        DescriptionAttribute("查询条件")]
        public QueryTypeEnum QuerType { get; set; }

        

    }
}
