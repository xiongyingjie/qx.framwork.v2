
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class medicare_card
        {

        public medicare_card()
        {
            
         }

           
[Key]
public string stu_no { get; set; }


public string card_state { get; set; }


           
public virtual student student { get; set; }  

             
        }
    }