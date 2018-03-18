
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class role_menu
        {

        public role_menu()
        {
            
         }

           
[Key]
public string role_menu_id { get; set; }


public string role_id { get; set; }


public string menu_id { get; set; }


public string note { get; set; }


public int include_children { get; set; }


public DateTime? expire_time { get; set; }


           
public virtual role role { get; set; }
public virtual menu menu { get; set; }  

             
        }
    }