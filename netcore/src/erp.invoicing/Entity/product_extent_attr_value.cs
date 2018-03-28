
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class product_extent_attr_value
        {

        public product_extent_attr_value()
        {
            
         }

           

public string attr_value { get; set; }


public string product_id { get; set; }


public DateTime? create_time { get; set; }

[Key]
public string product_extent_attr_value_id { get; set; }


public string category_attr_id { get; set; }


           
public virtual product product { get; set; }
public virtual category_attr category_attr { get; set; }  

             
        }
    }