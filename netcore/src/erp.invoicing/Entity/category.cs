
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class category
        {

        public category()
        {
            
category_attrs = new HashSet<category_attr>();
products = new HashSet<product>();
         }

           

public int? status { get; set; }

[Key]
public string category_id { get; set; }


public string name { get; set; }


public string note { get; set; }


             

           
public virtual ICollection<category_attr> category_attrs { get; set; }
public virtual ICollection<product> products { get; set; }  
        }
    }