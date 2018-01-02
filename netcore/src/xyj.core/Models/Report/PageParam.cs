namespace xyj.core.Models.Report
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
        public string uid { get; set; }
        public string filter_script { get; set; }
    }
}
