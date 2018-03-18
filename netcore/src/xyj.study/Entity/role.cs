
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class role
        {

        public role()
        {
            
role_button_forbids = new HashSet<role_button_forbid>();
role_group_relations = new HashSet<role_group_relation>();
role_menus = new HashSet<role_menu>();
user_roles = new HashSet<user_role>();
data_filters = new HashSet<data_filter>();
user_group_role_relations = new HashSet<user_group_role_relation>();
         }

           
[Key]
public string role_id { get; set; }


public string name { get; set; }


public string role_type { get; set; }


public string sub_system { get; set; }


public int is_default { get; set; }


             

           
public virtual ICollection<role_button_forbid> role_button_forbids { get; set; }
public virtual ICollection<role_group_relation> role_group_relations { get; set; }
public virtual ICollection<role_menu> role_menus { get; set; }
public virtual ICollection<user_role> user_roles { get; set; }
public virtual ICollection<data_filter> data_filters { get; set; }
public virtual ICollection<user_group_role_relation> user_group_role_relations { get; set; }  
        }
    }