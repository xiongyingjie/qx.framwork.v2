using System;
using System.Collections.Generic;
using Qx.Tools.Interfaces;
using Qx.WorkFlow.Models;

namespace Qx.WorkFlow.Interfaces
{
    public interface IWorkFlowService : IAutoInject
    {
        List<WorkFlowBag> FindInstances(List<string> workFlowInstanceIdArray);
        WorkFlowBag CreateInstance(string workFlowId, string uid, string unitId);
        WorkFlowBag FindInstance(string workFlowInstanceId);
        bool CreateAndMoveNext(WorkFlowParams param);
        bool MoveNext(WorkFlowParams param);
        bool DeleteInstance(WorkFlowBag workFlowBag, string operatorId, string reason = "未填写");
        bool AbortInstance(WorkFlowBag workFlowBag, string operatorId, string reason);
        Task GetToDo(string uid, List<string> roleList, List<string> unitList);
        bool IsFinished(WorkFlowBag workFlowBag);
    }
}
