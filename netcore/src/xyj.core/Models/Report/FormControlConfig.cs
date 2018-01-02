using System.Collections.Generic;
using xyj.core.Extensions;

namespace xyj.core.Models.Report
{


   

    public class FormControlConfig
    {
       
        public FormControlConfig(string lable, string id, string name,  string value, FormControlType type,
            string crossWidth, List<DropDownListItem> items, int sequence,
            string regex, string input_tip, string error_tip
           )
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.sequence = sequence;
            this.lable = lable;
            this.crossWidth = crossWidth;
            this.value = value;
            this.items = items.Format();
            this.regex = regex;
            this.input_tip = input_tip;
            this.error_tip = error_tip;
        }
        public FormControlConfig(string lable, string id,  string value,
            FormControlType type, int sequence,
            string regex, string input_tip, string error_tip)
        {
            this.id = id;
            this.name = id;
            this.type = type;
            this.sequence = sequence;
            this.lable = lable;
            this.crossWidth = "1";
            this.value = value;
            this.items = new List<DropDownListItem>();
            this.regex = regex;
            this.input_tip = input_tip;
            this.error_tip = error_tip;
        }
        public FormControlConfig(string lable, string id,string value, int sequence, 
            string regex, string input_tip, string error_tip)
        {
            this.id = id;
            this.name = id;
            this.type = FormControlType.Input;
            this.sequence = sequence;
            this.lable = lable;
            this.crossWidth = "1";
            this.value = value;
            this.items = new List<DropDownListItem>();
            this.regex = regex;
            this.input_tip = input_tip;
            this.error_tip = error_tip;
        }
        public FormControlConfig(string lable, string id,  string value,
            List<DropDownListItem> items, int sequence,
           string regex, string input_tip,string error_tip)
        {
            this.id = id;
            this.name = id;
            this.type = FormControlType.Select;
            this.sequence = sequence;
            this.lable = lable;
            this.crossWidth ="1";
            this.value = value;
            this.items = items.Format();
            this.regex = regex;
            this.input_tip = input_tip;
            this.error_tip = error_tip;
        }
        public string id { get; set; }
        public string name { get; set; }
        public FormControlType type { get; set; }
        public int sequence { get; set; }
        public string lable { get; set; }
        public string crossWidth { get; set; }
        public string value { get; set; }
        public string regex { get; set; }
        public string input_tip { get; set; }
        public string error_tip { get; set; }
        public List<DropDownListItem> items { get; set; }

    }
}