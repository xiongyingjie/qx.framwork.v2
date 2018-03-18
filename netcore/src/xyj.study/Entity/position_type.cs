
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class position_type
        {

        public position_type()
        {
            
positions = new HashSet<position>();
         }

           
[Key]
public string position_type_id { get; set; }


public string name { get; set; }


public string father_id { get; set; }


             

           
public virtual ICollection<position> positions { get; set; }  
        }
    }