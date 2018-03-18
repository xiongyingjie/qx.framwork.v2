
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class sub_system
        {

        public sub_system()
        {
            
sub_system_datas = new HashSet<sub_system_data>();
sub_system_regs = new HashSet<sub_system_reg>();
         }

           
[Key]
public string sub_system_id { get; set; }


public string name { get; set; }


public DateTime create_time { get; set; }


public string note { get; set; }


public string plateform { get; set; }


             

           
public virtual ICollection<sub_system_data> sub_system_datas { get; set; }
public virtual ICollection<sub_system_reg> sub_system_regs { get; set; }  
        }
    }