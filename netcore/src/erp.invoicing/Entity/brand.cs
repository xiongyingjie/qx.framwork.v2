
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class brand
        {

        public brand()
        {
            
products = new HashSet<product>();
         }

           

public string logo { get; set; }


public int? sequence { get; set; }


public string note { get; set; }

[Key]
public string brand_id { get; set; }


public string descripe { get; set; }


public string url { get; set; }


public string name { get; set; }


             

           
public virtual ICollection<product> products { get; set; }  
        }
    }