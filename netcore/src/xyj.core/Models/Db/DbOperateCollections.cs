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
                throw new Exception("ִ�й����в������������");
            }
            op.IsMain = !Operates.Any();
            Operates.Add(op);
        }
        public List<string> RollBack()
        {
            //�����ع��ѳɹ��Ĳ���
            for (var i = 0; i < SuccessfulOperates.Count; i++)
            {
                AddMessages(SuccessfulOperates[i].RollBack());
            }
            _rollbacked = true;
            AddMessage(SuccessfulOperates.Any() ? "�����ع���ɹ�" : "����ع���");
            return _messages;
        }
        //ע�Ⲷ��DbOperateCollectionFailException
        public List<string> Excute(bool throwException=true)
        {
            if (_excuted) return _messages;
            _excuted = true;
            //����ִ��
            for (var i = 0; i < Operates.Count; i++)
            {
                AddMessage("��ʼִ�е�" + (i + 1) + "����");
                var op = Operates[i];
                AddMessages(op.Excute(false));
                if (op.Successful)
                {
                    SuccessfulOperates.Add(op);
                }
                else
                {
                    //ֻҪ��һ��û�ɹ��������ع�����ֹ
                    AddMessage("��" + (i + 1) + "����ִ��ʧ��," + (SuccessfulOperates.Any() ? "�����ع�" + SuccessfulOperates.Count() + "����" : "��������ֹ"));
                    RollBack();
                    if (throwException)
                    {
                        throw new DbOperateCollectionsFailException(("�ɹ�" + SuccessfulOperates.Count() + "��(��" + Operates.Count() + "��):<br/>" +
                                                                    op.Message + "<hr/>��ϸִ�й���<br/>" +
                                                                    _messages.PackString("<br/>")).ToHtml(),
                            Operates, _messages, i
                            );
                    }
                    return _messages;
                }
            }
            _successful = true;
            //������ֵ
            if (Operates.Count == 1)//ֻ��һ������
            {//ֱ�ӷ���
                _result = Operates[0].Result;
            }
            else
            { //�ϲ�json
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
                        {//������
                            var destJson = "";
                            for (var k = 0; k < Operates.Count; k++)
                            {
                                var json = (string)Operates[k].Result;
                                if (k == 0)
                                {//��һ��
                                    destJson += json.Substring(0, json.Length - 1);
                                }
                                else
                                {
                                    if (k == Operates.Count - 1)
                                    {
                                        //���һ�� ��������
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
                    {//������
                        throw new NotImplementedException("��֧�ֵ�������<br/>��ǰ��Ҫִ�е���������:" + MainOperate.MainOperate.OperateType);
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
                    throw new GetResultBeforeExcuteException("��ȡ���ǰ��ִ��Excute()");
                }
                return _successful;
            }
        }
    }
}