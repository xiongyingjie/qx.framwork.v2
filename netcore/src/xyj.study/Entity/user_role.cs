
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class user_role
        {

        public user_role()
        {
            
         }

           
[Key]
public string user_role_id { get; set; }


public string user_id { get; set; }


public string role_id { get; set; }


public string note { get; set; }


public DateTime? expire_time { get; set; }


           
public virtual permission_user permission_user { get; set; }
public virtual role role { get; set; }  

             
        }
    }