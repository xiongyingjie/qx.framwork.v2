
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class sub_system_reg
        {

        public sub_system_reg()
        {
            
permission_users = new HashSet<permission_user>();
         }

           
[Key]
public string sub_system_reg_id { get; set; }


public string sub_system_id { get; set; }


public string site { get; set; }


public string user_id { get; set; }


public DateTime reg_time { get; set; }


public string note { get; set; }


           
public virtual sub_system sub_system { get; set; }  

           
public virtual ICollection<permission_user> permission_users { get; set; }  
        }
    }