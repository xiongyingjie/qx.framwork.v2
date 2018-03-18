
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class metting_room_state
        {

        public metting_room_state()
        {
            
metting_rooms = new HashSet<metting_room>();
         }

           
[Key]
public string metting_room_state_id { get; set; }


public string name { get; set; }


public string note { get; set; }


             

           
public virtual ICollection<metting_room> metting_rooms { get; set; }  
        }
    }