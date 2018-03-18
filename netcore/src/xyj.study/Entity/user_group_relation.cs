
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class user_group_relation
        {

        public user_group_relation()
        {
            
         }

           
[Key]
public string user_group_relation_id { get; set; }


public string user_id { get; set; }


public string nick_name { get; set; }


public string user_group_id { get; set; }


public string create_user_id { get; set; }


public string create_user_name { get; set; }


public string create_date { get; set; }


           
public virtual permission_user permission_user { get; set; }
public virtual user_group user_group { get; set; }  

             
        }
    }