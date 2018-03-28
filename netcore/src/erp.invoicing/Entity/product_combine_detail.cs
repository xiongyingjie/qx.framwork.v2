
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class product_combine_detail
        {

        public product_combine_detail()
        {
            
         }

           

public string product_combine_id { get; set; }


public string child_id { get; set; }


public int child_num { get; set; }

[Key]
public string product_combine_detail_id { get; set; }


           
public virtual product_combine product_combine { get; set; }  

             
        }
    }