
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class permission_user
        {

        public permission_user()
        {
            
user_orgnizations = new HashSet<user_orgnization>();
user_roles = new HashSet<user_role>();
user_group_relations = new HashSet<user_group_relation>();
user_positions = new HashSet<user_position>();
         }

           
[Key]
public string user_id { get; set; }


public string nick_name { get; set; }


public string user_pwd { get; set; }


public string email { get; set; }


public string phone { get; set; }


public string user_type_id { get; set; }


public string note { get; set; }


public DateTime? register_date { get; set; }


public DateTime? last_login_date { get; set; }


public string sub_system_reg_id { get; set; }


           
public virtual user_type user_type { get; set; }
public virtual sub_system_reg sub_system_reg { get; set; }  

           
public virtual ICollection<user_orgnization> user_orgnizations { get; set; }
public virtual ICollection<user_role> user_roles { get; set; }
public virtual ICollection<user_group_relation> user_group_relations { get; set; }
public virtual ICollection<user_position> user_positions { get; set; }  
        }
    }