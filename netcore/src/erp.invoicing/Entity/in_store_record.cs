
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class in_store_record
        {

        public in_store_record()
        {
            
         }

           

public string in_store_order_item_id { get; set; }


public string org_storage_id { get; set; }


public string creator { get; set; }


public DateTime? create_time { get; set; }

[Key]
public string in_store_record_id { get; set; }


public int num { get; set; }


           
public virtual in_store_order_item in_store_order_item { get; set; }
public virtual org_storage org_storage { get; set; }  

             
        }
    }