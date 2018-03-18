
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class orgnization_position
        {

        public orgnization_position()
        {
            
user_positions = new HashSet<user_position>();
         }

           
[Key]
public string orgnization_position_id { get; set; }


public string orgnization_id { get; set; }


public string position_id { get; set; }


           
public virtual orgnization orgnization { get; set; }
public virtual position position { get; set; }  

           
public virtual ICollection<user_position> user_positions { get; set; }  
        }
    }