
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class role_group_relation
        {

        public role_group_relation()
        {
            
         }

           
[Key]
public string role_group_relation_id { get; set; }


public string role_group_id { get; set; }


public string role_id { get; set; }


public string role_name { get; set; }


public string create_userid { get; set; }


public string create_username { get; set; }


public string create_Date { get; set; }


           
public virtual role_group role_group { get; set; }
public virtual role role { get; set; }  

             
        }
    }