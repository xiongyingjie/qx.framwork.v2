using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.WorkFlow.Entity;

namespace Qx.WorkFlow.Models
{
  public  class WorkFlowPath
  {
        public string Name { get; set; }
        public List<ConvertCondition> Conditions { get; set; }
        public string FromNodeId { get; set; }
        public string ToNodeId { get; set; }
        public WorkFlowPath(string name, List<ConvertCondition> conditions)
      {
          var realetion = conditions.FirstOrDefault().NodeRelation;
          Name = name;
          FromNodeId = realetion.NodeID;
          ToNodeId = realetion.ChildID;
          Conditions = conditions;
      }
       
    }
}
