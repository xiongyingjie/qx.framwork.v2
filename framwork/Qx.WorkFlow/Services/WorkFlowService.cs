using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Qx.Tools.CommonExtendMethods;
using Qx.WorkFlow.Entity;
using Qx.WorkFlow.Interfaces;
using Qx.WorkFlow.Models;

namespace Qx.WorkFlow.Services
{
    public class WorkFlowService : BaseRepository, IWorkFlowService
    {
        //查找实例
        private WorkFlowInstance Find(string workFlowInstanceId)
        {
            var old = Db.WorkFlowInstances.Find(workFlowInstanceId);
            if (old == null)
            {
                throw new Exception("未找到该实例workFlowInstanceId=>" + workFlowInstanceId);
            }
            return old;
        }
        //寻找结束节点
        private string FindEndNodeId(string workFlowId,string startNodeId)
        {
            //所有节点
            var allNodes = Db.NodeRelations.NoTrackingWhere(a => a.Node.WorkFlowID == workFlowId);
            var current= allNodes.FirstOrDefault(a=>a.NodeID== startNodeId);
            //找根节点
            while (current.ChildID.HasValue())
            {
                var next= allNodes.FirstOrDefault(a => a.NodeID == current.ChildID);
                if(next==null)
                { break;}
                else
                {
                    current = next;
                }
                
            }
            return current.ChildID;
        }
        //判断条件
        private bool JudgeCondition(object moveParam,ConvertCondition condition)
        {
            //判断条件
            var paramValue = Qx.Tools.ReflectionUtility.GetObjPropertieValue(moveParam, condition.Property).ToString();
            var exceptValue = condition.PropertyValue;
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
                default:throw new Exception("不支持的操作符Operator=>"+ condition.Operator);
            }
        }
        //判断路径
        private MoveResult JudgePath(List<ConvertCondition> allCondition, object moveParam)
        {
            var result =new MoveResult();
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
          return  result;
        }
        private MoveResult ChoosePath(string currentNodeId, string nextNodeId)
        {
            var result = new MoveResult() ;
            result.FromNodeId = currentNodeId;
            result.ToNodeId = nextNodeId;
            //寻找下一节点
            var nextNodeIds = Db.NodeRelations.NoTrackingWhere(a => a.NodeID == currentNodeId).Select(b => b.ChildID);
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
         
            var results = new List<MoveResult>();;
            //所有路径
            allPath.ForEach(a =>
            {
                var allCondition = Db.ConvertConditions.NoTrackingWhere(b => b.NodeRelationID == a.NodeRelationID);
                //某条路径的所有条件
                results.Add(JudgePath(allCondition, moveParam));
            });
            //随机选取1条通路（这里可能有多条通路）
            var successResult = results.Where(a => a.Successful).ToList();
          if(successResult .Count()> 1)
            {
                throw new Exception("捕获异常：存在"+ successResult.Count() + "条可达路径，请检查路径条件是否配置正确");
            }
            return successResult.FirstOrDefault();
        }
        public WorkFlowBag CreateInstance(string workFlowId)
        {
            var workFlow = Db.WorkFlows.Find(workFlowId);
            if (workFlow==null)
            {
                throw new Exception("不存在该工作流！workFlowId=>"+ workFlowId);
            }
           
            var model=new WorkFlowInstance()
            {
                CreateTime = DateTime.Now,
                CurrentNodeID = workFlow.StartNodeID,
                Note = DateTime.Now+ "实例化了一个" + workFlow.Name,
                WorkFlowID = workFlowId,
                WorkFlowInstanceID = workFlowId+"-"+DateTime.Now.Random()
            };
            Db.WorkFlowInstances.Add(model);
            if (Db.SaveChanges() > 0)
            {
                var result=new WorkFlowBag(model);
                return result;
            }
            else
            {
                throw new Exception("工作流实例化失败！");
            }
             
        }

        public WorkFlowBag FindInstance(string workFlowInstanceId)
        {
            var old= Find(workFlowInstanceId);
            return  new WorkFlowBag(old);
        }
        private MoveResult _MoveNext(WorkFlowBag workFlowBag, MoveResult result, string operatorId, string reason )
        {
            //移动到下一节点
            if (result.Successful)
            {
                if (workFlowBag.MoveToNext(result.ToNodeId, operatorId, reason))
                {
                    result.SucessMsgs.Add("已成功转移到下一状态");
                }
                else
                {
                    result.SucessMsgs.Add("转移到下一状态失败");
                }
            }
            return result;
        }
        public MoveResult MoveNext(WorkFlowBag workFlowBag,object moveParam, string operatorId,string reason="未填写")
        {
           
            var currentId = workFlowBag.Instance.CurrentNodeID;
            var allPath = Db.NodeRelations.NoTrackingWhere(a => a.NodeID == currentId);
            var result = ChoosePath(allPath, moveParam);
            return _MoveNext(workFlowBag, result, operatorId, reason);
        }
        public MoveResult MoveNext(WorkFlowBag workFlowBag, string nextNodeId,string operatorId, string reason = "未填写")
        {
            var currentId = workFlowBag.Instance.CurrentNodeID;
            var result = ChoosePath(currentId, nextNodeId);
            return _MoveNext(workFlowBag, result, operatorId, reason);
        }
        public bool DeleteInstance(WorkFlowBag workFlowBag)
        {
            var old = Find(workFlowBag.Instance.WorkFlowInstanceID);
            Db.Entry(old).State=EntityState.Deleted;
            return Db.SaveChanges() > 0;
        }

        public bool IsFinished(WorkFlowBag workFlowBag)
        {
            var endNodeId = FindEndNodeId(workFlowBag.Instance.WorkFlowID, workFlowBag.Instance.WorkFlow.StartNodeID);
            var old = Find(workFlowBag.Instance.WorkFlowInstanceID);
            return old.CurrentNodeID == endNodeId;
        }
    }
}
