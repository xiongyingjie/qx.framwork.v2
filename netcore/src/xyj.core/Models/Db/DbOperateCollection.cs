using System;
using System.Collections.Generic;
using System.Linq;
using xyj.core.Exceptions.Db;
using xyj.core.Extensions;

namespace xyj.core.Models.Db
{
    public class DbOperateCollection
    {
        public DbOperateCollection()
        {
           
            _rollbacked=
            IsMain = 
            _successful =
                _excuted = false;
            Operates = new List<DbOperate>();
            SuccessfulOperates=new List<DbOperate>();
            _messages = new List<string>();
            _guid = DateTime.Now.Random(1) + "#";
        }

        public bool IsMain { get; set; }
        private bool _rollbacked;
        private bool _excuted;
        private dynamic _result;

        public bool HasData
        {
            get { return _result !=null && _result != "" && _result != "{}"; }
        }

        public dynamic Result
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
        public DbOperate MainOperate
        {
            get { return Operates.FirstOrDefault(o => o.IsMain); }
        }
       
        public void SetParam(Dictionary<string,object> paramDictionary)
        {
            Operates.ForEach(op =>
            {
                op.SetParam(paramDictionary);
            });
        }
        public void Add(DbOperate op)
        {
            if (_excuted)
            {
                throw new Exception("执行过程中不允许添加新操作");
            }
            op.IsMain = !Operates.Any();
            Operates.Add(op);
        }
        public List<string> RollBack()
        {
            var rollMsg = new List<string>();
            //批量回滚已成功的操作
            for (var i = 0; i < SuccessfulOperates.Count; i++)
            {
                rollMsg.Add(AddMessage("开始回滚第" + (i + 1) + "个"));
                rollMsg.Add(AddMessages(new List<string>() { SuccessfulOperates[i].Result.RollBack() }));
            }
            _rollbacked = true;
            rollMsg.Add(AddMessage(SuccessfulOperates.Any()?"批量回滚成功":"无需回滚"));
            return rollMsg;
        }
        public string Message { get; private set; }
        //注意捕获DbOperateCollectionFailException
        public List<string> Excute(bool throwException=true)
        {
            if (_excuted) return _messages;
            _excuted = true;
          
            //批量执行
            for (var i = 0; i < Operates.Count; i++)
            {
                AddMessage("开始执行第" +(i+1) + "个");
                var op = Operates[i];
                AddMessages(op.Excute());
                if (op.Successful)
                {
                    SuccessfulOperates.Add(op);
                }
                else
                {
                    //只要有一个没成功则批量回滚并终止
                    AddMessage("第" + (i + 1) + "个执行失败,"+(SuccessfulOperates.Any()? "即将回滚" + SuccessfulOperates.Count() + "个操作":"操作已终止"));
                    RollBack();
                    if (throwException)
                    {
                        throw new DbOperateCollectionFailException(("成功" + SuccessfulOperates.Count() + "个(共" + Operates.Count() + "个):<br/>" +
                                                                    op.Message+ "<hr/>详细执行过程<br/>" +
                                                                    _messages.PackString("<br/>")).ToHtml(),
                            Operates, _messages, i
                            );
                    }
                   // _successful = false;
                    return _messages;
                }
            }
            _successful = true;
            //处理返回值
            if (Operates.Count == 1)//只有一个操作
            {//直接返回
                _result = Operates[0].Result.Value;
            }
            else
            { //合并json
                switch (MainOperate.OperateType)
                {
                    case Operate.Add:
                    case Operate.Update:
                    case Operate.Delete:
                    {
                        _result = MainOperate.Result.Value;
                    }
                        break;
                    case Operate.Find:
                    {//单行类
                        var destJson = "";
                            for (var k = 0; k < Operates.Count; k++)
                            {//拼接

                                var json = (string)Operates[k].Result.Value;
                                if (k == 0)
                                {//第一个
                                    destJson += json.Substring(0, json.Length - 1);
                                }
                                else
                                {
                                    if (k == Operates.Count - 1)
                                    {
                                        //最后一个 且无数据
                                        destJson += !Operates[k].Result.HasData
                                            ? "}"
                                            : "," + json.Substring(1, json.Length - 1);
                                    }
                                    else
                                    {
                                        if (Operates[k].Result.HasData)
                                        {

                                            destJson += "," + json.Substring(1, json.Length - 1);
                                        }
                                    }
                                }
                            }
                            _result = destJson;
                    }
                        break;
                    default:
                    {//多行类
                        throw new NotImplementedException("不支持的主操作<br/>当前想要执行的主操作是:" + MainOperate.OperateType);
                    }
                }
            }
            return _messages;
        }

        private readonly List<string> _messages;
        private int _step = 0;
        public string AddMessage(string msg)
        {
            msg = _guid + (++_step) + ":" + msg;
            _messages.Add(msg);
            return msg;
        }
        public string AddMessages(List<string> msgs)
        {
            var msg = "";
            msgs.ForEach(m =>
            {
                msg = (m.Contains("|--") ? "    " : "    |--") + m;
                _messages.Add(msg);
            });
            return msg;
        }
        protected List<DbOperate> Operates { get; }
        protected List<DbOperate> SuccessfulOperates { get; private set; }
        private bool _successful;
        private string _guid;

        public bool Successful
        {
            get
            {
                if (!_excuted)
                {
                    throw new GetResultBeforeExcuteException("获取结果前先执行Excute()");
                }
                return _successful;
            }
        }
    }
}