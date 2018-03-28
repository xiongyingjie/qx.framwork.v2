
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class product_unit
        {

        public product_unit()
        {
            
products = new HashSet<product>();
         }

           

public string name { get; set; }

[Key]
public string product_unit_id { get; set; }


             

           
public virtual ICollection<product> products { get; set; }  
        }
    }