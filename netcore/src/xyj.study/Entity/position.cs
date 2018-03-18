
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class position
        {

        public position()
        {
            
orgnization_positions = new HashSet<orgnization_position>();
         }

           
[Key]
public string position_id { get; set; }


public string position_type_id { get; set; }


public string name { get; set; }


public string descripe { get; set; }


public string note { get; set; }


           
public virtual position_type position_type { get; set; }  

           
public virtual ICollection<orgnization_position> orgnization_positions { get; set; }  
        }
    }