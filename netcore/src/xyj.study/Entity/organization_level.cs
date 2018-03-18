
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class organization_level
        {

        public organization_level()
        {
            
orgnizations = new HashSet<orgnization>();
         }

           
[Key]
public string organization_level_id { get; set; }


public string name { get; set; }


public string note { get; set; }


             

           
public virtual ICollection<orgnization> orgnizations { get; set; }  
        }
    }