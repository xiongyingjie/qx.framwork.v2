using System;
using System.Collections.Generic;
using System.Linq;
using xyj.core.Exceptions.Db;
using xyj.core.Extensions;
using xyj.core.Services;

namespace xyj.core.Models.Db
{
    public class DbOperate
    {

        public DbOperate(Dictionary<string,object> paramDictionary, Operate operateType, string dataBase, string table)
        {
            _excuted =
               IsMain = false;
            //取出带前缀的数据(这才是本表真正需要处理的，如果存在旧值，直接覆盖)
            var finalDictionary = new Dictionary<string, object>();
            foreach (var key in paramDictionary.Keys)
            {
                var keyWithoutPre = key.Replace(table + "-", "");//清除前缀
                var v= paramDictionary[key];
                if (finalDictionary.ContainsKey(keyWithoutPre))
                {//执行覆盖
                    finalDictionary[keyWithoutPre] = v;
                }
                else
                {
                    finalDictionary.Add(keyWithoutPre, v);
                }
            }
            _paramDictionary = finalDictionary;
             OperateType = operateType;
            DataBase = dataBase;
            Table = table;
            
        }

        public string Message { get;private set; }

        public List<string> Excute()
        {
            if (_excuted) return _result.Messages;
            var db = new DbService<object>(Table, DataBase);
            switch (OperateType)
            {
                case Operate.Add:
                {
                    _result = db.Add(Param);
                }
                    break;
                case Operate.Update:
                {
                    _result = db.Update(Param);
                }
                    break;
                case Operate.Delete:
                {
                    _result = db.Delete(Param["_id"] + ""); //id
                }
                    break;
                case Operate.Find:
                {
                    _result = (db.Find(Param["_id"] + "")); //id
                }
                    break;
                case Operate.Info:
                {
                    _result = (db.Info()); //id
                }
                    break;
                case Operate.List:
                {
                    _result = (db.All(Param["_searchCondition"] as Dictionary<string, string>));
                }
                    break;
                case Operate.Items:
                {
                    _result = (db.ToSelectItems(Param["_name"]+"", Param["_value"]+""));
                }
                    break;
                case Operate.Download:
                {
                    _result = db.Download(Param["_id"] + "", Param["_file"] + "");
                }
                    break;
                default:
                    throw new NotImplementedException("不支持的操作<br/>当前想要执行的操作是:" + OperateType);
            }
            _excuted = true;
            Message = _result.Messages.PackString("\n");
            return _result.Messages;
        }
        private bool _excuted;
        private ExcuteResult _result;
        public ExcuteResult Result
        {
            get
            {
                if (!_excuted)
                {
                    throw new GetResultBeforeExcuteException("获取结果前先执行Excute()");
                }
                return _result;
            }
        }
      
        public bool IsMain { get; set; }

        public bool Successful
        {
            get
            {
                if (!_excuted)
                {
                    throw new GetResultBeforeExcuteException("获取结果前先执行Excute()");
                }
                return _result.Successful;
            }
        }

        public string DataBase { get; set; }
        public Operate OperateType { get; set; }
        public string Table { get; set; }
        private Dictionary<string, object> _paramDictionary;
        public Dictionary<string, object> Param
        {
            get { return _paramDictionary; }
        } //可能为提交的json，也可能为包含id,name,value,conditionObject等参数的对象

        public void SetParam(Dictionary<string, object> paramDictionary)
        {
            //清除前缀
            _paramDictionary = paramDictionary.Keys.ToDictionary(key => key.Replace(Table + "-", ""), key => paramDictionary[key]);
        }

    }
}