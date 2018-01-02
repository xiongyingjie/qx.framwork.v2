using System;
using System.Collections.Generic;
using xyj.core.Models.Db;

namespace xyj.core.Interfaces
{
    public interface IDbService<T>:IAutoInject
    {
        IDbService<T> Get(Enum table);
        IDbService<T> Init(Enum table, string connString);
        ExcuteResult Add(Dictionary<string, object> paramDictionary);
        ExcuteResult Update(Dictionary<string, object> paramDictionary);
        ExcuteResult Delete(string id);
        ExcuteResult ToSelectItems(string name, string value = "");
        ExcuteResult All();
        ExcuteResult All(Dictionary<string,string> conditionObject);
        ExcuteResult Find(string id);
        ExcuteResult Download(string id, string fileColumnName);
        Table TableInfo { get; }
    }
}