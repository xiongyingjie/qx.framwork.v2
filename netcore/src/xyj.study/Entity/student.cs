
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class student
        {

        public student()
        {
            
student_classs = new HashSet<student_class>();
medicare_cards = new HashSet<medicare_card>();
         }

           
[Key]
public string stu_no { get; set; }


public string name { get; set; }


public string degree { get; set; }


public string specialty { get; set; }


public string major { get; set; }


public string phone { get; set; }


public string wx { get; set; }


public string dormitory { get; set; }


public string lab { get; set; }


public string teacher { get; set; }


             

           
public virtual ICollection<student_class> student_classs { get; set; }
public virtual ICollection<medicare_card> medicare_cards { get; set; }  
        }
    }