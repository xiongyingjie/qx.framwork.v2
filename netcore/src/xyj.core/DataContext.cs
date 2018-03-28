using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using xyj.core.Exceptions.Db;
using xyj.core.Extensions;
using xyj.core.Models.Db;
using xyj.core.Services;

namespace xyj.core
{
    public class DataContext
    {
        
        private HttpContext _httpContext;
        public DataContext(HttpContext httpContext)
        {
            _httpContext = httpContext;
//针对前后端分离的模式，无需保存状态
            UserId = GetParam("uid").Decrypt();//解码
            UnitId = GetParam("unitid").Decrypt();//解码
            UserName = GetParam("uname");
            KeepState = false;
        }

        public DataContext(HttpContext httpContext, string uid, string unitid="", string userName="")
        {//针对旧版本,需要保存状态
            UserId = uid.Decrypt();//解码
            UnitId = unitid.Decrypt();//解码 
            _httpContext = httpContext;
            UserName = userName;
            KeepState = true;
        }
        public string UserId { get; }
        public string UserName { get;  }
        public int UserType { get; set; }
        public bool IsLogin
        {
            get { return UserId.HasValue(); }
        }
        public bool KeepState { get; }
        public string UnitId { get; }
        private string GetParam(string key)
        {
           
          var v = this.Q(_httpContext,key);
          
            #region 转换特殊标志

            #endregion
            return ConvertString(v);
        }
        private string ConvertString(string v)
        {
            if (v == "_uid")
            {
                v = UserId;
            }
            else if (v == "_unitid")
            {
                v = UnitId;
            }
            else if (v == "_now")
            {
                v = DateTime.Now.FormatTime();
            }
            else if (v == "_id")
            {
                v = DateTime.Now.Random();
            }

            return v;
        }
        #region 数据库操作相关

        private string _cmd;
        private bool _isDebug;
        private bool _ready=true;
        private string _currentTable;
        private Dictionary<string, object> _paramDictionary;
        public string Cmd
        {
             set
            {
                _cmd = value;
                //set cmd后需重新init
                _ready = false;
            }
        }
        public string CurrentTable
        {//如果存在多张表CurrentTable为最后一张
            get
            {
               
                if (CurrentOperate!=null&&!_currentTable.HasValue())
                {
                    throw new Exception("请先设置CurrentTable");
                }
                return _currentTable;
            }
            set
            {
                _currentTable = value;
            }
        }
        
        public Dictionary<string, object> Param
        {
            get
            {
                if (_paramDictionary==null)
                {
                   
                }
                return _paramDictionary;
            }
          
        }
        public object this[string key]
        {
            get
            {
                key = CurrentTable + "-" + key;
                return Param.ContainsKey(key)?Param[key]:"";
            }
            set
            {
                key = CurrentTable + "-" + key;
                if (Param.ContainsKey(key))
                {
                    Param[key] = value+"";
                }
                else
                {
                    Param.Add(key,value+"");
                }
                //set参数后需重新init
                _ready = false;
            }
             }

        private string _dataBase;
        private DbOperateCollection _currentOperate;
        private DbOperateCollection CurrentOperate
        {
            get
            {
                if (_currentOperate == null)
                {
                    if (!_cmd.HasValue())
                    {
                        _cmd = GetParam("cmd").ToLower();
                    }
                    var index = _cmd.LastIndexOf('.');
                    if (index == -1)
                    {
                        throw new DbCmdErrorException("cmd参数错误,没有指明要操作的数据库,当前的cmd:"+ _cmd);
                    }
                    if (_cmd.Contains("delete"))
                    {//兼容删除主键包含.
                        index= _cmd.Split("delete")[0].LastIndexOf('.');
                    }
                 
                    _dataBase = _cmd.Substring(0, index);//数据库信息 wx.sports  
                    var operateString = _cmd.Substring(index + 1).Split('|');//操作数组 user-add-123|user_info-add
                    _currentOperate = new DbOperateCollection();
                    foreach (var o in operateString)
                    {
                        var operateStringArray = o.Split('-');
                       var currentTable = operateStringArray[0];
                        #region 默认操作第一张表
                        if (!_currentTable.HasValue())
                        {
                            _currentTable = currentTable;
                        }
                        #endregion

                        if (_paramDictionary == null)
                        {
                            _isDebug = bool.Parse(GetParam("isDebug"));

                            #region 业务参数
                            _paramDictionary = GetParam("_json").CheckValue("{}").
                                    Replace("#uid", UserId).
                                    Replace("#unitid", UnitId).
                                    Replace("#now", DateTime.Now.FormatTime()).
                                    Replace("#id", DateTime.Now.Random()).ToDictionary<object>();
                            //_paramDictionary["_conditionObject"] = "列明=值";
                            _paramDictionary["_id"] = operateStringArray.Length > 2 ? ConvertString(operateStringArray.Skip(2).ToList().PackString('-')): GetParam("id");
                            _paramDictionary["_name"] = GetParam("name");
                            _paramDictionary["_value"] = GetParam("value");
                            _paramDictionary["_file"] = GetParam("file");

                            
                            var searchCondition = new Dictionary<string, string>();
                            foreach (var pair in _httpContext.Request.Query)
                            {
                                if (pair.Key.StartsWith("search."))
                                {
                                    var v = pair.Value;
                               
                                    searchCondition.Add(pair.Key.Replace("search.",""), ConvertString(v));
                                }
                                   
                            }
                              _paramDictionary["_searchCondition"] = searchCondition;
                            // = HttpContext.Current.Request.Params.Keys.Cast<string>().Where(a=>a.StartsWith("search-")).
                            //    ToDictionary(key => key, key => HttpContext.Current.Request.Params[key]).ToJson();


                            #endregion

                            _paramDictionary["_isDebug"] = _isDebug.ToString();
                        }
                        _currentOperate.Add(new DbOperate(_paramDictionary,
                           operateStringArray[1].ToOperate(), _dataBase, currentTable));
                    }
                 
                }
                return _currentOperate;
            }
        }
        private DbOperateCollections _operates;
        public DbOperateCollections Operates
        {
            get
            {
                if (_operates==null) _operates=new DbOperateCollections();
                return _operates;
            }
           
        }
        #region Push
        private void Push(DbOperate operate)
        {
            var collection = new DbOperateCollection();
            collection.Add(operate);
            Push(collection);
        }
        public void Push(Operate operateType, string table="")
        {
            if (!table.HasValue())
                table = CurrentTable;
            Push(new DbOperate(_paramDictionary, operateType, _dataBase, table));
        }

        public void Push(DbOperateCollection operateCollection)
        {
            Operates.Add(operateCollection);
            _ready = true;
        }
        public void Push()
        {
            CurrentOperate.SetParam(_paramDictionary);
            Operates.Add(CurrentOperate);
            _currentOperate = null;
            //push后标识所有参数都已保存 设为true
            _ready = true;
        }
        #endregion
        public DbOperateCollections Commit()
        {//执行前可更改参数
            if (!_ready) throw new Exception("存在未Push的操作:修改cmd或参数后需要Push");
            if (Operates.IsEmpty)
            {//默认执行当前操作
                Operates.Add(CurrentOperate);
            }
            //执行
            Operates.Excute(_isDebug);
            return Operates;
        }
        #endregion

        #region 临时参数传递
        private Dictionary<string, object> UserData { get; set; }
        public void SetFiled(string key, object value)
        {
            if (UserData == null)
            {
                UserData = new Dictionary<string, object> {{key, value}};
            }
            else if (UserData.ContainsKey(key))
            {
                UserData[key] = value;
            }
            else
            {
                UserData.Add(key, value);
            }
        }
        public object GetFiled(string key)
        {
            if (UserData == null || !UserData.ContainsKey(key))
            {
                return null;
            }
            return UserData[key];
        }
        #endregion
    }
}