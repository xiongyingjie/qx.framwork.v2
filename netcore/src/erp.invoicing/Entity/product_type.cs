
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class product_type
        {

        public product_type()
        {
            
products = new HashSet<product>();
         }

           
[Key]
public string product_type_id { get; set; }


public string father_id { get; set; }


public string note { get; set; }


public string name { get; set; }


             

           
public virtual ICollection<product> products { get; set; }  
        }
    }