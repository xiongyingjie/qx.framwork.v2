
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class Class
        {

        public Class()
        {
            
student_classs = new HashSet<student_class>();
class_courses = new HashSet<class_course>();
         }

           
[Key]
public string class_id { get; set; }


public string name { get; set; }


public string note { get; set; }


             

           
public virtual ICollection<student_class> student_classs { get; set; }
public virtual ICollection<class_course> class_courses { get; set; }  
        }
    }