
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class invoicing_order_state
        {

        public invoicing_order_state()
        {
            
invoicing_orders = new HashSet<invoicing_order>();
         }

           
[Key]
public string invoicing_order_state_id { get; set; }


public string name { get; set; }


             

           
public virtual ICollection<invoicing_order> invoicing_orders { get; set; }  
        }
    }