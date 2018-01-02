using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Qx.WorkFlow.Interfaces;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class WorkFlowController :BaseController
    {
 
        private IWorkFlowService _workFlowService;
        private IRepository<user_role> _userRole;

        public WorkFlowController(IWorkFlowService workFlowService, IRepository<user_role> userRole)
        {
            _workFlowService = workFlowService;
            _userRole = userRole;

        }
        // 获取待办 GET: /WorkFlow/GetToDo?uid=
        public ActionResult GetToDo()
        {
        
            return Json(State.Success, _workFlowService.GetToDo(DataContext.UserId, 
                _userRole.All(a => a.user_id == DataContext.UserId).Select(b => b.role_id).ToList(), WorkFlowDoman),false);
        }
        // 获取下一步的路径信息 GET: /WorkFlow/GetNextInfo?id=
        public ActionResult GetNextInfo(string id)
        { 
            return Json(State.Success, _workFlowService.FindInstance(id).NextStepInfo(),false);
        }
  
    }
}