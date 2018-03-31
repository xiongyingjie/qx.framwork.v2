using System.Collections.Generic;
using xyj.core.Extensions;

namespace xyj.core.Models.Report
{

    public class ReportViewModel
    {

        public ReportViewModel()
        {
            this.report = new ReportModel();
            this.pageParam = new PageParam();
            this.header = new List<string>();
            header_all = new List<string>();
            this.tableBody = new List<List<string>>();
            tableBody_all = new List<List<string>>();
            this.operatCol = operatCol;
            FinalView = new List<List<string>>();
            DataFilter = new List<DataFilter>();
        }

        /// <summary>
        /// 报表配置
        /// </summary>
        public ReportModel report { get; set; }

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

        /// <summary>
        /// 最终视图
        /// </summary>
        public string FinalJson
        {
            get
            {
                return tableBody_all.ToJsonString(header_all.DealDuplicate());
            }
        }


        public List<DataFilter> DataFilter { get; set; }

        /// <summary>
        /// 是最后一页
        /// </summary>
        public bool isLastPage
        {
            get { return tableBody.Count == pageParam.perPage; }
        }

        public int TotalCount { get; internal set; }

        public ReportViewModel SetPageParam(int pageIndex, int perCount, string filterScript,string finalSql)
        {
            report.FinalSqlStr = finalSql;
            pageParam.pageIndex = pageIndex;
            pageParam.perPage = perCount;
            pageParam.title = report.ReportName;
            pageParam.maxIndex = 999;
            pageParam.filter_script = filterScript;
            return this;
        }
    }
}
