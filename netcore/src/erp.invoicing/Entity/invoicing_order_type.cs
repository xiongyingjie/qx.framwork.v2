
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class invoicing_order_type
        {

        public invoicing_order_type()
        {
            
invoicing_orders = new HashSet<invoicing_order>();
         }

           

public string name { get; set; }

[Key]
public string invoicing_order_type_id { get; set; }


             

           
public virtual ICollection<invoicing_order> invoicing_orders { get; set; }  
        }
    }