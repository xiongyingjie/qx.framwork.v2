
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class user_group
        {

        public user_group()
        {
            
user_group_role_group_relations = new HashSet<user_group_role_group_relation>();
user_group_relations = new HashSet<user_group_relation>();
user_group_role_relations = new HashSet<user_group_role_relation>();
         }

           
[Key]
public string user_group_id { get; set; }


public string user_group_name { get; set; }


public string father_id { get; set; }


             

           
public virtual ICollection<user_group_role_group_relation> user_group_role_group_relations { get; set; }
public virtual ICollection<user_group_relation> user_group_relations { get; set; }
public virtual ICollection<user_group_role_relation> user_group_role_relations { get; set; }  
        }
    }