using System;
using System.Collections.Generic;
using System.Linq;
using Qx.WorkFlow.Entity;

namespace Qx.WorkFlow.Models
{
    public class ToDoMsg
    {
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public string Note { get; set; }
        public string Url { get; set; }
        public string CurrentId { get; set; }
        public IEnumerable<Node> AllNode { get; set; }
        public IEnumerable<NodeRelation> AllRelation { get; set; }
        public IEnumerable<InstanceChangeLog> PathHistory { get; set; }

        public double Progress
        {
            get
            {
              
                return (0.0+PathHistory .Count()/ AllRelation.Count())*100;
            }
        }
    }
}