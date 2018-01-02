using System;
using System.Collections.Generic;
using System.Linq;
using xyj.core.Exceptions.Db;
using xyj.core.Extensions;

namespace xyj.core.Models.Db
{
    public class DbOperateCollections
    {
        public DbOperateCollections()
        {
            _rollbacked=
            _successful =
                _excuted = false;
            Operates = new List<DbOperateCollection>();
            SuccessfulOperates=new List<DbOperateCollection>();
            _messages=new List<string>();
            _guid = DateTime.Now.Random(1) + "#";
        }
        private bool _excuted;
        private dynamic _result;
    
        public DbOperateCollection MainOperate
        {
            get { return Operates[0]; }
        }
        public void Add(DbOperateCollection op)
        {
            if (_excuted)
            {
                throw new Exception("执行过程中不允许添加新组");
            }
            op.IsMain = !Operates.Any();
            Operates.Add(op);
        }
        public List<string> RollBack()
        {
            //批量回滚已成功的操作
            for (var i = 0; i < SuccessfulOperates.Count; i++)
            {
                AddMessages(SuccessfulOperates[i].RollBack());
            }
            _rollbacked = true;
            AddMessage(SuccessfulOperates.Any() ? "批量回滚组成功" : "无需回滚组");
            return _messages;
        }
        //注意捕获DbOperateCollectionFailException
        public List<string> Excute(bool throwException=true)
        {
            if (_excuted) return _messages;
            _excuted = true;
            //批量执行
            for (var i = 0; i < Operates.Count; i++)
            {
                AddMessage("开始执行第" + (i + 1) + "个组");
                var op = Operates[i];
                AddMessages(op.Excute(false));
                if (op.Successful)
                {
                    SuccessfulOperates.Add(op);
                }
                else
                {
                    //只要有一个没成功则批量回滚并终止
                    AddMessage("第" + (i + 1) + "个组执行失败," + (SuccessfulOperates.Any() ? "即将回滚" + SuccessfulOperates.Count() + "个组" : "操作已终止"));
                    RollBack();
                    if (throwException)
                    {
                        throw new DbOperateCollectionsFailException(("成功" + SuccessfulOperates.Count() + "个(共" + Operates.Count() + "个):<br/>" +
                                                                    op.Message + "<hr/>详细执行过程<br/>" +
                                                                    _messages.PackString("<br/>")).ToHtml(),
                            Operates, _messages, i
                            );
                    }
                    return _messages;
                }
            }
            _successful = true;
            //处理返回值
            if (Operates.Count == 1)//只有一个操作
            {//直接返回
                _result = Operates[0].Result;
            }
            else
            { //合并json
                switch (MainOperate.MainOperate.OperateType)
                {
                    case Operate.Add:
                    case Operate.Update:
                    case Operate.Delete:
                    {
                        _result = MainOperate.Result;
                    }
                        break;
                    case Operate.Find:
                        {//单行类
                            var destJson = "";
                            for (var k = 0; k < Operates.Count; k++)
                            {
                                var json = (string)Operates[k].Result;
                                if (k == 0)
                                {//第一个
                                    destJson += json.Substring(0, json.Length - 1);
                                }
                                else
                                {
                                    if (k == Operates.Count - 1)
                                    {
                                        //最后一个 且无数据
                                        destJson += !Operates[k].HasData
                                               ? "}"
                                               : "," + json.Substring(1, json.Length - 1);

                                    }
                                    else
                                    {
                                        if (Operates[k].HasData)
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
                        throw new NotImplementedException("不支持的主操作<br/>当前想要执行的主操作是:" + MainOperate.MainOperate.OperateType);
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
        public void AddMessages(List<string> msgs)
        {
            msgs.ForEach(m =>
            {
                _messages.Add((m.Contains("|--") ? "    " : "    |--") + m);
            });
        }

        protected List<DbOperateCollection> Operates { get; }
        protected List<DbOperateCollection> SuccessfulOperates { get; private set; }
        private bool _rollbacked;
        private bool _successful;
        private string _guid;
        public bool IsEmpty
        {
            get
            {
             return !Operates.Any();
            }
        }
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