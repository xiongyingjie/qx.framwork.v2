using System.Collections.Generic;
using xyj.acs.Entity;

namespace xyj.acs.Models
{
    public class MenuItem
    {
        public bool Selected { get; set; }
        public menu Father { get; set; }
        public List<menu> Children { get; set; }
       

      
    }
    
}