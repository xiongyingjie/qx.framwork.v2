
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class org_storage_product
        {

        public org_storage_product()
        {
            
         }

           

public int num { get; set; }


public DateTime? update_time { get; set; }


public int fixed_num { get; set; }


public string org_storage_id { get; set; }


public string product_id { get; set; }

[Key]
public string org_storage_product_id { get; set; }


           
public virtual org_storage org_storage { get; set; }
public virtual product product { get; set; }  

             
        }
    }