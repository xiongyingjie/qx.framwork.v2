
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class metting_room
        {

        public metting_room()
        {
            
metting_orders = new HashSet<metting_order>();
         }

           
[Key]
public string metting_room_id { get; set; }


public string name { get; set; }


public int person_limit { get; set; }


public string metting_avaluable_time_id { get; set; }


public string equipment { get; set; }


public string pic { get; set; }


public int need_check { get; set; }


public string metting_room_state_id { get; set; }


           
public virtual metting_room_state metting_room_state { get; set; }  

           
public virtual ICollection<metting_order> metting_orders { get; set; }  
        }
    }