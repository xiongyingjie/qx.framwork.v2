
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xyj.study.Entity
{  
        public partial class orgnization
        {

        public orgnization()
        {
            
user_orgnizations = new HashSet<user_orgnization>();
orgnization_positions = new HashSet<orgnization_position>();
organization_relations = new HashSet<organization_relation>();
         }

           
[Key]
public string orgnization_id { get; set; }


public string father_id { get; set; }


public string name { get; set; }


public string orgnization_type_id { get; set; }


public string sub_system { get; set; }


public string organization_level_id { get; set; }


public string note { get; set; }


public string descripe { get; set; }


           
public virtual orgnization_type orgnization_type { get; set; }
public virtual organization_level organization_level { get; set; }  

           
public virtual ICollection<user_orgnization> user_orgnizations { get; set; }
public virtual ICollection<orgnization_position> orgnization_positions { get; set; }
public virtual ICollection<organization_relation> organization_relations { get; set; }  
        }
    }