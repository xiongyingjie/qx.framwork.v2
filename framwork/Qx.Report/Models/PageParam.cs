using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Report.Models
{
    public class PageParam
    {
        /// <summary>
        /// 
        /// </summary>
        public int pageIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int perPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int maxIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currentUrl { get; set; }
        /// <summary>
        /// 测试
        /// </summary>
        public string title { get; set; }
    }
}
