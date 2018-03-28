
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class sell_order
        {

        public sell_order()
        {
            
         }

           
[Key]
public string sell_order_id { get; set; }


public string customer_id { get; set; }


           
public virtual customer customer { get; set; }  

             
        }
    }