using System;
using System.Collections.Generic;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Qx.Tools.CommonExtendMethods;
using Qx.WorkFlow.Entity;
using Qx.WorkFlow.Exceptions;
using Qx.WorkFlow.Interfaces;
using Qx.WorkFlow.Models;

namespace Qx.WorkFlow.Services
{
   

    public class WorkFlowService : BaseRepository, IWorkFlowService
    {
        public List<WorkFlowBag>   FindInstances(List<string> workFlowInstanceIdArray)
        {
            return workFlowInstanceIdArray.Select(id => FindInstance(id)).ToList();
        }

        //public bool MoveManyNext(List<WorkFlowBag> workFlowBag, object moveParam, string operatorId, string reason = "未填写")
        //{
        //    var successfulList = new List<string>();
        //    workFlowBag.ForEach(item =>
        //    {
        //        if (!_MoveNext(item, moveParam, operatorId, reason).Successful)
        //        {
        //            throw new Exception("批量移动失败，请DBA手动回滚数据!已成功移动的实例为："+ successfulList.PackString(","));
        //        }
        //        successfulList.Add(item.Instance.WorkFlowInstanceID);
        //    });
        //    return true;
        //}

        //查找实例
        private WorkFlowInstance Find(string workFlowInstanceId)
        {
            var old = Db.WorkFlowInstance.Find(workFlowInstanceId);
            if (old == null)
            {
                throw new Exception("未找到该实例workFlowInstanceId=>" + workFlowInstanceId);
            }
            return old;
        }
        //寻找结束节点
        private string FindEndNodeId(string workFlowId, string startNodeId)
        {
            var visitedNodes=new List<string>() { startNodeId };
            //所有节点
            var allNodes = Db.NodeRelation.NoTrackingWhere(a => a.Node.WorkFlowID == workFlowId);
            var current = allNodes.FirstOrDefault(a => a.NodeID == startNodeId);
            //找根节点
            while (current.ChildID.HasValue())
            {
                var next = allNodes.Where(a => a.NodeID == current.ChildID).ToList();
                //next为空结束遍历
                if (!next.Any())
                { break; }
                else
                {
                    if (next.Count() > 1)
                    {
                        //多条路径时随机选择一条走过的
                        current = next.FirstOrDefault(a => !visitedNodes.Contains(a.ChildID));
                    }
                    else
                    {
                        current = next.FirstOrDefault();
                    }
                    visitedNodes.Add(current.NodeID);
                }
            }
            return current.ChildID;
        }
        //判断条件
        private bool JudgeCondition(object moveParam, ConvertCondition condition)
        {
            //判断条件
            var realvalue = Qx.Tools.ReflectionUtility.GetObjPropertieValue(moveParam, condition.Property);
            var paramValue = realvalue==null?"": realvalue.ToString();
            var exceptValue = condition.PropertyValue;
            try
            {
                switch (condition.Operator)
                {
                    case "=":
                    {
                        return paramValue == exceptValue;
                    }
                    case "!=":
                    {
                        return paramValue != exceptValue;
                    }
                    case ">":
                    {
                        return double.Parse(paramValue) > double.Parse(exceptValue);
                    }
                    case ">=":
                    {
                        return double.Parse(paramValue) >= double.Parse(exceptValue);
                    }
                    case "<":
                    {
                        return double.Parse(paramValue) < double.Parse(exceptValue);
                    }
                    case "<=":
                    {
                        return double.Parse(paramValue) <= double.Parse(exceptValue);
                    }
                    default:
                        throw new Exception("不支持的操作符Operator=>" + condition.Operator);
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        //判断路径
        private MoveResult JudgePath(List<ConvertCondition> allCondition, object moveParam)
        {
            var result = new MoveResult();

            var relation = allCondition.FirstOrDefault().NodeRelation;
            result.FromNodeId = relation.NodeID;
            result.ToNodeId = relation.ChildID;

            //判断条件
            allCondition.ForEach(c =>
            {

                var conditionStr = c.Property + c.Operator + c.PropertyValue;
                if (JudgeCondition(moveParam, c))
                {
                    result.SucessMsgs.Add("满足" + conditionStr + "的条件");
                }
                else
                {
                    result.ErrorMsgs.Add("不满足" + conditionStr + "的条件");
                }
            });
            return result;
        }
        private MoveResult ChoosePath(string currentNodeId, string nextNodeId)
        {
            var result = new MoveResult();
            result.FromNodeId = currentNodeId;
            result.ToNodeId = nextNodeId;
            //寻找下一节点
            var nextNodeIds = Db.NodeRelation.NoTrackingWhere(a => a.NodeID == currentNodeId).Select(b => b.ChildID);
            if (nextNodeIds.Contains(nextNodeId))
            {
                result.SucessMsgs.Add("已忽略条件，即将直接从[" + currentNodeId + "]转移至下一节点[" + nextNodeId + "]");
            }
            else
            {
                result.ErrorMsgs.Add("不允许跨越节点，不存在从[" + currentNodeId + "]至[" + nextNodeId + "]的通路！");
            }
            return result;
        }
        private MoveResult ChoosePath(List<NodeRelation> allPath, object moveParam)
        {

            var results = new List<MoveResult>(); ;
            //所有路径
            allPath.ForEach(path =>
            {
                //基于路径查找条件
                var allCondition = Db.ConvertCondition.NoTrackingWhere(b => b.NodeRelationID == path.NodeRelationID);
                //某条路径的所有条件
                if (allCondition.Any())
                {
                    results.Add(JudgePath(allCondition, moveParam));
                }
                else
                {
                    //无条件
                     results.Add(new MoveResult()
                     {
                         FromNodeId = path.NodeID,
                         ToNodeId = path.ChildID,
                         SucessMsgs = new List<string>() { "状态转移成功(本条路径未设置条件)"}
                     });

                }
                
            });
            //随机选取1条通路（这里可能有多条通路）
            var successResult = results.Where(a => a.Successful).ToList();
            if (successResult.Count()!= 1)
            {
                throw new MismatchConditionException("传入条件和流程预设条件不匹配，当前条件下存在" + successResult.Count() + "条可达路径，请检查传入条件是否能够正确匹配");
            }
            return successResult.FirstOrDefault();
        }
        public WorkFlowBag CreateInstance(string workFlowId, string uid,string unitId)
        {
            var workFlow = Db.WorkFlow.Find(workFlowId);
            if (workFlow == null)
            {
                throw new Exception("不存在该工作流！workFlowId=>" + workFlowId);
            }

            var model = new WorkFlowInstance()
            {
                CreateTime = DateTime.Now,
                CurrentNodeID = workFlow.StartNodeID,
                Note = Note(uid, "创建工作流实例"),
                WorkFlowID = workFlowId,
                WorkFlowInstanceID = workFlowId + "-" + uid + "-" + DateTime.Now.Random(),
                InstancePeople = uid,
                UnitID = unitId
            };
            Db.WorkFlowInstance.Add(model);
            //创建转移日志
            Db.CreateInstanceChangeLog(model, "1", uid, "激活" + model.WorkFlow.Name + "实例");
            if (Db.SaveChanges() > 0)
            {
                var result = new WorkFlowBag(model);
                return result;
            }
            else
            {
                throw new Exception("工作流实例化失败！");
            }

        }

        public WorkFlowBag FindInstance(string workFlowInstanceId)
        {
            var old = Find(workFlowInstanceId);
            return new WorkFlowBag(old);
        }

        public bool CreateAndMoveNext(WorkFlowParams param)
        {
            param.WorkFlowInstanceId = CreateInstance(param.WorkFlowId,param.Uid, param.UnitId).Instance.WorkFlowInstanceID;
            return MoveNext(param);
        }
        public bool MoveNext(WorkFlowParams param)
        {
            var doSuccessful = false;
            //先移动节点
            var msg = _MoveNext(FindInstance(param.WorkFlowInstanceId),param.MoveParam, param.OperatorId, param.Reason,param.Relation);
            //移动结果
            if (msg.SuccessfulAll)
            {
                try
                {
                    //移动成功后执行业务代码
                    doSuccessful = param.DoIfSuccessful.Invoke(param.WorkFlowInstanceId);
                }
                catch (Exception ex)
                {
                    doSuccessful = false;
                }
                if (!doSuccessful)
                { //业务代码执行失败应回滚实例到上一状态 
                    throw new MoveFailByBllException("业务代码执行失败,请到数据库中手动将业务员代码回滚到上一状态");
                }
                else
                {
                    Db.SaveChanges();//提交工作流事务
                }
            }
            return doSuccessful;
        }

        private MoveResult __MoveNext(WorkFlowBag workFlowBag, MoveResult result,
            string operatorId, string reason)
        {
            //移动到下一节点
            if (result.Successful)
            {
               workFlowBag.MoveToNext(Db, result.ToNodeId, operatorId, reason,
                   FindEndNodeId(workFlowBag.Instance.WorkFlowID,
                        workFlowBag.Instance.WorkFlow.StartNodeID));

                    result.SucessMsgs.Add("已成功转移到下一状态");
            }
            else
            {
                result.SucessMsgs.Add("转移到下一状态失败");
            }
            return result;
        }
        //自动移动
        private MoveResult _MoveNext(WorkFlowBag workFlowBag, object moveParam, string operatorId, string reason , RelationMoveParam relation)
        {
            var currentId = workFlowBag.Instance.CurrentNodeID;
            var allPath = Db.NodeRelation.NoTrackingWhere(a => a.NodeID == currentId);
            var result = ChoosePath(allPath, moveParam);
            //移动主流程
            var moveResult = __MoveNext(workFlowBag, result, operatorId, reason);
            //移动相关节点（子流程）
            if (moveResult.Successful&&relation != null)
            {
                for (var i = 0; i < relation.WorkFlowParam.Count; i++)
                {
                    var item = relation.WorkFlowParam[i];
                    //循环递归移动
                    moveResult.AddRelationMoveResult(_MoveNext(FindInstance(item.WorkFlowInstanceId), relation.GetMoveParam(i), relation.GetOperatorId(i),
                        relation.GetReason(i), relation.GetRelaton(i))) ;
                }
            }
            return moveResult;
        }
        //强制移动
        //private MoveResult _MoveNext(WorkFlowBag workFlowBag, string nextNodeId, string operatorId, string reason, RelationMoveParam relation)
        //{
        //    var currentId = workFlowBag.Instance.CurrentNodeID;
        //    var result = ChoosePath(currentId, nextNodeId);

        //    return __MoveNext(workFlowBag, result, operatorId, reason, relation);
        //}
        public bool DeleteInstance(WorkFlowBag workFlowBag, string operatorId, string reason = "未填写")
        {
            var old = Find(workFlowBag.Instance.WorkFlowInstanceID);
            Db.Entry(old).State = EntityState.Deleted;
            //记录转移日志
            Db.CreateInstanceHistory(old, "3", Note(operatorId, reason));
            return Db.Saved();
        }
        #region Create

        private string Note(string operatorId, string reason)
        {
            return operatorId + "于" + Now.ToTimeStr() + "进行了操作，理由为:" + reason;
        }

        #endregion
        public bool AbortInstance(WorkFlowBag workFlowBag, string operatorId, string reason)
        {
            var instanceId = workFlowBag.Instance.WorkFlowInstanceID;
            var old = Find(instanceId);
            var note = Note(operatorId, reason);
            //记录转移日志
            Db.CreateInstanceChangeLog(old, "4", operatorId, reason);
            //记录实例日志
            Db.CreateInstanceHistory(old, "2", old.Note + "\n" + note);
            //删除实例
            Db.WorkFlowInstance.Remove(old);
            return Db.Saved();
        }

        public Task GetToDo(string uid, List<string> roleList, List<string> unitList)
        {
            return new Task()
            {
                All = Db.WorkFlowInstance.Where(a =>
                roleList.Contains(a.Node.RoleID)&& unitList.Contains(a.UnitID)).ToList().
                Select(a => new ToDoMsg()
                {
                    Title = a.InstancePeople + "的" + a.WorkFlow.Name,
                    Time = a.CreateTime,
                    Url = a.Node.MenuID + "?id=" + a.WorkFlowInstanceID,
                    Note = a.InstancePeople + "在" + a.CreateTime.Year + "-" +
                    a.CreateTime.Month + "-" + a.CreateTime.Day + " " +
                    a.CreateTime.Hour + ":" + a.CreateTime.Minute +
                    "提交了" + a.WorkFlow.Name + "需要" + a.Node.Name,
                    CurrentId = a.CurrentNodeID,
                    AllNode = a.WorkFlow.Node1.Select(b=>new Node() {NodeID = b.NodeID,RoleID = b.RoleID,Domain = b.Domain,MenuID = b.MenuID,Name = b.Name}),
                    AllRelation=a.WorkFlow.Node1.SelectMany(b=>b.NodeRelation).Select(c=>new NodeRelation() {NodeID = c.NodeID,ChildID = c.ChildID}),
                    PathHistory=new List<InstanceChangeLog>()//a.InstanceChangeLog.Select(b=>new InstanceChangeLog() {FromNodeID =b.FromNodeID,ToNodeID = b.ToNodeID,ChangeTime = b.ChangeTime,Operator = b.Operator})

                }).OrderByDescending(z=>z.Time).ToList()
            };

        }

        public bool IsFinished(WorkFlowBag workFlowBag)
        {
            var endNodeId = FindEndNodeId(workFlowBag.Instance.WorkFlowID, workFlowBag.Instance.WorkFlow.StartNodeID);
            var old = Find(workFlowBag.Instance.WorkFlowInstanceID);
            return old.CurrentNodeID == endNodeId;
        }
    }
}
