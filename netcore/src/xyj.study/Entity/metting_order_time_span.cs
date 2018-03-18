
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class metting_order_time_span
        {

        public metting_order_time_span()
        {
            
metting_orders = new HashSet<metting_order>();
         }

           
[Key]
public string metting_order_time_span_id { get; set; }


public string name { get; set; }


public string note { get; set; }


             

           
public virtual ICollection<metting_order> metting_orders { get; set; }  
        }
    }