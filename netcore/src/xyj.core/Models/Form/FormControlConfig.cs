using System.Collections.Generic;
using xyj.core.Models.Report;

namespace xyj.core.Models.Form
{
   public class FormControlConfig: BaseControlConfig
    {
       public FormControlConfig(string lable, string id, string name, string value, FormControlType type, string crossWidth, List<DropDownListItem> items, int sequence, string regex, string inputTip, string errorTip) : base(lable, id, name, value, type, crossWidth, items, sequence)
       {
           this.regex = regex;
           input_tip = inputTip;
           error_tip = errorTip;
       }

     
       public string regex { get; set; }
        public string input_tip { get; set; }
        public string error_tip { get; set; }
      
    }
}
