
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class product
        {

        public product()
        {
            
org_storage_products = new HashSet<org_storage_product>();
product_extent_attr_values = new HashSet<product_extent_attr_value>();
         }

           

public int? is_service { get; set; }


public string produce_place { get; set; }


public double batch_out_price { get; set; }


public string thumbnail { get; set; }


public string brand_id { get; set; }


public string detail { get; set; }


public string pinyin_code { get; set; }


public string product_unit_id { get; set; }


public string product_type_id { get; set; }


public double in_price { get; set; }


public string satatus { get; set; }


public string main_code { get; set; }

[Key]
public string product_id { get; set; }


public string category_id { get; set; }


public double out_price { get; set; }


public string provider_id { get; set; }


public string name { get; set; }


public string lockor { get; set; }


           
public virtual brand brand { get; set; }
public virtual product_unit product_unit { get; set; }
public virtual product_type product_type { get; set; }
public virtual category category { get; set; }
public virtual provider provider { get; set; }  

           
public virtual ICollection<org_storage_product> org_storage_products { get; set; }
public virtual ICollection<product_extent_attr_value> product_extent_attr_values { get; set; }  
        }
    }