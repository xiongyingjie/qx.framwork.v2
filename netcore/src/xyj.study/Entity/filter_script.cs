
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class filter_script
        {

        public filter_script()
        {
            
data_filters = new HashSet<data_filter>();
         }

           
[Key]
public string filter_script_id { get; set; }


public string name { get; set; }


public string script { get; set; }


public string note { get; set; }


public int link_count { get; set; }


public DateTime? create_time { get; set; }


             

           
public virtual ICollection<data_filter> data_filters { get; set; }  
        }
    }