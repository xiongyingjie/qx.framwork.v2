using xyj.core.Extensions;

namespace xyj.core.Models.Form
{
   public class FormConfig 
    {
      
     
        public string form_id { get; set; }
        public string name { get; set; }
        public string columns_to_show { get; set; }
        public string columns { get; set; }
        public string displays { get; set; }
        public string control_types { get; set; }
        public string regexs { get; set; }
        public string error_tips { get; set; }
        public string input_tips { get; set; }
        public string key_info { get; set; }
        public string form_log { get; set; }



       public int Length
       {
            get { return name.UnPackString(';').Count; }
       }
     
    }
}
