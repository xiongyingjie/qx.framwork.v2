
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class sub_system_data_log
        {

        public sub_system_data_log()
        {
            
         }

           
[Key]
public string sub_system_data_log_id { get; set; }


public string sub_system_data_id { get; set; }


public string old_data_value { get; set; }


public DateTime change_time { get; set; }


           
public virtual sub_system_data sub_system_data { get; set; }  

             
        }
    }