using System.Collections.Generic;
using Qx.Permission.Entity;

namespace Qx.Permission.Models
{
    public class MenuItem
    {
        public bool Selected { get; set; }
        public menu Father { get; set; }
        public List<menu> Children { get; set; }
       

      
    }
    
}