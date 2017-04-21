using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Contents.Entity;
using Qx.Tools.Interfaces;
using Web.Areas.Contents.Controllers;

namespace Web.Areas.Contents.Controllers
{
    public class CrudController : BaseContentsController
    {
        private IRepository<content_column_design> _contentColumnDesign;

        public CrudController(IRepository<content_column_design> contentColumnDesign)
        {
            _contentColumnDesign = contentColumnDesign;
        }

        // GET: Contents/Crud
        public ActionResult Index()
        {
            return View();
        }
    }
}