
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class in_store_order_item
        {

        public in_store_order_item()
        {
            
in_store_records = new HashSet<in_store_record>();
         }

           

public int total_num { get; set; }


public string invoicing_order_id { get; set; }


public double? total_pay_price { get; set; }


public double? discount { get; set; }


public double? price { get; set; }


public double? reduced_price { get; set; }


public string product_id { get; set; }

[Key]
public string in_store_order_item_id { get; set; }


public int dealed_num { get; set; }


           
public virtual invoicing_order invoicing_order { get; set; }  

           
public virtual ICollection<in_store_record> in_store_records { get; set; }  
        }
    }