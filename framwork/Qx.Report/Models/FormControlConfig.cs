using System.Collections.Generic;

namespace Qx.Report.Models
{


   

    public class FormControlConfig
    {
       
        public FormControlConfig(string lable, string id, string name, int sequence, string value, FormControlType type,
            string crossWidth, List<DropDownListItem> items
            
           )
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.sequence = sequence;
            this.lable = lable;
            this.crossWidth = crossWidth;
            this.value = value;
            this.items = items;
        }
        public FormControlConfig(string lable, string id, int sequence, string value, FormControlType type )
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
        public FormControlConfig(string lable, string id, int sequence,string value)
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
        public FormControlConfig(string lable, string id, int sequence,  string value, List<DropDownListItem> items)
        {
            this.id = id;
            this.name = id;
            this.type = FormControlType.DropDownList;
            this.sequence = sequence;
            this.lable = lable;
            this.crossWidth ="1";
            this.value = value;
            this.items = items;
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