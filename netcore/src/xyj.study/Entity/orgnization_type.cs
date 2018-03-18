
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class orgnization_type
        {

        public orgnization_type()
        {
            
orgnizations = new HashSet<orgnization>();
         }

           
[Key]
public string orgnization_type_id { get; set; }


public string name { get; set; }


public string note { get; set; }


             

           
public virtual ICollection<orgnization> orgnizations { get; set; }  
        }
    }