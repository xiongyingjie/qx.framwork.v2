
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class category_attr
        {

        public category_attr()
        {
            
category_attr_options = new HashSet<category_attr_option>();
product_extent_attr_values = new HashSet<product_extent_attr_value>();
         }

           
[Key]
public string category_attr_id { get; set; }


public string category_attr_type_id { get; set; }


public int? sequence { get; set; }


public string name { get; set; }


public string category_id { get; set; }


public int? quoted { get; set; }


           
public virtual category_attr_type category_attr_type { get; set; }
public virtual category category { get; set; }  

           
public virtual ICollection<category_attr_option> category_attr_options { get; set; }
public virtual ICollection<product_extent_attr_value> product_extent_attr_values { get; set; }  
        }
    }