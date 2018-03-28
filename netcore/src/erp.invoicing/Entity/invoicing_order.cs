
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class invoicing_order
        {

        public invoicing_order()
        {
            
pay_records = new HashSet<pay_record>();
in_store_order_items = new HashSet<in_store_order_item>();
         }

           

public string note { get; set; }


public string creator { get; set; }


public double? total_payed_price { get; set; }


public string excutor { get; set; }


public string bllor { get; set; }


public string invoicing_order_state_id { get; set; }

[Key]
public string invoicing_order_id { get; set; }


public double? total_pay_price { get; set; }


public DateTime? check_time { get; set; }


public DateTime create_time { get; set; }


public DateTime? total_pay_time { get; set; }


public DateTime? finish_time { get; set; }


public double? total_reduced_price { get; set; }


public string invoicing_order_type_id { get; set; }


public string checkor { get; set; }


           
public virtual invoicing_order_state invoicing_order_state { get; set; }
public virtual invoicing_order_type invoicing_order_type { get; set; }  

           
public virtual ICollection<pay_record> pay_records { get; set; }
public virtual ICollection<in_store_order_item> in_store_order_items { get; set; }  
        }
    }