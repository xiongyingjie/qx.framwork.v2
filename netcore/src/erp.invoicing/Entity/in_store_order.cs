
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class in_store_order
        {

        public in_store_order()
        {
            
         }

           

public string send_no { get; set; }


public string provider_id { get; set; }

[Key]
public string in_store_order_id { get; set; }


           
public virtual provider provider { get; set; }  

             
        }
    }