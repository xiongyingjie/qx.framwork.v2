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
            //ȡ����ǰ׺������(����Ǳ���������Ҫ����ģ�������ھ�ֵ��ֱ�Ӹ���)
            var finalDictionary = new Dictionary<string, object>();
            foreach (var key in paramDictionary.Keys)
            {
                var keyWithoutPre = key.Replace(table + "-", "");//���ǰ׺
                var v= paramDictionary[key];
                if (finalDictionary.ContainsKey(keyWithoutPre))
                {//ִ�и���
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
                    throw new NotImplementedException("��֧�ֵĲ���<br/>��ǰ��Ҫִ�еĲ�����:" + OperateType);
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
                    throw new GetResultBeforeExcuteException("��ȡ���ǰ��ִ��Excute()");
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
                    throw new GetResultBeforeExcuteException("��ȡ���ǰ��ִ��Excute()");
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
        } //����Ϊ�ύ��json��Ҳ����Ϊ����id,name,value,conditionObject�Ȳ����Ķ���

        public void SetParam(Dictionary<string, object> paramDictionary)
        {
            //���ǰ׺
            _paramDictionary = paramDictionary.Keys.ToDictionary(key => key.Replace(Table + "-", ""), key => paramDictionary[key]);
        }

    }
}