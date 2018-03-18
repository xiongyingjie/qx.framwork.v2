
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class metting_order
        {

        public metting_order()
        {
            
         }

           
[Key]
public string metting_order_id { get; set; }


public string uid { get; set; }


public DateTime? time { get; set; }


public string metting_order_time_span_id { get; set; }


public string metting_room_id { get; set; }


public string note { get; set; }


public string metting_order_state_id { get; set; }


public string name { get; set; }


public string person_num { get; set; }


public string phone { get; set; }


           
public virtual metting_order_time_span metting_order_time_span { get; set; }
public virtual metting_room metting_room { get; set; }
public virtual metting_order_state metting_order_state { get; set; }  

             
        }
    }