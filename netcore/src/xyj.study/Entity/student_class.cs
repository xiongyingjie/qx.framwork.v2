
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class student_class
        {

        public student_class()
        {
            
         }

           

public string class_id { get; set; }

[Key]
public string stu_no { get; set; }


           
public virtual Class Class { get; set; }
public virtual student student { get; set; }  

             
        }
    }