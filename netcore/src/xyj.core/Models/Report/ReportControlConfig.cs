using System.Collections.Generic;

namespace xyj.core.Models.Report
{


   

    public class ReportControlConfig: BaseControlConfig
    {
        public ReportControlConfig(string lable, string id, string name, string value, FormControlType type, string crossWidth, List<DropDownListItem> items, int sequence)
            : base(lable, id, name, value, type, crossWidth, items, sequence)
        {
        }

        public ReportControlConfig(string lable, string id, string value, FormControlType type, int sequence) : base(lable, id, value, type, sequence)
        {
        }

        public ReportControlConfig(string lable, string id, string value, int sequence) : base(lable, id, value, sequence)
        {
        }

        public ReportControlConfig(string lable, string id, string value, List<DropDownListItem> items, int sequence) : base(lable, id, value, items, sequence)
        {
        }
    }
}