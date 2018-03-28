
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class category_attr_option
        {

        public category_attr_option()
        {
            
         }

           

public string category_attr_id { get; set; }

[Key]
public string category_attr_option_id { get; set; }


public string opt_text { get; set; }


public string opt_value { get; set; }


           
public virtual category_attr category_attr { get; set; }  

             
        }
    }