using System.Collections.Generic;
using xyj.core.Extensions;
using xyj.core.Models.Report;

namespace xyj.core.Models
{

    public class BaseControlConfig
    {
        //全集
        public BaseControlConfig(string lable, string id, string name,  string value, FormControlType type,
            string crossWidth, List<DropDownListItem> items, int sequence    
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

        }
        //非下拉
        public BaseControlConfig(string lable, string id,  string value,
            FormControlType type, int sequence)
        {
            this.id = id;
            this.name = id;
            this.type = type;
            this.sequence = sequence;
            this.lable = lable;
            this.crossWidth = "1";
            this.value = value;
            this.items = new List<DropDownListItem>();
        }
        //文本框
        public BaseControlConfig(string lable, string id,string value, int sequence)
        {
            this.id = id;
            this.name = id;
            this.type = FormControlType.Input;
            this.sequence = sequence;
            this.lable = lable;
            this.crossWidth = "1";
            this.value = value;
            this.items = new List<DropDownListItem>();
        }
        //下拉
        public BaseControlConfig(string lable, string id,  string value,
            List<DropDownListItem> items, int sequence)
        {
            this.id = id;
            this.name = id;
            this.type = FormControlType.Select;
            this.sequence = sequence;
            this.lable = lable;
            this.crossWidth ="1";
            this.value = value;
            this.items = items.Format();
 
        }
        public string id { get; set; }
        public string name { get; set; }
        public FormControlType type { get; set; }
        public int sequence { get; set; }
        public string lable { get; set; }
        public string crossWidth { get; set; }
        public string value { get; set; }
        public List<DropDownListItem> items { get; set; }

    }
}