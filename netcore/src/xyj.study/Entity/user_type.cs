
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class user_type
        {

        public user_type()
        {
            
permission_users = new HashSet<permission_user>();
         }

           
[Key]
public string user_type_id { get; set; }


public string name { get; set; }


             

           
public virtual ICollection<permission_user> permission_users { get; set; }  
        }
    }