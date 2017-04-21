using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Tools.CommonExtendMethods;
using Qx.WorkFlow.Entity;
using Qx.WorkFlow.Models;

namespace Qx.WorkFlow.Interfaces
{
  public static class WorkFlowExtensions
    {

        public static bool MoveToNext(this WorkFlowBag bag,string nextNodeId, string operatorId,string reason)
        {
            var Db = new MyDbContext();
            var log = new WorkFlowInstanceLog()
            {
                WorkFlowInstanceLogId = bag.Instance.WorkFlowInstanceID + "-" + bag.Instance.CurrentNodeID + "-" + nextNodeId,
                WorkFlowInstanceID = bag.Instance.WorkFlowInstanceID,
                FromNodeID = bag.Instance.CurrentNodeID,
                ToNodeID = nextNodeId,
                Operator = operatorId,
                ChangeTime = DateTime.Now,
                Reason = reason,
                Note = DateTime.Now + operatorId + "将" +
                        bag.Instance.WorkFlow.Name +
                        "(" + bag.Instance.WorkFlowInstanceID + ")从" +
                        bag.Instance.CurrentNodeID + "设置为" + nextNodeId + "理由为：" + reason
            };

            bag.Move(nextNodeId);

            Db.WorkFlowInstances.AddOrUpdate(bag.Instance);
            Db.WorkFlowInstanceLogs.AddOrUpdate(log);
            return Db.SaveChanges() > 0;
        }
        public static List<WorkFlowPath> NextStepInfo(this WorkFlowBag bag)
        {
            var Db = new MyDbContext();
            return Db.NodeRelations.Where(a=>a.NodeID==bag.Instance.CurrentNodeID).
                SelectMany(z => z.ConvertConditions).
                ToList().
                GroupBy(a => a.NodeRelationID).
                Select(g =>
                    new WorkFlowPath(g.Key, g.AsEnumerable().ToList())).ToList();
        }
        
    }
}
