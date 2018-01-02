using System;
using System.Collections.Generic;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Tools.Models.Db
{
    public class ExcuteResult
    {
        public ExcuteResult(Operate operateType, string connString, string tableName)
        {
            OperateType = operateType;
            _connString = connString;
            _tableName = tableName;
            Successful = true;
            HasData = false;
            RollBacked = false;
            Value = "";
            RollBackScript = "";
            _guid = tableName+"."+ operateType+"#";
            _messageses =new List<string>();
        }
        private string _tableName;
        private readonly string _connString;
        private bool _successful;
        private readonly string _guid;
        public bool Successful
        {
            get { return _successful; }
            set
            {
                _successful = value;
                //失败会自动回滚
                if (!_successful)
                {
                    RollBack();
                }
            }
        }
        public bool RollBacked { get; private set; }
        private readonly List<string> _messageses;

        public string RollBack()
        {
            if (CanRollBack&&!RollBacked)
            {
                RollBacked = true;
                if (RollBackScript.ExecuteNonQuery(_connString) > 0)
                {
                  return  AddMessage("回滚成功");
                }
                else
                {
                    throw new Exception("回滚失败异常，请检查框架代码!");
                    //AddMessage("回滚失败");
                } 
            }
            else
            {
                return AddMessage("无需回滚");
            }
        }
        private int _step = 0;
        public string AddMessage(string msg)
        {
            msg= _guid  + (++_step) + ":" + msg;
            _messageses.Add(msg);
            return msg;
        }
        public void AddMessages(List<string> msgs)
        {
            msgs.ForEach(m =>
            {
                _messageses.Add("    |--" + m);
            });
        }
        public List<string> Messages
        {
            get
            {
                return _messageses;
            }
        }

        public Operate OperateType { get; }
        public dynamic Value { get;  set; }
        public bool HasData { get; set; }
        public bool CanRollBack
        {
            get
            {
                return RollBackScript.HasValue();
            }
        }
        public string RollBackScript { get;  set; }
    }
}