
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class role_group
        {

        public role_group()
        {
            
role_group_relations = new HashSet<role_group_relation>();
user_group_role_group_relations = new HashSet<user_group_role_group_relation>();
         }

           
[Key]
public string role_group_id { get; set; }


public string role_group_name { get; set; }


public string father_id { get; set; }


             

           
public virtual ICollection<role_group_relation> role_group_relations { get; set; }
public virtual ICollection<user_group_role_group_relation> user_group_role_group_relations { get; set; }  
        }
    }