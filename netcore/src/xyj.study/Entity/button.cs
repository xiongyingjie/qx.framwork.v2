
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class button
        {

        public button()
        {
            
role_button_forbids = new HashSet<role_button_forbid>();
         }

           
[Key]
public string button_id { get; set; }


public string menu_id { get; set; }


public string name { get; set; }


public string note { get; set; }


public string value { get; set; }


           
public virtual menu menu { get; set; }  

           
public virtual ICollection<role_button_forbid> role_button_forbids { get; set; }  
        }
    }