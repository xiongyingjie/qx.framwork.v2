
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class organization_relation
        {

        public organization_relation()
        {
            
         }

           
[Key]
public string organization_relation_id { get; set; }


public string orgnization_id { get; set; }


public string other_orgnization_id { get; set; }


           
public virtual orgnization orgnization { get; set; }  

             
        }
    }