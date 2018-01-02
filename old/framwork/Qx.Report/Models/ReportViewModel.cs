using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qx.Report.Models
{

    public class ReportViewModel
    {
        /// <summary>
        /// 报表配置
        /// </summary>
        public Report report { get; set; }
        /// <summary>
        /// 页面参数
        /// </summary>
        public PageParam pageParam { get; set; }
        /// <summary>
        /// 要显示的标题
        /// </summary>
        public List<string> header { get; set; }
     
        /// <summary>
        /// 所有标题
        /// </summary>
        public List<string> header_all { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public List<List<string>> tableBody { get; set; }
     
        /// <summary>
        /// 所有内容
        /// </summary>
        public List<List<string>> tableBody_all { get; set; }
        /// <summary>
        /// 操作列
        /// </summary>
        public List<string> operatCol { get; set; }
        /// <summary>
        /// 最终视图
        /// </summary>
        public List<List<string>> FinalView { get; set; }

    }
}