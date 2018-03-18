
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class menu
        {

        public menu()
        {
            
buttons = new HashSet<button>();
role_menus = new HashSet<role_menu>();
         }

           
[Key]
public string menu_id { get; set; }


public string name { get; set; }


public string farther_id { get; set; }


public string note { get; set; }


public string url { get; set; }


public string depth { get; set; }


public int sequence { get; set; }


public string sub_system { get; set; }


public string status { get; set; }


public string controller { get; set; }


public string action { get; set; }


public string area { get; set; }


public string image_class { get; set; }


public string active_li { get; set; }


             

           
public virtual ICollection<button> buttons { get; set; }
public virtual ICollection<role_menu> role_menus { get; set; }  
        }
    }