
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class user_orgnization
        {

        public user_orgnization()
        {
            
         }

           
[Key]
public string user_orgnization_id { get; set; }


public string orgnization_id { get; set; }


public string user_id { get; set; }


           
public virtual orgnization orgnization { get; set; }
public virtual permission_user permission_user { get; set; }  

             
        }
    }