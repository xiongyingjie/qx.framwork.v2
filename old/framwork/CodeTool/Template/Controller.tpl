/*
db_name=${model.db_name} 
app_namespace=${model.app_namespace} 
repository_name=${model.repository_name}
table_name=${model.table_name}
controller_area=${model.controller_area}
controller_name=${model.controller_name}
table_column_pk_note=${model.table_column_pk_note}
report_title=${model.report_title}
reportId = ${model.reportId},
params = ${model.Params},
pageIndex = ${model.pageIndex},
perCount = ${model.perCount}
model.headers  is an ObjectArray{name,note}}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ${model.app_namespace}.Entity;
using ${model.app_namespace}.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Web.Controllers.Base;

namespace Web.Areas.${model.controller_area}.Controllers
{
    public class ${model.controller_name}Controller : BaseController
    {
   
        private IRepository<${model.table_name}> _repository;

        public ${model.controller_name}Controller(IRepository<${model.table_name}> repository)
        {
            _repository = repository;
        }
      
        // GET: /${model.controller_area}/${model.controller_name}/Add
        public ActionResult Add(${model.table_name} m)
        {
           return _repository.Add(m).HasValue() ?
                Json(State.SuccessConfirmClose, "已添加,是否关闭添加页面"): 
                Json(State.FailConfirmClose, "添加失败,是否关闭添加页面");   
        }
        // GET: /${model.controller_area}/${model.controller_name}/Find
        public ActionResult Find(string id)
        {
            return Json(State.Success, _repository.Find(id));
        }
        // GET: /${model.controller_area}/${model.controller_name}/Items
        public ActionResult Items()
        {
            return Json(State.Success, _repository.ToSelectItems());
        }
        // GET: /${model.controller_area}/${model.controller_name}/Update
        public ActionResult Update(${model.table_name} m)
        {
            return _repository.Update(m)?
               Json(State.SuccessConfirmClose, "已保存,是否关闭编辑页面") :
               Json(State.FailConfirmClose, "保存失败,是否关闭编辑页面");
        }
        // GET: ${model.controller_area}/${model.controller_name}/Delete
        public ActionResult Delete(string id)
        {
            return _repository.Delete(id) ?
               Json(State.Success, "删除成功") :
               Json(State.Fail, "删除失败");
        }

        // GET: ${model.controller_area}/${model.controller_name}/List
        public ActionResult List(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("List",
                    new
                    {
                        reportId = "${model.reportId}",
                        Params = "${model.Params}",
                        pageIndex = ${model.pageIndex},
                        perCount = ${model.perCount}
                    });
            }
            Search.Add("${model.table_column_pk_note}");
          
            InitReport("${model.report_title}", "/${model.controller_area}/${model.controller_name}/Add", "", true, "${model.db_name}", "/${model.controller_area}/${model.controller_name}/Delete", "/${model.controller_area}/${model.controller_name}/Import");
            return ReportJson();
        }
        // GET: /${model.controller_area}/${model.controller_name}/Import
        public ActionResult Import()
        {
            return _repository.Update(new ${model.table_name}()
            {
                $foreach(header in model.headers)  
                    ${header.name} = model.${header.note},
           	　　$end    
            }) ?
                Json(State.Success, "已导入") :
                Json(State.Fail, "导入失败");

        }
    }
}