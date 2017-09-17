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

        public static MyDbContext MoveToNext(this WorkFlowBag bag, MyDbContext db,string nextNodeId,
            string operatorId, string reason,string endNodeId)
        {
            //创建转移日志
            db.CreateInstanceChangeLog(bag.Instance, "3", operatorId, reason,nextNodeId);
            bag.Move(nextNodeId);
            db.WorkFlowInstance.AddOrUpdate(bag.Instance);
            var isFinish = endNodeId==bag.Instance.CurrentNodeID;
            //如果为结束节点
            if (isFinish)
            {
                //记录实例日志
                db.CreateInstanceHistory(bag.Instance, "2", bag.Instance.Note + "\n" + DateTime.Now + "流程已结束");
                //创建转移日志
                db.CreateInstanceChangeLog(bag.Instance, "2", "system", "[sytem]流程自动结束", null);
                //删除示例
                db.WorkFlowInstance.Remove(db.WorkFlowInstance.Find(bag.Instance.WorkFlowInstanceID));
            }
          
            return db;
        }
        public static List<WorkFlowPath> NextStepInfo(this WorkFlowBag bag)
        {
            var Db = new MyDbContext();
            return Db.NodeRelation.Where(a => a.NodeID == bag.Instance.CurrentNodeID).
                SelectMany(z => z.ConvertCondition).
                ToList().
                GroupBy(a => a.NodeRelationID).
                Select(g =>
                    new WorkFlowPath(g.Key, g.AsEnumerable().ToList())).ToList();
        }
        //创建转移日志
        public static void CreateInstanceChangeLog(this MyDbContext Db, WorkFlowInstance instance, string typeId, string operatorId, string reason,  string nextNodeId = "")
        {
            /*
WorkFlowInstanceType    
1	开始
2	结束
3	正常流转
4	终止
5	回退
        */

            Db.InstanceChangeLog.Add(new InstanceChangeLog()
            {
                InstanceChangeLogID = instance.WorkFlowInstanceID + "-" +
                instance.CurrentNodeID.Replace(instance.WorkFlow.WorkFlowID, "") +
                nextNodeId.CheckValue().Replace(instance.WorkFlow.WorkFlowID, "")+DateTime.Now.Random(),
                WorkFlowInstanceID = instance.WorkFlowInstanceID,
                FromNodeID = typeId == "1" ? null:instance.CurrentNodeID,
                ToNodeID = typeId=="1"? instance.CurrentNodeID : nextNodeId,
                Operator = operatorId,
                ChangeTime = DateTime.Now,
                Reason = reason,
                InstanceChangeLogTypeID = typeId,
                Note = DateTime.Now + operatorId + "将" +
                       instance.WorkFlow.Name +
                        "(" +instance.WorkFlowInstanceID + ")从" +
                       //instance.Node.Name+
                       "("+  instance.CurrentNodeID + ")设置为" + nextNodeId.CheckValue() + "理由为：" + reason
            });
        }
        //创建实例日志
        public static void CreateInstanceHistory(this MyDbContext Db,  WorkFlowInstance old, string typeId, string note)
        {/*
InstanceHistoryType
1	正常结束
2	终止结束
3	中途删除*/
            Db.InstanceHistory.Add(new InstanceHistory()
            {
                WorkFlowInstanceID = old.WorkFlowInstanceID,
                WorkFlowID = old.WorkFlowID,
                CreateTime = old.CreateTime,
                CurrentNodeID = old.CurrentNodeID,
                Note = note,
                InstancePeople = old.InstancePeople,
                InstanceHistoryTypeID = typeId,
                UnitID = old.UnitID
            });
        }
    }
}
