
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class org_storage
        {

        public org_storage()
        {
            
in_store_records = new HashSet<in_store_record>();
org_storage_products = new HashSet<org_storage_product>();
         }

           
[Key]
public string org_storage_id { get; set; }


public string email { get; set; }


public string address { get; set; }


public string contactor { get; set; }


public string name { get; set; }


public string phone { get; set; }


public string note { get; set; }


public string capacity { get; set; }


public string org_id { get; set; }


             

           
public virtual ICollection<in_store_record> in_store_records { get; set; }
public virtual ICollection<org_storage_product> org_storage_products { get; set; }  
        }
    }