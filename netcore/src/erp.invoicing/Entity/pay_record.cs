
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class pay_record
        {

        public pay_record()
        {
            
         }

           

public string invoicing_order_id { get; set; }


public string pay_time { get; set; }

[Key]
public string pay_record_id { get; set; }


public double pay_num { get; set; }


           
public virtual invoicing_order invoicing_order { get; set; }  

             
        }
    }