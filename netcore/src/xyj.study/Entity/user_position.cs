
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class user_position
        {

        public user_position()
        {
            
         }

           
[Key]
public string user_position_id { get; set; }


public string orgnization_position_id { get; set; }


public string user_id { get; set; }


           
public virtual orgnization_position orgnization_position { get; set; }
public virtual permission_user permission_user { get; set; }  

             
        }
    }