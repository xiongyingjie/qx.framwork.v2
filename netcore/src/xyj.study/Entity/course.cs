
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class course
        {

        public course()
        {
            
class_courses = new HashSet<class_course>();
         }

           
[Key]
public string course_id { get; set; }


public string name { get; set; }


public string teacher { get; set; }


public string class_room { get; set; }


public float credit { get; set; }


public string type { get; set; }


public string note { get; set; }


             

           
public virtual ICollection<class_course> class_courses { get; set; }  
        }
    }