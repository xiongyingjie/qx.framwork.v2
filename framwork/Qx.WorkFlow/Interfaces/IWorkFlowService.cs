using Qx.WorkFlow.Models;

namespace Qx.WorkFlow.Interfaces
{
    public interface IWorkFlowService
    {
        WorkFlowBag CreateInstance(string workFlowId);
        WorkFlowBag FindInstance(string workFlowInstanceId);
        MoveResult MoveNext(WorkFlowBag workFlowBag, object moveParam, string operatorId, string reason = "未填写");
        MoveResult  MoveNext(WorkFlowBag workFlowBag, string nextNodeId, string operatorId, string reason = "未填写");
        bool DeleteInstance(WorkFlowBag workFlowBag);
        bool IsFinished(WorkFlowBag workFlowBag);
    }
}
