
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class data_filter
        {

        public data_filter()
        {
            
         }

           
[Key]
public string data_filter_id { get; set; }


public string role_id { get; set; }


public string report_id { get; set; }


public string note { get; set; }


public string filter_script_id { get; set; }


public DateTime? expire_time { get; set; }


public int seq { get; set; }


           
public virtual role role { get; set; }
public virtual filter_script filter_script { get; set; }  

             
        }
    }