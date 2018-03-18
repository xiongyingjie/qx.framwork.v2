
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class sub_system_data
        {

        public sub_system_data()
        {
            
sub_system_data_logs = new HashSet<sub_system_data_log>();
         }

           
[Key]
public string sub_system_data_id { get; set; }


public string sub_system_id { get; set; }


public string data_key { get; set; }


public string data_value { get; set; }


public string model { get; set; }


public DateTime create_time { get; set; }


public string note { get; set; }


           
public virtual sub_system sub_system { get; set; }  

           
public virtual ICollection<sub_system_data_log> sub_system_data_logs { get; set; }  
        }
    }