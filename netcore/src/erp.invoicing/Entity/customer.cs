
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace erp.invoicing.Entity
{  
        public partial class customer
        {

        public customer()
        {
            
sell_orders = new HashSet<sell_order>();
         }

           

public string credit_limit { get; set; }


public string name { get; set; }


public string tickect_type { get; set; }


public string area { get; set; }


public string bank { get; set; }


public int? checkout_day { get; set; }


public string email { get; set; }


public string checkout_method { get; set; }


public string charge_account_batch { get; set; }


public string phone { get; set; }


public string contactor { get; set; }


public string customer_type { get; set; }


public int? is_lock { get; set; }


public string stop_intercourse { get; set; }

[Key]
public string customer_id { get; set; }


public int? status { get; set; }


public string tax_no { get; set; }


public string bank_no { get; set; }


public string price_level { get; set; }


public string note2 { get; set; }


public string address { get; set; }


public string checkout_period { get; set; }


public string zip_code { get; set; }


public string fax { get; set; }


public string salesman { get; set; }


public string pinyin { get; set; }


public string note1 { get; set; }


             

           
public virtual ICollection<sell_order> sell_orders { get; set; }  
        }
    }