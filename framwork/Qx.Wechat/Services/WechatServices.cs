using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Qx.Tools.CommonExtendMethods;
using Qx.Wechat.Entity;
using Qx.Wechat.Interfaces;
using Qx.Wechat.Models;
using RestSharp;
using HtmlAgilityPack;
using Qx.Wechat.Configs;
using SystemSetup = Qx.Wechat.Models.SystemSetup;

namespace Qx.Wechat.Services
{
   

    public  class WechatServices: BaseRepository, IWechatServices
    {

        #region 微信开发工具类
        private Qx.Wechat.Models.Msg _message;

        private Dictionary<string, string> _param;
        private string _requstLog;
        private Dictionary<string, string> _requstParam;
        private string _xmlRequstBody;

        protected Dictionary<string, string> Param
        {
            get
            {
                if (_param == null)
                {
                    _param = new Dictionary<string, string>();
                }
                return _param;
            }
        }

        protected string ApiUrl(string action, string extraParam)
        {
            var url = ("/cgi-bin/" + action).ToLower();
            return extraParam.HasValue() ? url + "?" + extraParam : url;
        }

        public string ApiHttpGet(string host, string url, Dictionary<string, string> param, string logFileName = "")
        {
            var content = HttpGet(host, ApiUrl(url, null), param);
            return content;
        }

        public string ApiHttpPost(string host, string url, Dictionary<string, string> param, string logFileName = "")
        {
            var content = HttpPost(host, ApiUrl(url, null), param);
            return content;
        }

        public string ApiJsonHttpPost(string host, string url, object param, string logFileName = "", string extraParam = null)
        {
            var content = JsonHttp(host, ApiUrl(url, extraParam), param, Method.POST);
            return content;
        }

        protected string HttpGet(string host, string url, Dictionary<string, string> param)
        {
            return NormalHttp(host, url, param, Method.GET);
        }
        protected T HttpGet<T>(string url)
        {
            var client = new RestClient(new Uri(url));
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            var content = response.Content.Deserialize<T>();
            return content;
        }

        protected string HttpPost(string host, string url, Dictionary<string, string> param)
        {
            return NormalHttp(host, url, param, Method.POST);
        }

        protected string NormalHttp(string host, string url, Dictionary<string, string> param, Method method)
        {
            var request = new RestRequest(url, method);
            foreach (var key in param.Keys)
            {
                request.AddParameter(key, param[key]);
            }
            return BaseHttp(request, host);
        }

        protected string JsonHttp(string host, string url, object objParam, Method method)
        {
            var request = new RestRequest(url, method);
            request.AddJsonBody(objParam);
            request.DateFormat = "application/json";
            return BaseHttp(request, host);
        }

        protected string BaseHttp(RestRequest request, string host)
        {
            var client = new RestClient(new Uri(host));
            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        protected T XmlToObj<T>(string xmlBody) where T : new()
        {
            if (!xmlBody.HasValue())
                return new T();

            var dic = XmlToKeyValues(xmlBody);

            #region dic to jsonString

            var jsonString = new StringBuilder();
            jsonString.Append("{");

            for (var i = 0; i < dic.Count(); i++)
            {
                jsonString.Append("\"");
                jsonString.Append(dic[i].Key);
                jsonString.Append("\"");
                jsonString.Append(":");
                jsonString.Append("\"");
                jsonString.Append(dic[i].Value);
                jsonString.Append("\"");
                if (i < dic.Count() - 1)
                {
                    jsonString.Append(",");
                }
            }
            jsonString.Append("}");

            #endregion

            #region jsonString to obj

            var obj = jsonString.ToString().Deserialize<T>();

            #endregion

            return obj;
        }

        protected List<KeyValuePair<string, string>> XmlToKeyValues(string xmlBody)
        {
            if (!xmlBody.HasValue())
                return new List<KeyValuePair<string, string>>();

            var doc = new HtmlDocument();
            doc.LoadHtml(xmlBody);
            var nodes = doc.DocumentNode.ChildNodes.FirstOrDefault().
                ChildNodes.Where(a => !(a.InnerText == "\r\n" || a.Name == "#text" || a.InnerText == "")).
                Select(b => new KeyValuePair<string, string>(b.Name,
                    b.InnerText.Replace("<![CDATA[", "").Replace("]]>", ""))
                ).ToList();
            return nodes;
        }


        protected string ParseException(Exception ex)
        {
            var error = new StringBuilder();
            error.Append("----------------------" + DateTime.Now + "----------------------------");
            error.Append("\r\n");
            error.Append(ex.Message);
            error.Append("\r\n");
            error.Append("--------------------------StackTrace");
            error.Append("\r\n");
            error.Append(ex.StackTrace);
            error.Append("\r\n");
            foreach (var item in ex.Data)
            {
                error.Append(item);
                error.Append("\r\n");
            }

            if (ex.InnerException != null)
            {
                ex = ex.InnerException;//重新赋值
                error.Append("--------------------------InnerException");
                error.Append("\r\n");
                error.Append(ex.Message);
                error.Append("\r\n");
                error.Append("--------------------------InnerException.StackTrace");
                error.Append("\r\n");
                error.Append(ex.StackTrace);
                error.Append("\r\n");
            }


            return error.ToString();
        }


        #endregion

        public string RefreshToken()
        {
            var action = "Token";

            Param.Add("grant_type", "client_credential");
            Param.Add("appid", Setting.APP_ID);
            Param.Add("secret", Setting.APP_SECRET);
            var content = ApiHttpGet(Setting.URL_WECHAT_HOST, action, Param, action).Deserialize<access_token_model>();
            if (content == null)
            {
                throw new Exception("获取access_token失败!");
            }
            SaveToken(content.access_token,content.expires_in);
            return content.access_token;
        }
        public bool Send_Exchange_Ok_Msg(string touser, string click_url,
    string good_name, string time)
        {
            var data = new
            {
                first = new
                {
                    value = "亲，兑换码已验证成功！",
                    color = "#173177",
                },
                keyword1 = new
                {
                    value = good_name,
                    color = "#173177",
                },
                keyword2 = new
                {
                    value = time,
                    color = "#173177",
                },
               
                remark = new
                {
                    value = "如有疑问，请尽快与我们的客服联系！",
                    color = "#173177",
                }
            };
            return SendTemplateMsg(touser, Setting.template_id_exchanged, click_url, data);
        }
        public bool Send_Charge_Ok_Msg(string touser, string click_url,
            string time, string total_fee, string balance)
        {
            var data = new
            {
                first = new
                {
                    value = "尊敬的用户，您已成功充值！",
                    color = "#173177",
                },
                keyword1 = new
                {
                    value = time,
                    color = "#173177",
                },
                keyword2 = new
                {
                    value = total_fee,
                    color = "#173177",
                },
                keyword3 = new
                {
                    value = balance,
                    color = "#173177",
                },
                remark = new
                {
                    value = "感谢您的支持！",
                    color = "#173177",
                }
            };
            return SendTemplateMsg(touser, Setting.template_id_charge, click_url, data);
        }
        public bool Send_Expence_Ok_Msg(string touser, string click_url,  
            string total_fee, string payment_type, string good_name, string trade_no, string balance)
        {
            var data = new
            {
                first = new
                {
                    value = "您好，您成功购买门票。",
                    color = "#173177",
                },
                keyword1 = new
                {
                    value = total_fee,
                    color = "#173177",
                },
                keyword2 = new
                {
                    value = payment_type,
                    color = "#173177",
                },
                keyword3 = new
                {
                    value = good_name,
                    color = "#173177",
                },
                keyword4 = new
                {
                    value = trade_no,
                    color = "#173177",
                },
                keyword5 = new
                {
                    value = balance,
                    color = "#173177",
                },
                remark = new
                {
                    value = "你购买的商品已支付成功，查看详情了解更多信息！",
                    color = "#173177",
                }
            };
            return SendTemplateMsg(touser, Setting.template_id_expence, click_url, data);
        }

        public bool SendTemplateMsg(string toWho,string templateId,string click_url,object templateData)
        {
            var action = "message/template/send";

            var obj = new
            {
                access_token = GetToken(),
                touser = toWho,// "oksMlwPF5Y1KQvoi8AklF-lUwnYQ",
                template_id = templateId,// "aP5WSx_hkcCEbDJSu1Takrch4tTB1-3YkpRI6ESjeeE",
                url = click_url,// "http://wx.52xyj.cn/WeChat/BookTiketWeb/MyWallet",
                data= templateData// = new
                //{
                //    first = new
                //    {
                //        value = "尊敬的用户，您已成功充值！",
                //        color = "#173177",
                //    },
                //    keyword1 = new
                //    {
                //        value = "巧克力",
                //        color = "#173177",
                //    },
                //    keyword2 = new
                //    {
                //        value = "39.8元",
                //        color = "#173177",
                //    },
                //    keyword3 = new
                //    {
                //        value = "2017年1月26日",
                //        color = "#173177",
                //    },
                //    remark = new
                //    {
                //        value = "欢迎再次充值！",
                //        color = "#173177",
                //    },
                //}
            };
            var content = ApiJsonHttpPost(Setting.URL_WECHAT_HOST, action, obj, "template_send", "access_token=" + GetToken());  
            return content.Deserialize<template_msg_result>().errcode==0;
        }

        //private IWeChatBll _chatBll;

        //public WechatServices(IWeChatBll chatBll)
        //{
        //    _chatBll = chatBll;

        //}

        public SystemSetup GetSetup()
      {
          return Db.SystemSetups.
                Select(a=> 
                new SystemSetup()
                {
                    APP_ID = a.APP_ID,
                    APP_SECRET = a.APP_SECRET,
                    WECHAT_HOST = a.WECHAT_HOST
                }).FirstOrDefault();
      }
      public string GetToken()
      {
          var token= Db.Tokens.FirstOrDefault(a => a.ExpireTime > DateTime.Now);;
          if (token == null)
          {
              RefreshToken();
              token = Db.Tokens.FirstOrDefault(a => a.ExpireTime > DateTime.Now);
              if (token == null)
                    throw new Exception("数据库没有有效的Token!");
            }
          return token.TokenId;
      }
      public bool SaveToken(string tokenId,int expireTime)
        {
            if (!tokenId.HasValue())
            {
                throw new Exception("tokenId 为空!");
            }
            Db.Tokens.Add(new Token()
            {
                TokenId = tokenId,
                GetTime = DateTime.Now,
                ExpireTime = DateTime.Now.AddSeconds(expireTime)
            });
            return Db.SaveChanges() > 0;
        }

      
        //private List<KeyValuePair<string, string>> XmlToKeyValues(string xmlBody)
        //{
        //    if (!xmlBody.HasValue())
        //        return new List<KeyValuePair<string, string>>();

        //    var doc = new HtmlDocument();
        //    doc.LoadHtml(xmlBody);
        //    var nodes = doc.DocumentNode.ChildNodes.FirstOrDefault().
        //        ChildNodes.Where(a => !(a.InnerText == "\r\n" || a.Name == "#text" || a.InnerText == "")).
        //        Select(b => new KeyValuePair<string, string>(b.Name,
        //            b.InnerText.Replace("<![CDATA[", "").Replace("]]>", ""))
        //        ).ToList();
        //    return nodes;
        //}
        private Msg XmlToObj(string xmlBody)
        {
            if (!xmlBody.HasValue())
                return new Msg();

            var dic = XmlToKeyValues(xmlBody);

            #region dic to jsonString

            var jsonString = new StringBuilder();
            jsonString.Append("{");

            for (var i = 0; i < dic.Count(); i++)
            {
                jsonString.Append("\"");
                jsonString.Append(dic[i].Key);
                jsonString.Append("\"");
                jsonString.Append(":");
                jsonString.Append("\"");
                jsonString.Append(dic[i].Value);
                jsonString.Append("\"");
                if (i < dic.Count() - 1)
                {
                    jsonString.Append(",");
                }
            }
            jsonString.Append("}");

            #endregion

            #region jsonString to obj

            var obj = jsonString.ToString().Deserialize<Msg>();

            #endregion

            return obj;
        }

        public bool Log(string logString, bool hasError)
        {
            var model = new Log()
            {
                LogId = hasError ? "false" : "success" + DateTime.Now.Random().ToString(),
                Contents = logString,
                Time = DateTime.Now,
                HasError = hasError ? 1 : 0
            };
            if (Db.Logs.Find(model.LogId) == null)
            {
                Db.Logs.Add(model);
            }
            return Db.SaveChanges() > 0;
        }
        private bool _LogMsg(Msg message)
        {
            //记得解决发送2次重复问题
            switch (message.GetMsgType())
            {
                case MsgTypeEnum.Text:
                {
                        //WriteFile(message.Serialize() + "\r\n" + "\r\n", false);
                        //     WriteFile(message.Serialize().Deserialize<TextMsg>().Serialize() + "\r\n" + "\r\n" + "\r\n", false);
                        //var model = new TextMsg()
                        //{
                        //    MsgId = "6348073328791966656",
                        //    Content = "测试直接写入",
                        //    MsgType = "text",
                        //    CreateTime = "1478025999",
                        //    FromUserName = "oe4J2uAJoapkwmf039OcFy_YwVMw",
                        //    ToUserName = "gh_fc4c31ef2ade"
                        //};
                    WriteFile(message.Serialize(),false);
                    var model = message.Serialize().Deserialize<TextMsg>();
                    if (Db.TextMsgs.Find(model.MsgId) == null)
                    {
                            Db.TextMsgs.Add(model);
                        }
                    }
                    break;
                case MsgTypeEnum.Voice:
                    {
                        var model = message.Serialize().Deserialize<VoiceMsg>();
                        if (Db.VoiceMsgs.Find(model.MsgId) == null)
                        {
                            Db.VoiceMsgs.Add(model);
                        }
                    }
                    break;
                case MsgTypeEnum.Video:
                    {
                        var model = message.Serialize().Deserialize<VideoMsg>();
                        if (Db.VideoMsgs.Find(model.MsgId) == null)
                        {
                            Db.VideoMsgs.Add(model);
                        }
                    }
                    break;
                case MsgTypeEnum.Image:
                    {
                        var model = message.Serialize().Deserialize<ImageMsg>();
                        if (Db.ImageMsgs.Find(model.MsgId) == null)
                        {
                            Db.ImageMsgs.Add(model);
                            Db.SaveChanges();
                        }
                    }
                    break;
                case MsgTypeEnum.Link:
                    {
                        var model = message.Serialize().Deserialize<LinkMsg>();
                        if (Db.LinkMsgs.Find(model.MsgId) == null)
                        {
                            Db.LinkMsgs.Add(model);
                            Db.SaveChanges();
                        }
                    }
                    break;
                case MsgTypeEnum.Location:
                    {
                        var model = message.Serialize().Deserialize<LocationMsg>();
                        if (Db.LocationMsgs.Find(model.MsgId) == null)
                        {
                            Db.LocationMsgs.Add(model);
                            Db.SaveChanges();
                        }
                    }
                    break;
                case MsgTypeEnum.Shortvideo:
                    {
                        var model = message.Serialize().Deserialize<ShortVideoMsg>();
                        if (Db.ShortVideoMsgs.Find(model.MsgId) == null)
                        {
                            Db.ShortVideoMsgs.Add(model);
                            Db.SaveChanges();
                        }
                    }
                    break;
                case MsgTypeEnum.NotMsg:
                {
                        throw new Exception("框架不支持记录NotMsg消息");
                    }
            }
          

            return true;
        }

        private bool _LogEvent(Msg message)
        {
          
            switch (message.GetEventType())
            {
                case EventTypeEnum.CLICK:
                    {
                        var model = message.Serialize().Deserialize<MenuEvent>();
                        if (Db.MenuEvents.Find(model.EventId) == null)
                        {
                            Db.MenuEvents.Add(model);
                        }
                      
                    }
                    break;
                case EventTypeEnum.VIEW:
                    {
                        var model = message.Serialize().Deserialize<MenuEvent>();
                        if (Db.MenuEvents.Find(model.EventId) == null)
                        {
                            Db.MenuEvents.Add(model);
                        }
                    }
                    break;
                case EventTypeEnum.SCAN:
                    {
                        var model = message.Serialize().Deserialize<MenuEvent>();
                        if (Db.MenuEvents.Find(model.EventId) == null)
                        {
                            Db.MenuEvents.Add(model);
                        }
                    }
                    break;
                case EventTypeEnum.SUBSRIBE:
                    {
                        var model = message.Serialize().Deserialize<SubscribeEvent>();
                        if (Db.SubscribeEvents.Find(model.EventId) == null)
                        {
                            Db.SubscribeEvents.Add(model);
                        }
                      
                    }
                    break;
                case EventTypeEnum.UNSUBSRIBE:
                    {
                        var model = message.Serialize().Deserialize<SubscribeEvent>();
                        if (Db.SubscribeEvents.Find(model.EventId) == null)
                        {
                            Db.SubscribeEvents.Add(model);
                        }
                    }
                    break;
                case EventTypeEnum.LOCATION:
                    {
                        var model = message.Serialize().Deserialize<LocationEvent>();
                        if (Db.LocationEvents.Find(model.EventId) == null)
                        {
                            Db.LocationEvents.Add(model);
                        }
                       
                    }
                    break;
                case EventTypeEnum.NotEvent:
                {
                        throw new Exception("框架不支持回复NotEvent事件");
                    }
            }
            return Db.SaveChanges() > 0;
        }

        private Msg BeforeHandleLog(string xmlBody)
        {
            //序列化
            var msg = XmlToObj(xmlBody);
            #region 记录日志
            Log(xmlBody, false);
            if (msg.IsEvent)
            {
                if (!_LogEvent(msg))
                {
                    //记录消息错误
                    Log(xmlBody, true);
                }

            }
            else
            {
                if (!_LogMsg(msg))
                {
                    //记录事件错误
                    Log(xmlBody, true);
                }
            }
            #endregion

            return msg;
        }
        public string MsgHandle(string xmlBody)
        {
          

            //记录处理前日志
            var msg = BeforeHandleLog(xmlBody);
            //处理绑定
            //if (!_chatBll.HasBinding(msg.FromUserName))
            //{
            //    _chatBll.Binding(msg.FromUserName);
            //}
            ////处理业务
            //var result= _chatBll.Main(msg);
            //记录处理后日志
            object reply;
          //  AfterHandleLog(result,out reply);
           //根据不同消息生成不同消息

            #region 响应请求
            //var reply = Db.ReplySetups.
            //    FirstOrDefault(a => (
            //    a.KeyWord.Contains(msg.Content)
            //    ));

            //if (reply == null)
            //{
            //    //设置默认回复
            //    result = new ReplyTextMsg()
            //    {
            //        ToUserName = msg.FromUserName,
            //        FromUserName = msg.ToUserName,
            //        CreateTime = (int)(DateTime.Now - DateTime.MinValue).TotalSeconds+"",
            //        MsgType = MsgTypeEnum.Text.ToString().ToLower(),
            //        Content = "[开发模式自动回复]小熊已收到您的消息"
            //    };
            //}
            //else
            //{
            //    //使用文本回复

            //    result= Db.ReplyTextMsgs.Find(reply.ReplyMsgId);
            //    //回复给 发送者
            //    result.ToUserName = msg.FromUserName;
            //    result.FromUserName = msg.ToUserName;
            //    result.CreateTime = (int) (DateTime.Now - DateTime.MinValue).TotalSeconds + "";
            //    result.MsgType = MsgTypeEnum.Text.ToString().ToLower();
            //}
            #endregion

            //格式化为xml返回微信服务器
           // return result.ToXml();
            return null;
        }

        private bool AfterHandleLog(Msg replySrc,out object replyResult)
        {
            replyResult=new object();



            //记得解决发送2次重复问题
            if (Db.ReplyMsgs.Find(replySrc.MsgId) == null)
            {
                var fatherModel = new ReplyMsg()
                {
                    ReplyMsgId = replySrc.MsgId,
                    FromUserName = replySrc.FromUserName,
                    ToUserName = replySrc.ToUserName,
                    CreateTime = replySrc.CreateTime,
                    MsgType = replySrc.MsgType,
                };
                Db.ReplyMsgs.Add(fatherModel);
            }

            switch (replySrc.GetMsgType())
            {
                case MsgTypeEnum.Text:
                {
                    WriteFile(replySrc.Serialize(),false);
                    if (Db.ReplyTextMsgs.Find(replySrc.MsgId) == null)
                    {
                        var model = new ReplyTextMsg()
                        {
                            ReplyMsgId = replySrc.MsgId,
                            Content = replySrc.Content,
                        };
                        Db.ReplyTextMsgs.Add(model);
                    }
                    //直接返回msg类型，如果不可以则返回具体类型
                    replyResult= replySrc;
                }
                    break;
                case MsgTypeEnum.Voice:
                {
                    var model = replySrc.Serialize().Deserialize<ReplyVoiceMsg>();
                    if (Db.ReplyVoiceMsgs.Find(model.ReplyMsgId) == null)
                    {
                        Db.ReplyVoiceMsgs.Add(model);
                    }
                    replyResult = model;
                }
                    break;
                case MsgTypeEnum.Video:
                {
                    var model = replySrc.Serialize().Deserialize<ReplyVideoMsg>();
                    if (Db.ReplyVideoMsgs.Find(model.ReplyMsgId) == null)
                    {
                        Db.ReplyVideoMsgs.Add(model);
                    }
                        replyResult = model;
                    }
                    break;
                case MsgTypeEnum.Image:
                {
                    var model = replySrc.Serialize().Deserialize<ReplyImageMsg>();
                    if (Db.ReplyImageMsgs.Find(model.ReplyMsgId) == null)
                    {
                        Db.ReplyImageMsgs.Add(model);
                    }
                        replyResult = model;
                    }
                    break;
                case MsgTypeEnum.Link:
                {
                    throw new Exception("框架不支持回复Link消息");
                }
                    break;
                case MsgTypeEnum.Location:
                {
                    throw new Exception("框架不支持回复Location消息");
                }
                    break;
                case MsgTypeEnum.Shortvideo:
                {
                    throw new Exception("框架不支持回复Shortvideo消息");
                }
                    break;
                case MsgTypeEnum.NotMsg:
                {
                    throw new Exception("框架不支持回复NotMsg消息");
                }
            }
            return Db.SaveChanges() > 0;
            }

        public MsgTypeEnum ParseMsgType(string msgType)
        {
            if (msgType.Length <= 0)
            {
                return MsgTypeEnum.NotMsg;
            }
            var type = msgType.ToUpper()[0] + msgType.Substring(1);
            return (MsgTypeEnum)Enum.Parse(typeof(MsgTypeEnum), type);
        }

        public EventTypeEnum ParseEventType(string msgType)
        {
            if (msgType.Length <= 0)
            {
                return EventTypeEnum.NotEvent;
            }
            var type = msgType.ToUpper();
            return (EventTypeEnum)Enum.Parse(typeof(EventTypeEnum), type);
        }
    }
}
