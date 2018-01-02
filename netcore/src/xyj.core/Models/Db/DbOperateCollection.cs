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
                    throw new GetResultBeforeExcuteException("��ȡ���ǰ��ִ��Excute()");
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
                throw new Exception("ִ�й����в���������²���");
            }
            op.IsMain = !Operates.Any();
            Operates.Add(op);
        }
        public List<string> RollBack()
        {
            var rollMsg = new List<string>();
            //�����ع��ѳɹ��Ĳ���
            for (var i = 0; i < SuccessfulOperates.Count; i++)
            {
                rollMsg.Add(AddMessage("��ʼ�ع���" + (i + 1) + "��"));
                rollMsg.Add(AddMessages(new List<string>() { SuccessfulOperates[i].Result.RollBack() }));
            }
            _rollbacked = true;
            rollMsg.Add(AddMessage(SuccessfulOperates.Any()?"�����ع��ɹ�":"����ع�"));
            return rollMsg;
        }
        public string Message { get; private set; }
        //ע�Ⲷ��DbOperateCollectionFailException
        public List<string> Excute(bool throwException=true)
        {
            if (_excuted) return _messages;
            _excuted = true;
          
            //����ִ��
            for (var i = 0; i < Operates.Count; i++)
            {
                AddMessage("��ʼִ�е�" +(i+1) + "��");
                var op = Operates[i];
                AddMessages(op.Excute());
                if (op.Successful)
                {
                    SuccessfulOperates.Add(op);
                }
                else
                {
                    //ֻҪ��һ��û�ɹ��������ع�����ֹ
                    AddMessage("��" + (i + 1) + "��ִ��ʧ��,"+(SuccessfulOperates.Any()? "�����ع�" + SuccessfulOperates.Count() + "������":"��������ֹ"));
                    RollBack();
                    if (throwException)
                    {
                        throw new DbOperateCollectionFailException(("�ɹ�" + SuccessfulOperates.Count() + "��(��" + Operates.Count() + "��):<br/>" +
                                                                    op.Message+ "<hr/>��ϸִ�й���<br/>" +
                                                                    _messages.PackString("<br/>")).ToHtml(),
                            Operates, _messages, i
                            );
                    }
                   // _successful = false;
                    return _messages;
                }
            }
            _successful = true;
            //������ֵ
            if (Operates.Count == 1)//ֻ��һ������
            {//ֱ�ӷ���
                _result = Operates[0].Result.Value;
            }
            else
            { //�ϲ�json
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
                    {//������
                        var destJson = "";
                            for (var k = 0; k < Operates.Count; k++)
                            {//ƴ��

                                var json = (string)Operates[k].Result.Value;
                                if (k == 0)
                                {//��һ��
                                    destJson += json.Substring(0, json.Length - 1);
                                }
                                else
                                {
                                    if (k == Operates.Count - 1)
                                    {
                                        //���һ�� ��������
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
                    {//������
                        throw new NotImplementedException("��֧�ֵ�������<br/>��ǰ��Ҫִ�е���������:" + MainOperate.OperateType);
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
                    throw new GetResultBeforeExcuteException("��ȡ���ǰ��ִ��Excute()");
                }
                return _successful;
            }
        }
    }
}