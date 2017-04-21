using Qx.Msg.Entity;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Msg.Controllers
{
    public class GroupLimiteTypeController : Controller
    {
        // GET: Msg/GroupLimiteType
        private IRepository<crew_limite_type> _crewlimitetype;
        public GroupLimiteTypeController( IRepository<crew_limite_type> crewlimitetype)
        {         
            _crewlimitetype = crewlimitetype;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}