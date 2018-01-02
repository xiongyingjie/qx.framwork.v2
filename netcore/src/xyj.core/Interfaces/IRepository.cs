using System;
using System.Collections.Generic;
using xyj.core.Models.Report;

namespace xyj.core.Interfaces
{
    //泛型
    public interface IRepository<T> : IAutoInject
    {
        List<DropDownListItem> ToSelectItems(string value = "");
        string Add(T model);
        bool Delete(object id);
        bool Update(T model, string note = "");
        T Find(object id);
        List<T> All();
        List<T> All(Func<T, bool> filter);
        // T Find(object[] id);
    }
}