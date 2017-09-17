using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Qx.Tools.Models.Db;
namespace Qx.Tools.Interfaces
{
    //泛型
    public interface IRepository<T> : IAutoInject
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