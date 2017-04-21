using System.Collections.Generic;
using qx.permmision.v2.Entity;

namespace qx.permmision.v2.Models
{
    public class MenuItem
    {
        public bool Selected { get; set; }
        public menu Father { get; set; }
        public List<menu> Children { get; set; }
       

      
    }
    
}