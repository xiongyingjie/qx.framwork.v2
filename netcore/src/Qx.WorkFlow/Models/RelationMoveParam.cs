using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.WorkFlow.Models
{
   public class RelationMoveParam
   {
        public List<WorkFlowParams> WorkFlowParam;

       public RelationMoveParam(List<WorkFlowParams> workFlowParam, object commonMoveParam, string commonOperatorId, string commonReason)
       {
           WorkFlowParam = workFlowParam;
           CommonMoveParam = commonMoveParam;
           CommonOperatorId = commonOperatorId;
           CommonReason = commonReason;
       }
        public RelationMoveParam(List<string> workFlowInstanceIdList,object commonMoveParam = null, string commonOperatorId = "", string commonReason = "")
        {
            WorkFlowParam = workFlowInstanceIdList.Select(item => new WorkFlowParams(item, commonOperatorId, commonMoveParam,null, commonOperatorId, commonReason)).ToList();
            CommonMoveParam = commonMoveParam ?? new { };
            CommonOperatorId = commonOperatorId;
            CommonReason = commonReason;
        }
        public object CommonMoveParam { get; set; }
        public string CommonOperatorId { get; set; }
        public string CommonReason { get; set; }
       public object GetMoveParam(int index)
       {
           return WorkFlowParam[index].MoveParam ?? CommonMoveParam;
       }
        public string GetOperatorId(int index)
        {
            return WorkFlowParam[index].OperatorId ?? CommonOperatorId;
        }
        public string GetReason(int index)
        {
            return WorkFlowParam[index].Reason ?? CommonReason;
        }
        public RelationMoveParam GetRelaton(int index)
        {
            return WorkFlowParam[index].Relation;
        }
    }
}
