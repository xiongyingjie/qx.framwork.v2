using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.WorkFlow.Models
{
  public  class WorkFlowParams
    {

      public WorkFlowParams(string workFlowInstanceId, string uid, 
          object moveParam, Func<string, bool> doIfSuccessful=null ,
          string operatorId = "system", string reason = "未填写",
             RelationMoveParam relation = null)
      {
            //string workFlowId, string uid,string unitId, object moveParam,
            // Func<string, bool> doIfSuccessful, string operatorId = "system",string reason = "未填写",
            //  RelationMoveParam relation = null
           IsCreate = false;
           WorkFlowInstanceId = workFlowInstanceId;
          Uid = uid;
          UnitId = "move时可为空";
          MoveParam = moveParam;
            DoIfSuccessful = doIfSuccessful ?? ((id) => true);
            Reason = reason;
          OperatorId = operatorId;
          Relation = relation;
      }
        public WorkFlowParams(string workFlowId,string uid, string unitId,
         object moveParam, Func<string, bool> doIfSuccessful = null,
         string operatorId = "system", string reason = "未填写",
            RelationMoveParam relation = null)
        {

            //创建工作流   
            IsCreate = true;
            WorkFlowId = workFlowId;
            Uid = uid;
            UnitId = unitId;
            MoveParam = moveParam;
            DoIfSuccessful= doIfSuccessful ?? ((id) => true);
            Reason = reason;
            OperatorId = operatorId;
            Relation = relation;
        }
        public bool IsCreate { get; }
        public string WorkFlowId { get; set; }
        public string WorkFlowInstanceId { get; set; }
        public string Uid { get; set; }
        public string UnitId { get; set; }
      
        public object MoveParam { get; set; }
        public string OperatorId { get; set; }
        public string Reason { get; set; }
        public Func<string, bool> DoIfSuccessful { get; set; }
        public RelationMoveParam Relation { get; set; }
    }
}
