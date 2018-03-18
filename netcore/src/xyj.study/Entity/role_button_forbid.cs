
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class role_button_forbid
        {

        public role_button_forbid()
        {
            
         }

           
[Key]
public string role_Button_forbid_id { get; set; }


public string role_id { get; set; }


public string button_id { get; set; }


public DateTime? expire_time { get; set; }


public string note { get; set; }


           
public virtual role role { get; set; }
public virtual button button { get; set; }  

             
        }
    }