
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class user_group_role_group_relation
        {

        public user_group_role_group_relation()
        {
            
         }

           
[Key]
public string user_group_role_group_relation_id { get; set; }


public string user_group_id { get; set; }


public string role_group_id { get; set; }


public string create_date { get; set; }


public string note { get; set; }


           
public virtual user_group user_group { get; set; }
public virtual role_group role_group { get; set; }  

             
        }
    }