using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Qx.Tools.Interfaces;

namespace Web.Controllers.Base
{
    public interface ICrud< T>
    {
        ActionResult Create();
        ActionResult Create(T viewModel);
       
        ActionResult Edit(string id);
        ActionResult Edit(T viewModel);
        ActionResult Delete(string id);

        ActionResult Details(string id);
        ActionResult Index (string reportId, string Params, int pageIndex = 1, int perCount = 10);

    }
}
