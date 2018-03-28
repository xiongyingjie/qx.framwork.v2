
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class category_attr_type
        {

        public category_attr_type()
        {
            
category_attrs = new HashSet<category_attr>();
         }

           

public string Name { get; set; }

[Key]
public string category_attr_type_id { get; set; }


             

           
public virtual ICollection<category_attr> category_attrs { get; set; }  
        }
    }