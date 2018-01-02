using System;

namespace xyj.core.Models.Report
{
    public class DataFilter
    {
        public string data_filter_id { get; set; }

        public int seq { get; set; }
        public string role_id { get; set; }
        public string role_name { get; set; }

        public string report_id { get; set; }

        public string note { get; set; }

        public string filter_script { get; set; }

        public DateTime? expire_time { get; set; }
    }
}
