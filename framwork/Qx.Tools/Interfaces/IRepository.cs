using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Qx.Tools.Interfaces
{
    public interface IRepository<T>
    {
        List<SelectListItem> ToSelectItems(string value = "");
        string Add(T model);
        bool Delete(object id);
        bool Update(T model, string note = "");
        T Find(object id);
        List<T> All();
        List<T> All(Func<T, bool> filter);
        // T Find(object[] id);
    }
}