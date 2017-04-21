using System.Collections.Generic;
using System.Linq;
using Qx.WorkFlow.Entity;

namespace Qx.WorkFlow.Models
{
    public class WorkFlowBag
    {
        public WorkFlowBag(WorkFlowInstance workFlowBag)
        {
            Instance = workFlowBag;
        }
        public WorkFlowInstance Instance;

        public WorkFlowBag Move(string nextId)
        {
            Instance.CurrentNodeID = nextId;
            return this;
        }

       
    }
}
