
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class class_course
        {

        public class_course()
        {
            
         }

           
[Key]
public string student_course_id { get; set; }


public string class_id { get; set; }


public string course_id { get; set; }


public int start_week { get; set; }


public int end_week { get; set; }


public DateTime? start_time { get; set; }


public DateTime? end_time { get; set; }


           
public virtual Class Class { get; set; }
public virtual course course { get; set; }  

             
        }
    }